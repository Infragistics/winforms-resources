using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinDock;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using System.Diagnostics;
using System.ComponentModel.Design.Serialization;
using System.CodeDom;
using System.ComponentModel.Design;
using Microsoft.Practices.CompositeUI.Utility;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using Infragistics.Shared;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// A workspace that displays smart parts within an <see cref="UltraDockManager"/>
	/// </summary>
	[Serializable()]
	[LocalizedDescription("Desc_UltraDockWorkspace")]
	public class UltraDockWorkspace : UltraDockManager, IComposableWorkspace<Control, UltraDockSmartPartInfo>
	{
		#region Member Variables

		private ControlWorkspaceComposer<UltraDockSmartPartInfo, string> composer;

		private string workspaceName;

		// antirecursion flag
		private bool verifyingSmartParts = false;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="UltraDockWorkspace"/>
		/// </summary>
		public UltraDockWorkspace()
			: this(null)
		{
		}

		/// <summary>
		/// Initializes a new <see cref="UltraDockWorkspace"/>
		/// </summary>
		public UltraDockWorkspace(IContainer container)
			: base(container)
		{
			this.composer = new ControlWorkspaceComposer<UltraDockSmartPartInfo, string>(this, true);
		}

		/// <summary>
		/// Deserialization constructor
		/// </summary>
		protected UltraDockWorkspace(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			this.composer = new ControlWorkspaceComposer<UltraDockSmartPartInfo, string>(this, true);
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
			set { composer.WorkItem = value; }
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
			DockableControlPane pane = this.PaneFromSmartPart(smartPart);

			// MD 10/18/10 - TFS37058
			// Throw a meaningful exception if the smart part is not docked.
			if (pane == null)
				throw new ArgumentException(string.Format(Properties.Resources.UltraDockWorkspace_MissingSmartPart, this.GetType().Name));

			pane.Show();
			pane.Activate();
		}

		/// <summary>
		/// Applies the smart part info to the smart part within the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to which the smart part info should be applied.</param>
		/// <param name="smartPartInfo">The smart part info to apply</param>
		protected virtual void OnApplySmartPartInfo(Control smartPart, UltraDockSmartPartInfo smartPartInfo)
		{
			DockableControlPane pane = this.PaneFromSmartPart(smartPart);

			// MD 10/18/10 - TFS37058
			// Throw a meaningful exception if the smart part is not docked.
			if (pane == null)
				throw new ArgumentException(string.Format(Properties.Resources.UltraDockWorkspace_MissingSmartPart, this.GetType().Name));

			this.ApplySmartPartInfoHelper(pane, smartPartInfo);
		}

		/// <summary>
		/// Closes/removes the smart part.
		/// </summary>
		protected virtual void OnClose(Control smartPart)
		{
			// remove the backward pointers
			string paneKey = this.PaneKeyFromSmartPart(smartPart);

			this.composer.Remove(paneKey, smartPart);

			// lastly, get rid of the control pane
			if (this.ControlPanes.Exists(paneKey))
				this.ControlPanes.Remove(paneKey);

			if (smartPart.Disposing == false && smartPart.IsDisposed == false)
				smartPart.Parent = null;
		}

		/// <summary>
		/// Hides the smart part.
		/// </summary>
		protected virtual void OnHide(Control smartPart)
		{
			DockableControlPane pane = this.PaneFromSmartPart(smartPart);

			// MD 10/18/10 - TFS37058
			// Throw a meaningful exception if the smart part is not docked.
			if (pane == null)
				throw new ArgumentException(string.Format(Properties.Resources.UltraDockWorkspace_MissingSmartPart, this.GetType().Name));

			pane.Close();
		}

		/// <summary>
		/// Shows the smart part in the workspace.
		/// </summary>
		/// <param name="smartPart">The smart part to show</param>
		/// <param name="smartPartInfo">The associated smart part info for the smart part being shown.</param>
		protected virtual void OnShow(Control smartPart, UltraDockSmartPartInfo smartPartInfo)
		{
			DockableControlPane pane = this.PaneFromControl(smartPart);

			if (pane == null)
				pane = this.CreatePane(smartPart, smartPartInfo);

			// only force the pane to be visible if its not
			// being created because we're synchronizing with the
			// control panes
			if (this.verifyingSmartParts == false)
				pane.Show();
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
		#endregion // Event related

		/// <summary>
		/// Converts a smart part information to a compatible one for the workspace.
		/// </summary>
		protected virtual UltraDockSmartPartInfo OnConvertFrom(ISmartPartInfo source)
		{
			UltraDockSmartPartInfo spi = SmartPartInfo.ConvertTo<UltraDockSmartPartInfo>(source);

			if (spi is ImageSmartPartInfo && source is ImageSmartPartInfo)
			{
				((ImageSmartPartInfo)spi).Image = ((ImageSmartPartInfo)source).Image;
			}

			return spi;
		}
		#endregion //IComposableWorkspace related methods

		#region ApplySmartPartInfoHelper
		private void ApplySmartPartInfoHelper(DockableControlPane pane, UltraDockSmartPartInfo smartPartInfo)
		{
			pane.Text = smartPartInfo.Title;
			pane.ToolTipCaption = smartPartInfo.Description;
			pane.ToolTipTab = smartPartInfo.Description;

			if (smartPartInfo.PreferredSize != Size.Empty)
				pane.Size = smartPartInfo.PreferredSize;

			Image img = smartPartInfo.Image;

			if (img != null)
				pane.Settings.TabAppearance.Image = img;
			else if (pane.HasSettings && pane.Settings.HasTabAppearance)
				pane.Settings.TabAppearance.Image = null;
		} 
		#endregion //ApplySmartPartInfoHelper

		#region CreatePane
		private DockableControlPane CreatePane(Control smartPart, UltraDockSmartPartInfo smartPartInfo)
		{
			// create a pane to represent the smart part control
			DockableControlPane pane = new DockableControlPane(Guid.NewGuid().ToString(), smartPart);

			// keep track of the smart part to pane key relationship
			this.composer.Add(pane.Key, smartPart);

			// apply the smart part info
			this.ApplySmartPartInfoHelper(pane, smartPartInfo);

			// find out where this should be if we don't have a group
			DockedLocation location = smartPartInfo.DefaultLocation;

			// get the default pane style
			ChildPaneStyle paneStyle = smartPartInfo.DefaultPaneStyle;

			// store the key of the new groups
			string preferredGroupKey = smartPartInfo.PreferredGroup;

			// see if the group that this would like to belong to exists
			DockableGroupPane groupPane = this.FindGroup(preferredGroupKey);

			if (groupPane == null)
			{
				// create a dock area that should house the control pane
				DockAreaPane newDockArea = new DockAreaPane(location);
				newDockArea.Key = preferredGroupKey;
				newDockArea.ChildPaneStyle = paneStyle;

				Size paneSize = smartPartInfo.PreferredSize == Size.Empty ? smartPart.Size : smartPartInfo.PreferredSize;

				switch (location)
				{
					case DockedLocation.DockedLeft:
					case DockedLocation.DockedRight:
						paneSize.Width += this.SplitterBarWidth;
						break;
					case DockedLocation.DockedTop:
					case DockedLocation.DockedBottom:
						paneSize.Height += this.SplitterBarWidth;
						break;
				}

				newDockArea.Size = paneSize;

				newDockArea.Panes.Add(pane);
				this.DockAreas.Add(newDockArea);
			}
			else // just add it to the group that already exists
				groupPane.Panes.Add(pane);

			return pane;
		}
		#endregion //CreatePane

		#region FindGroup
		private DockableGroupPane FindGroup(string preferredGroup)
		{
			DockablePaneBase pane = this.PaneFromKey(preferredGroup);

			return pane as DockableGroupPane;
		}
		#endregion //FindGroup

		#region PaneFromSmartPart
		private DockableControlPane PaneFromSmartPart(Control smartPart)
		{
			// MD 10/18/10 - TFS37058
			// We can't assume the smart part is docked. The smart parts and control panes collection could be out of sync.
			//return this.ControlPanes[this.composer[smartPart]];		
			string key;
			if (this.composer.TryGetItem(smartPart, out key) == false)
				return null;

			if (this.ControlPanes.Exists(key) == false)
			{
				this.composer.Remove(key, smartPart);
				return null;
			}

			return this.ControlPanes[key];
		}
		#endregion //PaneFromSmartPart

		#region PaneKeyFromSmartPart
		private string PaneKeyFromSmartPart(Control smartPart)
		{
			return this.composer[smartPart];
		}
		#endregion //PaneKeyFromSmartPart

		#region VerifySmartParts
		private void VerifySmartParts()
		{
			if (this.verifyingSmartParts)
				return;

			try
			{
				this.verifyingSmartParts = true;

				foreach (DockableControlPane pane in this.ControlPanes)
				{
					Control smartPart = pane.Control;

					Debug.Assert(smartPart != null, "The control pane is not associated with a control.");

					if (smartPart == null)
						continue;

					if (smartPart.IsDisposed || smartPart.Disposing)
						continue;

					// if we haven't created an association between
					// the smart part and tabs
					if (this.composer.ContainsItem(pane.Key) == false)
					{
                        // if a layout was loaded then the smart part
                        // may already be referenced by the workspace
                        // in which case we just want to transfer which
                        // pane the smart part is associated with. to do
                        // this, we'll remove the old smartpart/pane 
                        // pair and add the new one.
                        if (this.composer.ContainsSmartPart(smartPart))
                        {
                            this.composer.Remove(this.composer[smartPart], smartPart);
                            this.composer.Add(pane.Key, smartPart);
                        }
                        else
                        {
                            this.composer.Add(pane.Key, smartPart);

                            UltraDockSmartPartInfo spi = new UltraDockSmartPartInfo();
                            this.Show(smartPart, spi);
                        }
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
			// AS 12/14/06 BR18647
			//this.composer.VerifyActiveItem(this.ActivePane == null ? null : this.ActivePane.Key);
			this.composer.VerifyActiveItem(this.ActivePane == null || this.ActivePane.IsInView == false ? null : this.ActivePane.Key);
		}
		#endregion //VerifyActiveSmartPart

		#endregion //Methods

		#region Base class overrides

		// MD 10/18/10 - TFS37058
		#region OnLayoutLoaded

		/// <summary>
		/// Called after a layout file is loaded with one of the LoadFromBinary or LoadFromXML overloads.
		/// </summary>
		protected override void OnLayoutLoaded()
		{
			base.OnLayoutLoaded();

			List<Control> smartPartsToRemove = null;
			foreach (Control smartPart in this.composer.SmartParts)
			{
				if (this.ControlPanes.Contains(smartPart))
					continue;

				if (smartPartsToRemove == null)
					smartPartsToRemove = new List<Control>();

				smartPartsToRemove.Add(smartPart);
			}

			if (smartPartsToRemove != null)
			{
				foreach (Control smartPart in smartPartsToRemove)
					this.composer.Remove(this.composer[smartPart], smartPart);
			}
		}

		#endregion // OnLayoutLoaded

		#region OnPropertyChanged
		/// <summary>
		/// Overriden. Used to invoke the <see cref="PropertyChanged"/> event when a property of the object or one of its subobjects has changed.
		/// </summary>
		/// <param name="e">Event args that provides information about the property change.</param>
		protected override void OnPropertyChanged(Infragistics.Win.PropertyChangedEventArgs e)
		{
			if (e.ChangeInfo.PropId is PropertyIds)
			{
				if ((PropertyIds)e.ChangeInfo.PropId == PropertyIds.ControlPanes)
				{
					// verify the control panes collection
					this.VerifySmartParts();
				}
			}

			base.OnPropertyChanged(e);
		}
		#endregion //OnPropertyChanged 

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

		#region IComposableWorkspace<Control,UltraDockSmartPartInfo>

		void IComposableWorkspace<Control, UltraDockSmartPartInfo>.OnActivate(Control smartPart)
		{
			this.OnActivate(smartPart);
		}

		void IComposableWorkspace<Control, UltraDockSmartPartInfo>.OnApplySmartPartInfo(Control smartPart, UltraDockSmartPartInfo smartPartInfo)
		{
			this.OnApplySmartPartInfo(smartPart, smartPartInfo);
		}

		void IComposableWorkspace<Control, UltraDockSmartPartInfo>.OnShow(Control smartPart, UltraDockSmartPartInfo smartPartInfo)
		{
			this.OnShow(smartPart, smartPartInfo);
		}

		void IComposableWorkspace<Control, UltraDockSmartPartInfo>.OnHide(Control smartPart)
		{
			this.OnHide(smartPart);
		}

		void IComposableWorkspace<Control, UltraDockSmartPartInfo>.OnClose(Control smartPart)
		{
			this.OnClose(smartPart);
		}

		void IComposableWorkspace<Control, UltraDockSmartPartInfo>.RaiseSmartPartActivated(WorkspaceEventArgs e)
		{
			this.OnSmartPartActivated(e);
		}

		void IComposableWorkspace<Control, UltraDockSmartPartInfo>.RaiseSmartPartClosing(WorkspaceCancelEventArgs e)
		{
			this.OnSmartPartClosing(e);
		}

		UltraDockSmartPartInfo IComposableWorkspace<Control, UltraDockSmartPartInfo>.ConvertFrom(ISmartPartInfo source)
		{
			return this.OnConvertFrom(source);
		}

		#endregion //IComposableWorkspace<Control,UltraDockSmartPartInfo>
	}
	
}
