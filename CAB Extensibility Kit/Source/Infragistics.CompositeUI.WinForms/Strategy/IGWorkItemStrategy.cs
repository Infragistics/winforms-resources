using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Infragistics.Win.UltraWinTabs;
using Infragistics.Win.UltraWinTabbedMdi;

namespace Infragistics.Practices.CompositeUI.WinForms
{
    /// <summary>
    /// Strategy that walks the control chain adding UltraDockWorkspace, 
	/// UltraToolbarsManagerWorkspace, and UltraMdiTabWorkspaces as well as the 
	/// controls associated with each to the <see cref="WorkItem"/>.
    /// </summary>
    public class IGWorkItemStrategy : BuilderStrategy
    {
		#region Base Class Overrides
		/// <summary>
		/// Walks the control hierarchy and adds the relevant elements to the <see cref="WorkItem"/>.
		/// </summary>
		public override object BuildUp(IBuilderContext context, Type typeToBuild, object existing, string idToBuild)
		{
			// handle ownedforms, ultradockmanager panes, ultratoolbarmgr forms
			if (existing is Control)
				this.ProcessAddControl(this.GetWorkItem(context.Locator), existing as Control);

			return base.BuildUp(context, typeToBuild, existing, idToBuild);
		}

		/// <summary>
		/// Walks the control hierarchy removing the relevant elements from the <see cref="WorkItem"/>.
		/// </summary>
		public override object TearDown(IBuilderContext context, object item)
		{
			// handle ownedforms, ultradockmanager panes, ultratoolbarmgr forms
			if (item is Control)
				this.ProcessRemoveControl(this.GetWorkItem(context.Locator), item as Control);

			return base.TearDown(context, item);
		} 
		#endregion //Base Class Overrides

		#region Methods

		#region AddItem
		private bool AddItem(WorkItem workItem, object item, string id)
		{
			if (this.ShouldAddItem(workItem, item))
			{
				if (string.IsNullOrEmpty(id) == false)
					workItem.Items.Add(item, id);
				else
					workItem.Items.Add(item);

				return true;
			}

			return false;
		} 
		#endregion //AddItem

		#region GetWorkItem
		private WorkItem GetWorkItem(IReadableLocator locator)
		{
			return locator.Get<WorkItem>(new DependencyResolutionLocatorKey(typeof(WorkItem), null));
		} 
		#endregion //GetWorkItem

		#region IsSmartPart
		private bool IsSmartPart(object item)
		{
			return (item.GetType().GetCustomAttributes(typeof(SmartPartAttribute), true).Length > 0);
		} 
		#endregion //IsSmartPart

		#region ProcessAddControl
		private void ProcessAddControl(WorkItem workItem, Control control)
		{
			// replace any place holders
			if (control is ISmartPartPlaceholder)
				this.ReplacePlaceHolder(workItem, control as ISmartPartPlaceholder);

			#region MdiTabWorkspace
			if (control is Form)
			{
				// if there is an mdi tab workspace, register it using its name
				UltraMdiTabWorkspace mdiManager = MdiParentManager.GetTabbedMdiManager( (Form)control ) as UltraMdiTabWorkspace;

				if (mdiManager != null)
					this.AddItem(workItem, mdiManager, mdiManager.WorkspaceName);
			} 
			#endregion //MdiTabWorkspace

			#region ToolbarsManagerWorkspace
			UltraToolbarsManagerWorkspace toolbarMgr = UltraToolbarsManager.FromContainer(control) as UltraToolbarsManagerWorkspace;

			if (toolbarMgr != null)
			{
				// be sure to add it as workspace if it is one
				this.AddItem(workItem, toolbarMgr, toolbarMgr.WorkspaceName);
			} 
			#endregion //ToolbarsManagerWorkspace

			#region UltraDockWorkspace
			if (control is AutoHideControl)
			{
				// if there is an mdi tab workspace, register it using its name
				UltraDockWorkspace dockManager = ((AutoHideControl)control).Owner as UltraDockWorkspace;

				if (dockManager != null)
				{
					this.AddItem(workItem, dockManager, dockManager.WorkspaceName);

					foreach (DockableControlPane pane in dockManager.ControlPanes)
					{
						if (null != pane.Control)
							this.ProcessAddControl(workItem, pane.Control);
					}
				}
			} 
			#endregion //UltraDockWorkspace

			// account for other info - placeholder, smart part, etc.
			if (this.AddItem(workItem, control, control.Name) == false)
			{
				// iterate the children
				foreach (Control child in control.Controls)
					ProcessAddControl(workItem, child);
			}
		} 
		#endregion //ProcessAddControl

		#region ProcessRemoveControl
		private void ProcessRemoveControl(WorkItem workItem, Control control)
		{
			#region MdiTabWorkspace
			if (control is Form)
			{
				UltraMdiTabWorkspace mdiManager = MdiParentManager.GetTabbedMdiManager( (Form)control ) as UltraMdiTabWorkspace;

				if (mdiManager != null)
					this.RemoveItem(workItem, mdiManager);
			}
			#endregion //MdiTabWorkspace

			#region ToolbarsManagerWorkspace

			UltraToolbarsManagerWorkspace toolbarMgr = UltraToolbarsManager.FromContainer(control) as UltraToolbarsManagerWorkspace;

			if (toolbarMgr != null)
				this.RemoveItem(workItem, toolbarMgr);

			#endregion //ToolbarsManagerWorkspace

			#region UltraDockWorkspace
			if (control is AutoHideControl)
			{
				// if there is an mdi tab workspace, register it using its name
				UltraDockWorkspace dockManager = ((AutoHideControl)control).Owner as UltraDockWorkspace;

				if (dockManager != null)
				{
					this.RemoveItem(workItem, dockManager);

					foreach (DockableControlPane pane in dockManager.ControlPanes)
					{
						if (null != pane.Control)
							this.RemoveItem(workItem, pane.Control);
					}
				}
			}
			#endregion //UltraDockWorkspace
		} 
		#endregion //ProcessRemoveControl

		#region RemoveItem
		private void RemoveItem(WorkItem workItem, object item)
		{
			workItem.Items.Remove(item);
		} 
		#endregion //RemoveItem

		#region ReplacePlaceHolder
		private void ReplacePlaceHolder(WorkItem workItem, ISmartPartPlaceholder placeholder)
		{
			Control replacement = workItem.Items.Get<Control>(placeholder.SmartPartName);

			if (replacement != null)
				placeholder.SmartPart = replacement;
		} 
		#endregion //ReplacePlaceHolder

		#region ShouldAddItem
		private bool ShouldAddItem(WorkItem workItem, object item)
		{
			if (item is IWorkspace || item is ISmartPartPlaceholder || this.IsSmartPart(item))
			{
				return workItem.Items.ContainsObject(item) == false;
			}

			return false;
		} 
		#endregion //ShouldAddItem

		#endregion //Methods    
	}
}
