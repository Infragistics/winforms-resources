using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.CompositeUI.WinForms;
using System.Drawing;
using System.Collections.ObjectModel;
using Infragistics.Win;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// A workspace that displays smart parts within an <see cref="UltraToolbarsManager"/>
	/// </summary>
	[Description("Desc_UltraToolbarsManagerWorkspace")]
	public class UltraToolbarsManagerWorkspace : UltraToolbarsManager, IComposableWorkspace<Control, UltraToolbarsSmartPartInfo>
	{
		#region Member Variables

		private ControlWorkspaceComposer<UltraToolbarsSmartPartInfo, TaskPaneTool> composer;

		private string workspaceName;

		#endregion //Member Variables

		#region Constructor

		/// <summary>
		/// Initializes a new <see cref="UltraToolbarsManagerWorkspace"/>
		/// </summary>
		public UltraToolbarsManagerWorkspace() : this(null)
		{
		}

		/// <summary>
		/// Initializes a new <see cref="UltraToolbarsManagerWorkspace"/>
		/// </summary>
		public UltraToolbarsManagerWorkspace(IContainer container)
			: base(container)
		{
			this.composer = new ControlWorkspaceComposer<UltraToolbarsSmartPartInfo, TaskPaneTool>(this, true);
		}

		#endregion //Constructor

		#region Properties

		/// <summary>
		/// Name of the workspace, which is used to register it with the 
		/// <see cref="IWorkspaceCatalogService"/>
		/// </summary>
		[DefaultValue(null)]
		public string WorkspaceName
		{
			get { return this.workspaceName; }
			set { this.workspaceName = value; }
		}

		#region WorkItem
		/// <summary>
		/// Dependency injection setter property to get the <see cref="WorkItem"/> where the object is contained.
		/// </summary>
		[ServiceDependency]
		public WorkItem WorkItem
		{
			set { this.composer.WorkItem = value; }
		}
		#endregion //WorkItem

		#endregion //Properties

		#region Methods

		#region IComposableWorkspace related methods
		/// <summary>
		/// Activates the smart part within the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to activate</param>
		protected virtual void OnActivate(Control smartPart)
		{
			TaskPaneTool taskPane = this.GetTaskPane(smartPart);

			// make sure its visible
			taskPane.SharedProps.Visible = true;

			UltraTaskPaneToolbar taskPaneToolbar = taskPane.OwningToolbar as UltraTaskPaneToolbar;

			// make sure its the selected tool in the owning task pane
			if (taskPaneToolbar != null)
			{
				taskPaneToolbar.SelectedTaskPaneTool = taskPane;
				taskPaneToolbar.Visible = true;
			}

			// assuming the control is visible, give it the input focus
			if (taskPane.Control.Visible)
				taskPane.Control.Focus();
		}

		/// <summary>
		/// Applies the smart part info to the smart part within the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to which the smart part info should be applied.</param>
		/// <param name="smartPartInfo">The smart part info to apply</param>
		protected virtual void OnApplySmartPartInfo(Control smartPart, UltraToolbarsSmartPartInfo smartPartInfo)
		{
			TaskPaneTool tool = this.GetTaskPane(smartPart);
			this.ApplySmartPartInfoHelper(tool, smartPartInfo);
		}

		/// <summary>
		/// Closes/removes the smart part.
		/// </summary>
		protected virtual void OnClose(Control smartPart)
		{
			this.RemoveSmartPart(smartPart);
		}

		/// <summary>
		/// Hides the smart part.
		/// </summary>
		protected virtual void OnHide(Control smartPart)
		{
			TaskPaneTool tool = this.GetTaskPane(smartPart);

			if (null != tool)
			{
				tool.SharedProps.Visible = false;

				// get and hide the owning taskpane toolbar if necessary
				this.HideToolbarWithNoVisibleTools(GetOwningToolbar(tool));
			}
		}

		/// <summary>
		/// Shows the smart part in the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to show</param>
		/// <param name="smartPartInfo">The associated smart part info for the smart part being shown.</param>
		protected virtual void OnShow(Control smartPart, UltraToolbarsSmartPartInfo smartPartInfo)
		{
			TaskPaneTool taskPane = this.CreateTaskPane(smartPart, smartPartInfo);
			taskPane.SharedProps.Visible = true;
		}

		#region Event related
		/// <summary>
		/// Raises the <see cref="SmartPartActivated"/> event.
		/// </summary>
		protected virtual void OnSmartPartActivated(WorkspaceEventArgs e)
		{
			if (this.SmartPartActivated != null)
				this.SmartPartActivated(this, e);
		}

		/// <summary>
		/// Raises the <see cref="SmartPartClosing"/> event.
		/// </summary>
		protected virtual void OnSmartPartClosing(WorkspaceCancelEventArgs e)
		{
			if (this.SmartPartClosing != null)
				this.SmartPartClosing(this, e);
		}
		#endregion //Event related

		/// <summary>
		/// Converts a smart part information to a compatible one for the workspace.
		/// </summary>
		protected virtual UltraToolbarsSmartPartInfo OnConvertFrom(ISmartPartInfo source)
		{
			UltraToolbarsSmartPartInfo spi = SmartPartInfo.ConvertTo<UltraToolbarsSmartPartInfo>(source);

			if (spi is ImageSmartPartInfo && source is ImageSmartPartInfo)
			{
				((ImageSmartPartInfo)spi).Image = ((ImageSmartPartInfo)source).Image;
			}

			return spi;
		}
		#endregion //IComposableWorkspace related methods

		#region ApplySmartPartInfoHelper
		private void ApplySmartPartInfoHelper(TaskPaneTool tool, UltraToolbarsSmartPartInfo smartPartInfo)
		{
			tool.SharedProps.Caption = smartPartInfo.Title;
			tool.SharedProps.ToolTipText = smartPartInfo.Description;

			tool.HeaderCaption = smartPartInfo.HeaderCaption;
			tool.ResizeMode = smartPartInfo.ResizeMode;

			Image img = smartPartInfo.Image;

			if (img != null)
				tool.SharedProps.AppearancesSmall.Appearance.Image = img;
			else if (tool.SharedProps.HasAppearancesSmall && tool.SharedProps.AppearancesSmall.HasAppearance)
				tool.SharedProps.AppearancesSmall.Appearance.Image = null;
		}
		#endregion //ApplySmartPartInfoHelper

		#region CreateTaskPane
		private TaskPaneTool CreateTaskPane(object smartPart, UltraToolbarsSmartPartInfo smartPartInfo)
		{
			// get the control that we will be siting
			Control ctrl = WorkspaceUtilities.GetSmartPartControl(smartPart);

			TaskPaneTool taskPane = null;
			UltraTaskPaneToolbar toolbar = null;
			DockedPosition defaultDockedPosition = smartPartInfo.PreferredDockedPosition;
			string toolbarKey = smartPartInfo.PreferredTaskPane;

			// create the task pane tool and set it up
			taskPane = new TaskPaneTool(Guid.NewGuid().ToString());
			taskPane.Control = ctrl;

			// add it to the root tools collection
			this.Tools.Add(taskPane);

			this.composer.Add(taskPane, ctrl);

			// initialize its settings
			this.ApplySmartPartInfoHelper(taskPane, smartPartInfo);

			// if a key was specified...
			if (toolbarKey != null && this.Toolbars.Exists(toolbarKey))
			{
				// as long as its an task pane toolbar key, use it
				if (this.Toolbars[toolbarKey] is UltraTaskPaneToolbar)
					toolbar = this.Toolbars[toolbarKey] as UltraTaskPaneToolbar;
				else // otherwise use a default key
					toolbarKey = null;
			}

			if (toolbar == null)
			{
				// if one wasn't specified use a guid to ensure uniqueness
				if (toolbarKey == null)
					toolbarKey = Guid.NewGuid().ToString();

				// create a taskpane toolbar and add it to the controls collection
				toolbar = new UltraTaskPaneToolbar(toolbarKey);
				toolbar.DockedPosition = defaultDockedPosition;

				if (smartPartInfo.PreferredExtent != UltraToolbarsSmartPartInfo.DefaultExtent)
					toolbar.DockedContentExtent = smartPartInfo.PreferredExtent;

				toolbar.ShowHomeButton = smartPartInfo.PreferredShowHomeButton;
				toolbar.NavigationButtonStyle = smartPartInfo.PreferredNavigationStyle;

				this.Toolbars.Add(toolbar);
			}

			toolbar.Tools.AddTool(taskPane.Key);

			return taskPane;
		}
		#endregion //CreateTaskPane

		#region GetOwningToolbar
		private static UltraTaskPaneToolbar GetOwningToolbar(TaskPaneTool tool)
		{
			foreach (ToolBase instance in tool.SharedProps.ToolInstances)
			{
				if (instance.OwnerIsToolbar)
					return instance.OwningToolbar as UltraTaskPaneToolbar;
			}

			return tool.OwningToolbar as UltraTaskPaneToolbar;
		}

		#endregion //GetOwningToolbar

		#region GetSmartPart
		private Control GetSmartPart(TaskPaneTool taskPane)
		{
			return this.composer[taskPane];
		}
		#endregion //GetSmartPart

		#region GetTaskPane
		private TaskPaneTool GetTaskPane(Control smartPart)
		{
			return this.composer[smartPart];
		}
		#endregion //GetTaskPane

		#region HideToolbarWithNoVisibleTools
		private void HideToolbarWithNoVisibleTools(UltraTaskPaneToolbar toolbar)
		{
			if (null != toolbar)
			{
				bool hasVisibleTools = false;

				// see if the toolbar has visible tools
				foreach (ToolBase tool in toolbar.Tools)
				{
					if (tool.VisibleResolved)
					{
						hasVisibleTools = true;
						break;
					}
				}

				if (hasVisibleTools == false)
					toolbar.Visible = false;
			}
		} 
		#endregion //HideToolbarWithNoVisibleTools

		#region RemoveSmartPart
		private void RemoveSmartPart(Control smartPartControl)
		{
			// get the task pane tool
			TaskPaneTool taskPane = this.GetTaskPane(smartPartControl);
			UltraTaskPaneToolbar toolbar = GetOwningToolbar(taskPane);

			// at design time, we won't remove the tool 
			// if you remove the control
			//
			if (this.DesignMode == false)
			{
				// remove the root tool so all the instances are removed
				this.Tools.Remove(this.Tools[taskPane.Key]);
			}

			// remove the smart parts
			this.composer.Remove(taskPane, smartPartControl);

			// at design time, don't mess with the toolbar visibility
			if (this.DesignMode == false)
			{
				// get and hide the owning taskpane toolbar if necessary
				this.HideToolbarWithNoVisibleTools(toolbar);
			}

			if (this.MdiParentManager != null)
				this.RefreshMerge();
		}
		#endregion //RemoveSmartPart

		#endregion //Methods

		#region IWorkspace

		#region Properties
		/// <summary>
		/// Returns the currently active smart part within the workspace.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object ActiveSmartPart
		{
			get { return this.composer.ActiveSmartPart; }
		}

		/// <summary>
		/// Returns a read-only collection of the smart parts associated with the workspace.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ReadOnlyCollection<object> SmartParts
		{
			get { return this.composer.SmartParts; }
		}
		#endregion //Properties

		#region Methods
		/// <summary>
		/// Activates the specified smart part within the workspace.
		/// </summary>
		/// <param name="smartPart">Smart part to activate</param>
		public void Activate(object smartPart)
		{
			this.composer.ActivateHelper(smartPart);
		}

		/// <summary>
		/// Applies the specified smart part info to the specified smart part within the workspace.
		/// </summary>
		/// <param name="smartPart">Smart part to update</param>
		/// <param name="smartPartInfo">Smart part info to apply to the <paramref name="smartPart"/></param>
		public void ApplySmartPartInfo(object smartPart, ISmartPartInfo smartPartInfo)
		{
			this.composer.ApplySmartPartInfo(smartPart, smartPartInfo);
		}

		/// <summary>
		/// Closes the specified smart part and removes it from the workspace.
		/// </summary>
		/// <param name="smartPart">Smart part to close and remove.</param>
		public void Close(object smartPart)
		{
			this.composer.Close(smartPart);
		}

		/// <summary>
		/// Hides the specified smart part.
		/// </summary>
		/// <param name="smartPart">Smart part within the workspace that should be hidden.</param>
		public void Hide(object smartPart)
		{
			this.composer.Hide(smartPart);
		}

		/// <summary>
		/// Shows the smart part within the workspace using the specified smart part info.
		/// </summary>
		/// <param name="smartPart">Smart part that should be displayed</param>
		/// <param name="smartPartInfo">Smart part info to applied to the smart part</param>
		public void Show(object smartPart, ISmartPartInfo smartPartInfo)
		{
			this.composer.Show(smartPart, smartPartInfo);
		}

		/// <summary>
		/// Shows the specified smart part within the workspace.
		/// </summary>
		/// <param name="smartPart">Smart part to show.</param>
		public void Show(object smartPart)
		{
			this.composer.Show(smartPart);
		}
		#endregion //Methods

		#region Events

		/// <summary>
		/// Invoked when a smart part is closing.
		/// </summary>
		[LocalizedDescription("Desc_Workspace_E_SmartPartClosing")]
		[LocalizedCategory("Category_CompositeUI")]
		public event EventHandler<WorkspaceCancelEventArgs> SmartPartClosing;

		/// <summary>
		/// Invoked when a smart part is activated.
		/// </summary>
		[LocalizedDescription("Desc_Workspace_E_SmartPartActivated")]
		[LocalizedCategory("Category_CompositeUI")]
		public event EventHandler<WorkspaceEventArgs> SmartPartActivated;

		#endregion //Events

		#endregion //IWorkspace

		#region IComposableWorkspace<Control,UltraToolbarsSmartPartInfo>

		void IComposableWorkspace<Control, UltraToolbarsSmartPartInfo>.OnActivate(Control smartPart)
		{
			this.OnActivate(smartPart);
		}

		void IComposableWorkspace<Control, UltraToolbarsSmartPartInfo>.OnApplySmartPartInfo(Control smartPart, UltraToolbarsSmartPartInfo smartPartInfo)
		{
			this.OnApplySmartPartInfo(smartPart, smartPartInfo);
		}

		void IComposableWorkspace<Control, UltraToolbarsSmartPartInfo>.OnShow(Control smartPart, UltraToolbarsSmartPartInfo smartPartInfo)
		{
			this.OnShow(smartPart, smartPartInfo);
		}

		void IComposableWorkspace<Control, UltraToolbarsSmartPartInfo>.OnHide(Control smartPart)
		{
			this.OnHide(smartPart);
		}

		void IComposableWorkspace<Control, UltraToolbarsSmartPartInfo>.OnClose(Control smartPart)
		{
			this.OnClose(smartPart);
		}

		void IComposableWorkspace<Control, UltraToolbarsSmartPartInfo>.RaiseSmartPartActivated(WorkspaceEventArgs e)
		{
			this.OnSmartPartActivated(e);
		}

		void IComposableWorkspace<Control, UltraToolbarsSmartPartInfo>.RaiseSmartPartClosing(WorkspaceCancelEventArgs e)
		{
			this.OnSmartPartClosing(e);
		}

		UltraToolbarsSmartPartInfo IComposableWorkspace<Control, UltraToolbarsSmartPartInfo>.ConvertFrom(ISmartPartInfo source)
		{
			return this.OnConvertFrom(source);
		}

		#endregion //IComposableWorkspace<Control,UltraToolbarsSmartPartInfo>
	}
}
