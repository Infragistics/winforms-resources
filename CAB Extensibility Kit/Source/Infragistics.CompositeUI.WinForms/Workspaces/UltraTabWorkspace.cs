using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinTabControl;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.Utility;
using System.Drawing;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// A workspace that displays smart parts within an <see cref="UltraTabControl"/>
	/// </summary>
	[Description("Desc_UltraTabWorkspace")]
	public class UltraTabWorkspace : UltraTabControl, IComposableWorkspace<Control, UltraTabSmartPartInfo>
	{
		#region Member Variables

		private ControlWorkspaceComposer<UltraTabSmartPartInfo, UltraTab> composer;

		// antirecursion flag
		private bool verifyingSmartParts = false;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="UltraTabWorkspace"/>
		/// </summary>
		public UltraTabWorkspace()
		{
			this.composer = new ControlWorkspaceComposer<UltraTabSmartPartInfo, UltraTab>(this, false);
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
			UltraTab tab = this.composer[smartPart];

			tab.Visible = true;
			tab.EnsureTabInView();
			tab.Selected = true;

			// only activate the tab if it was able to be selected
			if (tab.Selected)
			{
				tab.Active = true;

				smartPart.Focus(); // AS 6/6/07 BR23528
			}
		}

		/// <summary>
		/// Applies the smart part info to the smart part within the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to which the smart part info should be applied.</param>
		/// <param name="smartPartInfo">The smart part info to apply</param>
		protected virtual void OnApplySmartPartInfo(Control smartPart, UltraTabSmartPartInfo smartPartInfo)
		{
			UltraTab tab = this.composer[smartPart];

			if (null != tab)
			{
				this.ApplySmartPartInfoHelper(tab, smartPartInfo);

				if (smartPartInfo.ActivateTab)
					this.Activate(smartPart);
			}
		}

		/// <summary>
		/// Closes/removes the smart part.
		/// </summary>
		protected virtual void OnClose(Control smartPart)
		{
			// find the tab we contained the smartpart within
			UltraTab tab = this.composer[smartPart];

			// clean up the group<=>smartpart references
			this.composer.Remove(tab, smartPart);

			// at design time, we won't remove the tab 
			// if you remove the first control
			//
			if (this.DesignMode == false)
			{
				// reparent the control if its not been disposed
				if (smartPart.Disposing == false && smartPart.IsDisposed == false)
					smartPart.Parent = null;

				// get rid of the tab
				this.Tabs.Remove(tab);
				tab.Dispose();
			}
		}

		/// <summary>
		/// Hides the smart part.
		/// </summary>
		protected virtual void OnHide(Control smartPart)
		{
			UltraTab tab = this.composer[smartPart];

			if (null != tab)
				tab.Visible = false;
		}

		/// <summary>
		/// Shows the smart part in the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to show</param>
		/// <param name="smartPartInfo">The associated smart part info for the smart part being shown.</param>
		protected virtual void OnShow(Control smartPart, UltraTabSmartPartInfo smartPartInfo)
		{
			UltraTab tab = null;

			// if we're verifying the smart parts then we may already have a tab created
			if (this.verifyingSmartParts)
			{
				foreach (UltraTabPageControl tabPage in this.Controls)
				{
					if (tabPage.Contains(smartPart))
					{
						tab = tabPage.Tab;
						break;
					}
				}
			}

			// create a tab that will represent the smart part
			if (tab == null)
				tab = new UltraTab();

			// keep associations between the smart part
			// and tab that represents it
			this.composer.Add(tab, smartPart);

			if (tab.TabControl == null)
			{
				this.ApplySmartPartInfoHelper(tab, smartPartInfo);

				// and then add the smart part control to the
				// tab page
				smartPart.Dock = DockStyle.Fill;

				// store the new tab
				this.Tabs.Add(tab);

				tab.TabPage.Controls.Add(smartPart);
			}

			if (smartPartInfo.ActivateTab)
				this.Activate(smartPart);
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
		protected virtual UltraTabSmartPartInfo OnConvertFrom(ISmartPartInfo source)
		{
			UltraTabSmartPartInfo spi = SmartPartInfo.ConvertTo<UltraTabSmartPartInfo>(source);

			if (spi is ImageSmartPartInfo && source is ImageSmartPartInfo)
			{
				((ImageSmartPartInfo)spi).Image = ((ImageSmartPartInfo)source).Image;
			}

			return spi;
		}
		#endregion //IComposableWorkspace related methods

		#region ApplySmartPartInfoHelper
		private void ApplySmartPartInfoHelper(UltraTab tab, UltraTabSmartPartInfo smartPartInfo)
		{
			tab.Text = smartPartInfo.Title;
			tab.ToolTipText = smartPartInfo.Description;

			Image img = smartPartInfo.Image;

			if (img != null)
				tab.Appearance.Image = img;
			else if (tab.HasAppearance)
				tab.Appearance.Image = null;
		}
		#endregion //ApplySmartPartInfoHelper

		#region VerifySmartParts
		private void VerifySmartParts()
		{
			if (this.verifyingSmartParts)
				return;

			try
			{
				this.verifyingSmartParts = true;

				foreach (UltraTab tab in this.Tabs)
				{
					Debug.Assert(tab.TabPage != null, "The tab page has not yet been associated with the tab pages.");

					if (tab.TabPage == null || tab.TabPage.HasChildren == false)
						continue;

					Control smartPart = tab.TabPage.Controls[0];

					// if we haven't created an association between
					// the smart part and tabs
					if (this.composer.ContainsItem(tab) == false)
					{
						UltraTabSmartPartInfo spi = new UltraTabSmartPartInfo();
						spi.ActivateTab = false;

						this.Show(smartPart, spi);
					}
				}
			}
			finally
			{
				this.verifyingSmartParts = false;
			}

			this.VerifyActiveSmartPart();
		} 
		#endregion //VerifySmartParts

		#region VerifyActiveSmartPart
		private void VerifyActiveSmartPart()
		{
			this.composer.VerifyActiveItem(this.SelectedTab);
		} 
		#endregion //VerifyActiveSmartPart

		#endregion //Methods

		#region Base class overrides

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			this.VerifySmartParts();
		}

		protected override void OnSelectedTabChanged(SelectedTabChangedEventArgs e)
		{
			base.OnSelectedTabChanged(e);

			this.composer.VerifyActiveItem(e.Tab);
		}

		protected override void OnPropertyChanged(Infragistics.Win.PropertyChangedEventArgs e)
		{
			// verify that the tabs collection is in sync with the smart parts
			this.VerifySmartParts();

			base.OnPropertyChanged(e);
		}
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

		#region IComposableWorkspace<Control,UltraTabSmartPartInfo>

		void IComposableWorkspace<Control, UltraTabSmartPartInfo>.OnActivate(Control smartPart)
		{
			this.OnActivate(smartPart);
		}

		void IComposableWorkspace<Control, UltraTabSmartPartInfo>.OnApplySmartPartInfo(Control smartPart, UltraTabSmartPartInfo smartPartInfo)
		{
			this.OnApplySmartPartInfo(smartPart, smartPartInfo);
		}

		void IComposableWorkspace<Control, UltraTabSmartPartInfo>.OnShow(Control smartPart, UltraTabSmartPartInfo smartPartInfo)
		{
			this.OnShow(smartPart, smartPartInfo);
		}

		void IComposableWorkspace<Control, UltraTabSmartPartInfo>.OnHide(Control smartPart)
		{
			this.OnHide(smartPart);
		}

		void IComposableWorkspace<Control, UltraTabSmartPartInfo>.OnClose(Control smartPart)
		{
			this.OnClose(smartPart);
		}

		void IComposableWorkspace<Control, UltraTabSmartPartInfo>.RaiseSmartPartActivated(WorkspaceEventArgs e)
		{
			this.OnSmartPartActivated(e);
		}

		void IComposableWorkspace<Control, UltraTabSmartPartInfo>.RaiseSmartPartClosing(WorkspaceCancelEventArgs e)
		{
			this.OnSmartPartClosing(e);
		}

		UltraTabSmartPartInfo IComposableWorkspace<Control, UltraTabSmartPartInfo>.ConvertFrom(ISmartPartInfo source)
		{
			return this.OnConvertFrom(source);
		}

		#endregion //IComposableWorkspace<Control,UltraTabSmartPartInfo>
	}
}
