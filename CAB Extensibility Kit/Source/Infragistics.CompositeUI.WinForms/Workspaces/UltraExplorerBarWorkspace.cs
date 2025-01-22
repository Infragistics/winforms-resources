using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.Utility;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using Infragistics.Win.UltraWinExplorerBar;
using System.Drawing;
using System.Collections.ObjectModel;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// A workspace that displays smart parts within an <see cref="UltraExplorerBar"/>
	/// </summary>
	[LocalizedDescription("Desc_UltraExplorerBarWorkspace")]
	public class UltraExplorerBarWorkspace : UltraExplorerBar, IComposableWorkspace<Control, UltraExplorerBarSmartPartInfo>
	{
		#region Member Variables

		private ControlWorkspaceComposer<UltraExplorerBarSmartPartInfo, UltraExplorerBarGroup> composer;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="UltraExplorerBarWorkspace"/>
		/// </summary>
		public UltraExplorerBarWorkspace()
		{
			this.composer = new ControlWorkspaceComposer<UltraExplorerBarSmartPartInfo, UltraExplorerBarGroup>(this, true);
		}
		#endregion //Constructor

		#region Properties

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
			UltraExplorerBarGroup group = this.composer[smartPart];

			group.Visible = true;
			group.EnsureGroupInView();
			group.Selected = true;
			group.Active = true;
			smartPart.Focus();
		}

		/// <summary>
		/// Applies the smart part info to the smart part within the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to which the smart part info should be applied.</param>
		/// <param name="smartPartInfo">The smart part info to apply</param>
		protected virtual void OnApplySmartPartInfo(Control smartPart, UltraExplorerBarSmartPartInfo smartPartInfo)
		{
			UltraExplorerBarGroup group = this.composer[smartPart];
			this.ApplySmartPartInfoHelper(group, smartPartInfo);
		}

		/// <summary>
		/// Closes/removes the smart part.
		/// </summary>
		protected virtual void OnClose(Control smartPart)
		{
			// find the group we contained the smartpart within
			UltraExplorerBarGroup group = this.composer[smartPart];

			// clean up the group<=>smartpart references
			this.composer.Remove(group, smartPart);

			// at design time, we won't remove the group 
			// if you remove the first control
			//
			if (this.DesignMode == false)
			{
				// reparent the control
				if (smartPart.Disposing == false && smartPart.IsDisposed == false)
					smartPart.Parent = null;

				// get rid of the explorerbar group
				this.Groups.Remove(group);
				group.Dispose();
			}
		}

		/// <summary>
		/// Hides the smart part.
		/// </summary>
		protected virtual void OnHide(Control smartPart)
		{
			UltraExplorerBarGroup group = this.composer[smartPart];

			if (null != group)
				group.Visible = false;
		}

		/// <summary>
		/// Shows the smart part in the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to show</param>
		/// <param name="smartPartInfo">The associated smart part info for the smart part being shown.</param>
		protected virtual void OnShow(Control smartPart, UltraExplorerBarSmartPartInfo smartPartInfo)
		{
			// create a tab that will represent the smart part
			UltraExplorerBarGroup group = new UltraExplorerBarGroup();
			group.Settings.Style = GroupStyle.ControlContainer;

			this.ApplySmartPartInfoHelper(group, smartPartInfo);

			// keep associations between the smart part
			// and group that represents it
			this.composer.Add(group, smartPart);

			// store the new group
			this.Groups.Add(group);

			// and then add the smart part control to the
			// tab page
			smartPart.Dock = DockStyle.Fill;
			group.Container.Controls.Add(smartPart);
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
		protected virtual UltraExplorerBarSmartPartInfo OnConvertFrom(ISmartPartInfo source)
		{
			UltraExplorerBarSmartPartInfo spi = SmartPartInfo.ConvertTo<UltraExplorerBarSmartPartInfo>(source);

			if (spi is ImageSmartPartInfo && source is ImageSmartPartInfo)
			{
				((ImageSmartPartInfo)spi).Image = ((ImageSmartPartInfo)source).Image;
			}

			return spi;
		}
		#endregion //IComposableWorkspace related methods

		#region ApplySmartPartInfoHelper
		private void ApplySmartPartInfoHelper(UltraExplorerBarGroup group, UltraExplorerBarSmartPartInfo smartPartInfo)
		{
			group.Text = smartPartInfo.Title;
			group.ToolTipText = smartPartInfo.Description;

			Image img = smartPartInfo.Image;

			if (img != null)
				group.Settings.AppearancesSmall.HeaderAppearance.Image = img;
			else if (group.Settings.HasAppearancesSmall && group.Settings.AppearancesSmall.HasHeaderAppearance)
				group.Settings.AppearancesSmall.HeaderAppearance.Image = null;
		}
		#endregion //ApplySmartPartInfoHelper

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

		#region IComposableWorkspace<Control,UltraExplorerBarSmartPartInfo>

		void IComposableWorkspace<Control, UltraExplorerBarSmartPartInfo>.OnActivate(Control smartPart)
		{
			this.OnActivate(smartPart);
		}

		void IComposableWorkspace<Control, UltraExplorerBarSmartPartInfo>.OnApplySmartPartInfo(Control smartPart, UltraExplorerBarSmartPartInfo smartPartInfo)
		{
			this.OnApplySmartPartInfo(smartPart, smartPartInfo);
		}

		void IComposableWorkspace<Control, UltraExplorerBarSmartPartInfo>.OnShow(Control smartPart, UltraExplorerBarSmartPartInfo smartPartInfo)
		{
			this.OnShow(smartPart, smartPartInfo);
		}

		void IComposableWorkspace<Control, UltraExplorerBarSmartPartInfo>.OnHide(Control smartPart)
		{
			this.OnHide(smartPart);
		}

		void IComposableWorkspace<Control, UltraExplorerBarSmartPartInfo>.OnClose(Control smartPart)
		{
			this.OnClose(smartPart);
		}

		void IComposableWorkspace<Control, UltraExplorerBarSmartPartInfo>.RaiseSmartPartActivated(WorkspaceEventArgs e)
		{
			this.OnSmartPartActivated(e);
		}

		void IComposableWorkspace<Control, UltraExplorerBarSmartPartInfo>.RaiseSmartPartClosing(WorkspaceCancelEventArgs e)
		{
			this.OnSmartPartClosing(e);
		}

		UltraExplorerBarSmartPartInfo IComposableWorkspace<Control, UltraExplorerBarSmartPartInfo>.ConvertFrom(ISmartPartInfo source)
		{
			return this.OnConvertFrom(source);
		}

		#endregion //IComposableWorkspace<Control,UltraExplorerBarSmartPartInfo>
	}
}
