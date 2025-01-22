using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.Utility;
using System.Diagnostics;
using System.Collections;
using Infragistics.Shared;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="ToolsCollection"/> for use as an <see cref="IUIElementAdapter"/>.
	/// </summary>
	public class ToolsCollectionUIAdapter : UIElementAdapter<ToolBase>
	{
		#region Member Variables

		private static Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl> menuToolsAdapters = new Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl>();
		private static Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl> toolbarToolsAdapters = new Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl>();

		// ribbon group keys are not unique across the toolbarsmanager so we need to keep
		// a collection of them with respect to their containing tab's key
		private static Dictionary<ToolsCollectionKey, Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl>> ribbonGroupToolsAdapters = new Dictionary<ToolsCollectionKey, Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl>>();

		// for the application menu, we'll use the same structure since we still want to use
		// a weak reference on the toolbarsmanager but we'll use constants for the areas
		private static Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl> applicationMenuAdapters = new Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl>();

		private const string ApplicationMenuAreaLeft = "Left";
		private const string ApplicationMenuAreaRight = "Right";
		private const string ApplicationMenuAreaFooter = "Footer";

		// for the special toolbars, we'll use the same structure since we still want to use
		// a weak reference on the toolbarsmanager but we'll use constants for the areas
		private static Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl> specialToolbarAdapters = new Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl>();

		private const string SpecialToolbarQuickAccessToolbar = "Qat";
		private const string SpecialToolbarMiniToolbar = "Mini";
		private const string SpecialToolbarTabItemToolbar = "Tab";

		private ToolsCollectionAdapterImpl toolsAdapter;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ToolsCollectionUIAdapter"/>
		/// </summary>
		/// <param name="tools">Tools collection represented by the ui adapter</param>
		public ToolsCollectionUIAdapter(ToolsCollectionBase tools)
		{
			Guard.ArgumentNotNull(tools, "tools");
			
			if (tools.Owner is UltraTaskPaneToolbar || 
				(tools.Owner is PopupMenuTool == false && 
				 tools.Owner is RibbonGroup == false &&
				 tools.Owner is ApplicationMenuArea == false &&
				 tools.Owner is UltraToolbarBase == false))
				throw new ArgumentException(Properties.Resources.InvalidToolsCollectionForElements, "tools");

			if (tools.ToolbarsManager == null)
				throw new ArgumentException(Properties.Resources.ToolsCollectionNotPartOfManager, "tools");

			if (tools.Owner is PopupMenuTool)
				this.toolsAdapter = GetMenuToolsAdapter(tools);
			else if (tools.Owner is RibbonGroup)
				this.toolsAdapter = GetRibbonGroupToolsAdapter(tools);
			else if (tools.Owner is ApplicationMenuArea)
			{
				string area = ((ApplicationMenuArea)tools.Owner).ApplicationMenu.ToolAreaLeft.Equals(tools.Owner)
					? ApplicationMenuAreaLeft
					: ApplicationMenuAreaRight;

				this.toolsAdapter = GetApplicationMenuToolsAdapter(tools, area);
			}
			else if (tools.Owner is ApplicationMenuFooterToolbar)
				this.toolsAdapter = GetApplicationMenuToolsAdapter(tools, ApplicationMenuAreaFooter);
			else if (tools.Owner is QuickAccessToolbar)
				this.toolsAdapter = GetApplicationMenuToolsAdapter(tools, SpecialToolbarQuickAccessToolbar);
			else if (tools.Owner is MiniToolbar)
				this.toolsAdapter = GetApplicationMenuToolsAdapter(tools, SpecialToolbarMiniToolbar);
			else if (tools.Owner is RibbonTabItemToolbar)
				this.toolsAdapter = GetApplicationMenuToolsAdapter(tools, SpecialToolbarTabItemToolbar);
			else
				this.toolsAdapter = GetToolbarToolsAdapter(tools);
		}
		#endregion //Constructor

		#region Properties

		#region Tools
		/// <summary>
		/// The <see cref="ToolsCollection"/> that is represented by the adapter.
		/// </summary>
		internal protected ToolsCollectionBase Tools
		{
			get { return this.toolsAdapter.Tools; }
		}
		#endregion //Tools

		#endregion //Properties

		#region Methods

		#region Add
		/// <summary>
		/// Adds an <see cref="ToolBase"/> to the <see cref="ToolsCollection"/> associated with the adapter.
		/// </summary>
		/// <param name="uiElement">Tool to add to the group</param>
		/// <returns>The tool that was added.</returns>
		protected override ToolBase Add(ToolBase uiElement)
		{
			return this.toolsAdapter.Add(uiElement, this.GetNewElementIndex(uiElement));
		}

		#endregion //Add

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which an item will be added.
		/// </summary>
		/// <param name="tool">Tool to evaluate</param>
		/// <returns>By default, tools are added at the end of the associated <see cref="Tools"/> collection.</returns>
		protected virtual int GetNewElementIndex(ToolBase tool)
		{
			return this.Tools.Count;
		}
		#endregion //GetNewElementIndex

		#region GetToolsAdapter (static)
		private static ToolsCollectionAdapterImpl GetMenuToolsAdapter(ToolsCollectionBase tools)
		{
			return GetToolsAdapter(tools, menuToolsAdapters);
		}

		private static ToolsCollectionAdapterImpl GetToolbarToolsAdapter(ToolsCollectionBase tools)
		{
			return GetToolsAdapter(tools, toolbarToolsAdapters);
		}

		private static ToolsCollectionAdapterImpl GetRibbonGroupToolsAdapter(ToolsCollectionBase tools)
		{
			Debug.Assert(tools.Owner is RibbonGroup, "Unexpected owner type.");

			RibbonGroup group = (RibbonGroup)tools.Owner;
			ToolsCollectionKey tabKey = new ToolsCollectionKey(tools.ToolbarsManager, group.Tab.Key);
			Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl> groupsCollectionAdapters;

			if (ribbonGroupToolsAdapters.TryGetValue(tabKey, out groupsCollectionAdapters) == false)
			{
				groupsCollectionAdapters = new Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl>();
				ribbonGroupToolsAdapters.Add(tabKey, groupsCollectionAdapters);
			}

			return GetToolsAdapter(tools, groupsCollectionAdapters);
		}

		private static ToolsCollectionAdapterImpl GetApplicationMenuToolsAdapter(ToolsCollectionBase tools, string key)
		{
			return GetToolsAdapter(tools, applicationMenuAdapters, key);
		}

		private static ToolsCollectionAdapterImpl GetSpecialToolbarToolsAdapter(ToolsCollectionBase tools, string key)
		{
			return GetToolsAdapter(tools, specialToolbarAdapters, key);
		}

		private static ToolsCollectionAdapterImpl GetToolsAdapter(ToolsCollectionBase tools, Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl> adapters)
		{
			Debug.Assert(tools.Owner is KeyedSubObjectBase, "Unexpected owner type.");

			return GetToolsAdapter(tools, adapters, ((KeyedSubObjectBase)tools.Owner).Key);
		}

		private static ToolsCollectionAdapterImpl GetToolsAdapter(ToolsCollectionBase tools, Dictionary<ToolsCollectionKey, ToolsCollectionAdapterImpl> adapters, string ownerKey)
		{
			ToolsCollectionKey key = new ToolsCollectionKey(tools.ToolbarsManager, ownerKey);
			ToolsCollectionAdapterImpl collectionAdapter;

			if (adapters.TryGetValue(key, out collectionAdapter) == false)
			{
				collectionAdapter = new ToolsCollectionAdapterImpl(tools);
				adapters.Add(key, collectionAdapter);
			}

			return collectionAdapter;
		}
		#endregion //GetToolsAdapter (static)

		#region Remove
		/// <summary>
		/// Removes the specified <see cref="ToolBase"/> from the associated <see cref="ToolsCollection"/>
		/// </summary>
		/// <param name="uiElement">Tool that should be removed.</param>
		protected override void Remove(ToolBase uiElement)
		{
			// remove the instancen
			this.toolsAdapter.Remove(uiElement);
		}
		#endregion //Remove

		#endregion // Methods

		#region ToolsCollectionKey nested class
		private class ToolsCollectionKey
		{
			#region Member Variables

			private string ownerKey;
			private WeakReference manager;

			#endregion //Member Variables

			#region Constructor
			internal ToolsCollectionKey(UltraToolbarsManager manager, string ownerKey)
			{
				this.ownerKey = ownerKey;
				this.manager = new WeakReference(manager);
			}
			#endregion //Constructor

			#region Equals
			public override bool Equals(object obj)
			{
				ToolsCollectionKey instance = obj as ToolsCollectionKey;

				if (instance != null)
				{
					return instance.manager == this.manager &&
						instance.ownerKey == this.ownerKey;
				}

				return false;
			}
			#endregion //Equals

			#region GetHashCode
			public override int GetHashCode()
			{
				return this.ownerKey.GetHashCode();
			}
			#endregion //GetHashCode
		}
		#endregion //ToolsCollectionKey nested class

		#region ToolsCollectionAdapterImpl nested class
		private class ToolsCollectionAdapterImpl
		{
			#region Member Variables

			private WeakReference tools;
			private WeakReference manager;

			// we want to keep a list of the tools that we have 
			// handed out. in this way, if two objects ask for the 
			// same tool instance to be added, we can hand back the 
			// original instance and you won't end up with multiple
			// instances of the same tool on the menu/toolbar.
			private Dictionary<string, ToolInstance> toolInstances = new Dictionary<string, ToolInstance>();

			#endregion //Member Variables

			#region Constructor
			internal ToolsCollectionAdapterImpl(ToolsCollectionBase tools)
			{
				// for a menu, store the tools collection of the root tool
				// in case the instance we were created for has been removed.
				if (tools.Owner is PopupMenuTool)
				{
					PopupMenuTool menu = tools.Owner as PopupMenuTool;
					tools = ((PopupMenuTool)menu.SharedProps.RootTool).Tools;
				}

				this.tools = new WeakReference(tools);
				this.manager = new WeakReference(tools.ToolbarsManager);
			}
			#endregion //Constructor

			#region Methods

			#region Add
			public ToolBase Add(ToolBase uiElement, int newToolIndex)
			{
				ToolInstance instance;

				if (this.toolInstances.TryGetValue(uiElement.Key, out instance))
				{
					instance.IncrementCount();
				}
				else
				{
					ToolBase tool;

					if (this.Manager.Tools.Exists(uiElement.Key) == false)
					{
						// create a root tool instance
						this.Manager.Tools.Add(uiElement);
					}

					// see if there is an instance of the tool in the collection
					int index = this.Tools.IndexOf(uiElement.Key);

                    bool existingTool = index >= 0;

					if (index < 0)
					{
						// now create an instance of the tool
						index = newToolIndex;
						this.Tools.Insert(index, uiElement);
					}

					// get the tool
					tool = this.Tools[index];

					// then create a toolinstance to manage the count
                    // AS 3/13/09 TFS15391
                    // Track whether the tool existing before so we know 
                    // whether to remove it when the last toolinstance is
                    // removed.
                    //
                    //instance = new ToolInstance(tool);
					instance = new ToolInstance(tool, existingTool);
					this.toolInstances.Add(uiElement.Key, instance);
				}

				return instance.Tool;
			}

			#endregion //Add

			#region Remove
			public void Remove(ToolBase uiElement)
			{
				ToolInstance instance = null;

				if (this.toolInstances.TryGetValue(uiElement.Key, out instance))
				{
					instance.DecrementCount();

                    if (instance.Count == 0)
                    {
                        this.toolInstances.Remove(uiElement.Key);

                        // AS 3/13/09 TFS15391
                        // The tool instance needs to be removed from the Tools collection
                        // if it didn't exist when the ToolInstance was first created.
                        //
                        if ( !instance.ExistingTool )
                            this.Tools.Remove(instance.Tool);
                    }
				}
			}
			#endregion //Remove 

			#endregion //Methods

			#region Properties

			#region Manager
			private UltraToolbarsManager Manager
			{
				get { return this.manager.Target as UltraToolbarsManager; }
			} 
			#endregion //Manager

			#region Tools
			public ToolsCollectionBase Tools
			{
				get
				{
					return this.tools.Target as ToolsCollectionBase;
				}
			}
			#endregion //Tools 

			#region ToolInstancesCount
			public int ToolsInstancesCount
			{
				get { return this.toolInstances.Count; }
			} 
			#endregion //ToolInstancesCount

			#endregion //Properties

			#region ToolInstance class
#if DEBUG
			/// <summary>
			/// Helper class for maintaining a reference to a tool instance and the number of 
			/// times it has been referenced.
			/// </summary>
#endif
			private class ToolInstance
			{
				#region Member Variables

				private WeakReference tool;
				private int count;
                private bool existingTool;
				#endregion //Member Variables

				#region Constructor
				internal ToolInstance(ToolBase tool, bool existingTool)
				{
					this.tool = new WeakReference(tool);
					this.count++;
                    this.existingTool = existingTool;
				}
				#endregion //Constructor

				#region Properties
				internal int Count
				{
					get { return this.count; }
				}

				internal ToolBase Tool
				{
					get { return this.tool.Target as ToolBase; }
				}

                internal bool ExistingTool
                {
                    get { return this.existingTool; }
                }
				#endregion //Properties

				#region Methods
				internal void IncrementCount()
				{
					this.count++;
				}

				internal void DecrementCount()
				{
					Debug.Assert(this.count > 0, "Attempting to decrement the instance count below 0.");

					this.count--;
				}
				#endregion //Methods
			} 
			#endregion //ToolInstance class
		}
		#endregion //ToolsCollectionAdapterImpl nested class
	}
}
