using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Infragistics.Win.UltraWinTabbedMdi;
using System.Windows.Forms;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.CodeDom;
using System.Drawing;
using Microsoft.Practices.CompositeUI.Utility;
using System.Collections.ObjectModel;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// A workspace that displays smart parts within an <see cref="UltraTabbedMdiManager"/>
	/// </summary>
	[LocalizedDescription("Desc_UltraMdiTabWorkspace")]
	public class UltraMdiTabWorkspace : UltraTabbedMdiManager, IComposableWorkspace<Control, UltraMdiTabSmartPartInfo>
	{
		#region Member Variables

		private ControlWorkspaceComposer<UltraMdiTabSmartPartInfo, MdiTab> composer;

		private string workspaceName;
		private MdiTab tabForcingClosed;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="UltraMdiTabWorkspace"/>
		/// </summary>
		public UltraMdiTabWorkspace() : this(null)
		{
		}

		/// <summary>
		/// Initializes a new <see cref="UltraMdiTabWorkspace"/>
		/// </summary>
		public UltraMdiTabWorkspace(IContainer container)
			: base(container)
		{
			this.composer = new ControlWorkspaceComposer<UltraMdiTabSmartPartInfo, MdiTab>(this, false);
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
			MdiTab tab = this.GetTab(smartPart);

			// AS 7/13/06 BR13877
			// When a hidden tab is requesting to be activated, we need to 
			// show the associated form.
			//
			tab.Show();

			tab.Activate();
		}

		/// <summary>
		/// Applies the smart part info to the smart part within the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to which the smart part info should be applied.</param>
		/// <param name="smartPartInfo">The smart part info to apply</param>
		protected virtual void OnApplySmartPartInfo(Control smartPart, UltraMdiTabSmartPartInfo smartPartInfo)
		{
			MdiTab tab = this.GetTab(smartPart);
			this.ApplySmartPartInfoHelper(tab, smartPartInfo);
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
			MdiTab tab = this.GetTab(smartPart);

			if (null != tab)
				tab.Form.Hide();
		}

		/// <summary>
		/// Shows the smart part in the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to show</param>
		/// <param name="smartPartInfo">The associated smart part info for the smart part being shown.</param>
		protected virtual void OnShow(Control smartPart, UltraMdiTabSmartPartInfo smartPartInfo)
		{
			// create and show the tab
			MdiTab tab = this.CreateTab(smartPart, smartPartInfo);
			tab.Show();
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
		protected virtual UltraMdiTabSmartPartInfo OnConvertFrom(ISmartPartInfo source)
		{
			UltraMdiTabSmartPartInfo spi = SmartPartInfo.ConvertTo<UltraMdiTabSmartPartInfo>(source);

			if (spi is ImageSmartPartInfo && source is ImageSmartPartInfo)
			{
				((ImageSmartPartInfo)spi).Image = ((ImageSmartPartInfo)source).Image;
			}

			return spi;
		}
		#endregion //IComposableWorkspace related methods

		#region ApplySmartPartInfoHelper
		private void ApplySmartPartInfoHelper(MdiTab tab, UltraMdiTabSmartPartInfo smartPartInfo)
		{
			tab.Text = smartPartInfo.Title;
			tab.ToolTip = smartPartInfo.Description;

			//~ AS 7/21/06 BR14381
			if (tab.Form != null)
				tab.Form.Text = smartPartInfo.Title;

			Image img = smartPartInfo.Image;

			if (img != null)
				tab.Settings.TabAppearance.Image = img;
			else if (tab.HasSettings && tab.Settings.HasTabAppearance)
				tab.Settings.TabAppearance.Image = null;
		}
		#endregion //ApplySmartPartInfoHelper

		#region CreateTab
		private MdiTab CreateTab(Control smartPart, UltraMdiTabSmartPartInfo smartPartInfo)
		{
			if (this.MdiParent == null)
				throw new InvalidOperationException(Properties.Resources.MdiParentNotSet);

			// create an mdi form
			Form form = new Form();
			form.MdiParent = this.MdiParent;
			string groupKey = smartPartInfo.PreferredGroup;

			// get the tab associated with that form
			MdiTab tab = this.TabFromForm(form);

			this.composer.Add(tab, smartPart);

			// add the control to the form and make it fill the mdi child
			smartPart.Dock = DockStyle.Fill;
			form.Controls.Add(smartPart);

			this.ApplySmartPartInfoHelper(tab, smartPartInfo);

			if (groupKey != null)
			{
				// if there's a group key, we'll use a helper class to put
				// the tab into the specified group
				using (TabDisplayingHelper tabHelper = new TabDisplayingHelper(this, groupKey))
					tab.Show();
			}
			else
				tab.Show();

			return tab;
		}
		#endregion //CreateTab

		#region ForceCloseTab

		private void ForceCloseTab(MdiTab tab)
		{
			MdiTab previousForceCloseTab = this.tabForcingClosed;

			try
			{
				this.tabForcingClosed = tab;

				tab.Form.Close();
			}
			finally
			{
				this.tabForcingClosed = previousForceCloseTab;
			}
		}

		#endregion //ForceCloseTab

		#region GetSmartPart
		private Control GetSmartPart(MdiTab tab)
		{
			return this.composer[tab];
		}
		#endregion //GetSmartPart

		#region GetTab
		private MdiTab GetTab(Control smartPart)
		{
			return this.composer[smartPart];
		}
		#endregion //GetTab

		#region RemoveSmartPart
		private void RemoveSmartPart(Control smartPartControl)
		{
			// find the tab we contained the smartpart within
			MdiTab tab = this.GetTab(smartPartControl);

			// clean up the group<=>smartpart references
			this.composer.Remove(tab, smartPartControl);

			// TODO remove the control from the form

			// get rid of the tab
			if (tab.Form != null)
			{
				// don't allow it to be cancelled
				this.ForceCloseTab(tab);
				tab.Dispose();
			}
		}
		#endregion //RemoveSmartPart

		#endregion //Methods

		#region Base class overrides

		#region OnTabClosed
		protected override void OnTabClosed(MdiTabEventArgs e)
		{
			base.OnTabClosed(e);

			// TODO handle - this could happen because they closed us or the programmer did

			// when the tab/form is closed then remove our 
			// references to it. if the tab was just hidden
			// then we don't want to fire the closed event
			if (e.Tab.Form == null || e.Tab.Form.IsDisposed)
			{
				Control ctrl = this.GetSmartPart(e.Tab);

				if (null != ctrl)
					this.RemoveSmartPart(ctrl);
			}
		}
		#endregion //OnTabClosed

		#region OnTabClosing
		protected override void OnTabClosing(CancelableMdiTabEventArgs e)
		{
			base.OnTabClosing(e);

			// just in case the user of the mdi tab workspace
			// wants the tab to be opened, cancel it if the workspace
			// is being explicitly told to remove the smart part
			if (e.Tab == this.tabForcingClosed)
				e.Cancel = false;

			if (!e.Cancel && this.composer.ContainsItem(e.Tab))
			{
				// TODO call off their close method?

				Control smartPart = this.GetSmartPart(e.Tab);

				if (null != smartPart)
				{
					WorkspaceCancelEventArgs args = new WorkspaceCancelEventArgs(smartPart);

					this.OnSmartPartClosing(args);

					if (args.Cancel)
						e.Cancel = true;
				}
			}
		}
		#endregion //OnTabClosing

		#region OnTabActivated
		protected override void OnTabActivated(MdiTabEventArgs e)
		{
			base.OnTabActivated(e);

			Control smartPart = this.GetSmartPart(e.Tab);

			if (null != smartPart)
				this.Activate(smartPart);
		}
		#endregion //OnTabActivated

		#endregion //Base class overrides

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

		#region IComposableWorkspace<Control,UltraMdiTabSmartPartInfo>

		void IComposableWorkspace<Control, UltraMdiTabSmartPartInfo>.OnActivate(Control smartPart)
		{
			this.OnActivate(smartPart);
		}

		void IComposableWorkspace<Control, UltraMdiTabSmartPartInfo>.OnApplySmartPartInfo(Control smartPart, UltraMdiTabSmartPartInfo smartPartInfo)
		{
			this.OnApplySmartPartInfo(smartPart, smartPartInfo);
		}

		void IComposableWorkspace<Control, UltraMdiTabSmartPartInfo>.OnShow(Control smartPart, UltraMdiTabSmartPartInfo smartPartInfo)
		{
			this.OnShow(smartPart, smartPartInfo);
		}

		void IComposableWorkspace<Control, UltraMdiTabSmartPartInfo>.OnHide(Control smartPart)
		{
			this.OnHide(smartPart);
		}

		void IComposableWorkspace<Control, UltraMdiTabSmartPartInfo>.OnClose(Control smartPart)
		{
			this.OnClose(smartPart);
		}

		void IComposableWorkspace<Control, UltraMdiTabSmartPartInfo>.RaiseSmartPartActivated(WorkspaceEventArgs e)
		{
			this.OnSmartPartActivated(e);
		}

		void IComposableWorkspace<Control, UltraMdiTabSmartPartInfo>.RaiseSmartPartClosing(WorkspaceCancelEventArgs e)
		{
			this.OnSmartPartClosing(e);
		}

		UltraMdiTabSmartPartInfo IComposableWorkspace<Control, UltraMdiTabSmartPartInfo>.ConvertFrom(ISmartPartInfo source)
		{
			return this.OnConvertFrom(source);
		}

		#endregion //IComposableWorkspace<Control,UltraMdiTabSmartPartInfo>

		#region TabDisplayingHelper nested class
#if DEBUG
		/// <summary>
		/// Helper class that is used to ensure the tab is added to the correct tab group.
		/// </summary>
#endif
		private class TabDisplayingHelper : IDisposable
		{
			#region Member Variables

			private string groupKey;
			private UltraTabbedMdiManager mdiManager;

			#endregion //Member Variables

			#region Constructor
			public TabDisplayingHelper(UltraTabbedMdiManager mdiManager, string groupKey)
			{
				this.mdiManager = mdiManager;
				this.groupKey = groupKey;

				mdiManager.TabDisplaying += new MdiTabEventHandler(this.OnTabDisplaying);
			}
			#endregion //Constructor

			#region Methods
			void OnTabDisplaying(object sender, MdiTabEventArgs e)
			{
				// unhook the event
				this.mdiManager.TabDisplaying -= new MdiTabEventHandler(this.OnTabDisplaying);

				MdiTabGroup tabGroup = this.GetTabGroup(this.mdiManager.TabGroups);

				// if there is no tab group with that name and this tab is in a 
				// new tabgroup, name the tabgroup with the specified key
				if (tabGroup == null && e.Tab.TabGroup.Tabs.Count == 1)
				{
					e.Tab.TabGroup.Key = this.groupKey;
				}
				else if (tabGroup != null)
				{
					// if a tabgroup was specified, move it to that group
					e.Tab.MoveToGroup(tabGroup);
				}
			}

			private MdiTabGroup GetTabGroup(MdiTabGroupsCollection tabGroups)
			{
				foreach (MdiTabGroup tabGroup in tabGroups)
				{
					// return a tab containing tabgroup that has the matching key
					if (tabGroup.Key == this.groupKey && tabGroup.HasTabs)
						return tabGroup;

					// if the tabgroup has child tabgroups, check them
					if (tabGroup.HasTabGroups)
					{
						MdiTabGroup childGroup = this.GetTabGroup(tabGroup.TabGroups);

						if (childGroup != null)
							continue;
					}
				}

				return null;
			}

			public void Dispose()
			{
				this.mdiManager.TabDisplaying -= new MdiTabEventHandler(this.OnTabDisplaying);
			}

			#endregion //Methods
		}
		#endregion //TabDisplayingHelper nested class
	}
}
