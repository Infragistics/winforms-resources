using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Utility;
using System.Diagnostics;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// Helper class for dealing with a composable workspace where the smart parts are controls.
	/// </summary>
	/// <typeparam name="TSmartPartInfo">Type of the smart part info for the workspace</typeparam>
	/// <typeparam name="TWorkspaceItem">Type of the item that represents the smart parts in the workspace.</typeparam>
	internal class ControlWorkspaceComposer<TSmartPartInfo, TWorkspaceItem> : WorkspaceComposer<Control, TSmartPartInfo>
		where TSmartPartInfo : ISmartPartInfo, new()
		where TWorkspaceItem : class
	{
		#region Member Variables

		private Dictionary<Control, TWorkspaceItem> smartParts = new Dictionary<Control, TWorkspaceItem>();
		private Dictionary<TWorkspaceItem, Control> items = new Dictionary<TWorkspaceItem, Control>();

		private IComposableWorkspace<Control, TSmartPartInfo> composedWorkspace;

		private Control smartPartBeingActivated = null;
		private bool hookControlEnter = false;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ControlWorkspaceComposer"/>
		/// </summary>
		/// <param name="composedWorkspace">ComposableWorkspace that will be delegated to.</param>
		/// <param name="activateSmartPartOnControlEnter">Boolean indicating whether to automatically activate the smart part when the control's Enter event is invoked.</param>
		public ControlWorkspaceComposer(IComposableWorkspace<Control, TSmartPartInfo> composedWorkspace, bool activateSmartPartOnControlEnter)
			: base(composedWorkspace)
		{
			this.composedWorkspace = composedWorkspace;
			this.hookControlEnter = activateSmartPartOnControlEnter;
		} 
		#endregion //Constructor

		#region Properties

		#region Indexer
		public TWorkspaceItem this[Control smartPart]
		{
			get
			{
				TWorkspaceItem item;
				this.TryGetItem(smartPart, out item);
				return item;
			}
		}

		public Control this[TWorkspaceItem item]
		{
			get
			{
				Control smartPart;
				this.TryGetSmartPart(item, out smartPart);
				return smartPart;
			}
		}
				#endregion //Indexer

		#endregion //Properties

		#region Methods

		#region Public

		// AS 11/15/07 BR27062
		// Technically I think this is a bug in cab. They're setting the activesmartpart member variable
		// after calling the OnActivate of the workspace. However, we can get around it while we are in the
		// OnActivate.
		//
		#region ActivateHelper
		/// <summary>
		/// Activates the smartPart on the workspace if it is not already in the process of being activated.
		/// </summary>
		/// <param name="smartPart">The smart part to activate.</param>
		public void ActivateHelper(object smartPart)
		{
			if (smartPart == this.smartPartBeingActivated)
				return;

			this.Activate(smartPart);
		}
		#endregion //ActivateHelper

		#region Add
		public void Add(TWorkspaceItem item, Control smartPart)
		{
			Guard.ArgumentNotNull(item, "item");
			Guard.ArgumentNotNull(smartPart, "smartPart");

			if (smartPart.IsDisposed)
				throw new InvalidOperationException();

			this.items.Add(item, smartPart);
			this.smartParts.Add(smartPart, item);

			smartPart.Disposed += new EventHandler(OnSmartPartControlDisposed);

			if (this.hookControlEnter)
				smartPart.Enter += new EventHandler(OnSmartPartControlEnter);
		}  
		#endregion //Add

		#region Contains
		public bool ContainsItem(TWorkspaceItem item)
		{
			return this.items.ContainsKey(item);
		}

		public bool ContainsSmartPart(Control smartPart)
		{
			return this.smartParts.ContainsKey(smartPart);
		} 
		#endregion //Contains

		#region Remove
		public void Remove(TWorkspaceItem item, Control smartPart)
		{
			Guard.ArgumentNotNull(item, "item");
			Guard.ArgumentNotNull(smartPart, "smartPart");

			if (this.items[item] != smartPart || this.smartParts[smartPart] != item)
				throw new InvalidOperationException();

			this.items.Remove(item);
			this.smartParts.Remove(smartPart);

			smartPart.Disposed -= new EventHandler(OnSmartPartControlDisposed);

			if (this.hookControlEnter)
				smartPart.Enter -= new EventHandler(OnSmartPartControlEnter);
		} 
		#endregion //Remove

		#region TryGet
		public bool TryGetItem(Control smartPart, out TWorkspaceItem item)
		{
			return this.smartParts.TryGetValue(smartPart, out item);
		}

		public bool TryGetSmartPart(TWorkspaceItem item, out Control smartPart)
		{
			return this.items.TryGetValue(item, out smartPart);
		} 
		#endregion //TryGet

		#region VerifyActive
		public void VerifyActiveItem(TWorkspaceItem item)
		{
			Control smartPart = null != item ? this[item] : null;

			this.VerifyActiveSmartPart(smartPart);
		}

		public void VerifyActiveSmartPart(Control smartPart)
		{
			if (this.ActiveSmartPart != smartPart)
			{
				this.SetActiveSmartPart(smartPart);
				this.RaiseSmartPartActivated(smartPart);
			}
		}
		#endregion //VerifyActive

		#endregion //Public

		#region Private

		#region OnSmartPartControlDisposed
		private void OnSmartPartControlDisposed(object sender, EventArgs e)
		{
			Control ctrl = sender as Control;

			if (this.ContainsSmartPart(ctrl))
				this.ForceClose(ctrl);
		}
		#endregion //OnSmartPartControlDisposed

		#region OnSmartPartControlEnter
		private void OnSmartPartControlEnter(object sender, EventArgs e)
		{
			this.VerifyActiveSmartPart(sender as Control);
		}
		#endregion //OnSmartPartControlEnter

		#endregion //Private

		#endregion //Methods

		#region Base class overrides

		#region OnActivate
		/// <summary>
		/// Calls <see cref="IComposableWorkspace{TSmartPart, TSmartPartInfo}.OnActivate"/> 
		/// on the composed workspace.
		/// </summary>
		protected override void OnActivate(Control smartPart)
		{
			if (smartPart == this.smartPartBeingActivated)
				return;

			Utilities.Output("OnActivate", "Before", smartPart);

			Control previousSmartPart = this.smartPartBeingActivated;

			try
			{
				this.smartPartBeingActivated = smartPart;

				base.OnActivate(smartPart);
			}
			finally
			{
				this.smartPartBeingActivated = previousSmartPart;
			}

			Utilities.Output("OnActivate", "After", smartPart);
		} 
		#endregion //OnActivate

		#region OnApplySmartPartInfo
#if DEBUG
		protected override void OnApplySmartPartInfo(Control smartPart, TSmartPartInfo smartPartInfo)
		{
			Utilities.Output("OnApplySmartPartInfo", "Before", smartPart, smartPartInfo);

			composedWorkspace.OnApplySmartPartInfo(smartPart, smartPartInfo);

			Utilities.Output("OnApplySmartPartInfo", "After", smartPart, smartPartInfo);
		}
#endif // DEBUG 
		#endregion //OnApplySmartPartInfo

		#region OnShow
#if DEBUG
		protected override void OnShow(Control smartPart, TSmartPartInfo smartPartInfo)
		{
			Utilities.Output("OnShow", "Before", smartPart, smartPartInfo);

			composedWorkspace.OnShow(smartPart, smartPartInfo);

			Utilities.Output("OnShow", "After", smartPart, smartPartInfo);
		}
#endif // DEBUG 
		#endregion //OnShow

		#region OnHide
#if DEBUG
		protected override void OnHide(Control smartPart)
		{
			Utilities.Output("OnHide", "Before", smartPart);

			composedWorkspace.OnHide(smartPart);

			Utilities.Output("OnHide", "After", smartPart);
		}
#endif // DEBUG 
		#endregion //OnHide

		#region OnClose
#if DEBUG
		protected override void OnClose(Control smartPart)
		{
			Utilities.Output("OnClose", "Before", smartPart);

			composedWorkspace.OnClose(smartPart);

			Utilities.Output("OnClose", "After", smartPart);
		}
#endif // DEBUG 
		#endregion //OnClose

		#endregion //Base class overrides	
	}
}
