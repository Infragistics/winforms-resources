using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinStatusBar;
using Microsoft.Practices.CompositeUI.Commands;
using System.Diagnostics;

namespace Infragistics.Practices.CompositeUI.WinForms.Commands
{
	/// <summary>
	/// Class for managing the relationship between a <b>UltraStatusPanel</b> instances and a <see cref="Command"/>.
	/// </summary>
	public class StatusPanelCommandAdapter : CommandAdapterBase<UltraStatusPanel>
	{
		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="StatusPanelCommandAdapter"/>
		/// </summary>
		public StatusPanelCommandAdapter()
		{
		} 
		#endregion //Constructor

		#region Base class overrides

		#region GetEventSource
#if DEBUG
		/// <summary>
		/// Invoked to determine the object whose event should be hooked.
		/// </summary>
		/// <param name="invoker">Tool for which the specified event will be hooked</param>
		/// <param name="eventName">Event that will be hooked.</param>
		/// <returns>The object whose event should be hooked.</returns>
#endif
		internal override object GetEventSource(UltraStatusPanel invoker, string eventName)
		{
			return invoker.UltraStatusBar;
		}
		#endregion //GetEventSource

		#region CreateLogicalInvoker
		internal override IUIElement CreateLogicalInvoker(UltraStatusPanel invoker)
		{
			Debug.Assert(invoker != null && invoker.Control != null, "Unexpected panel state to be creating an invoker key.");

			return new PanelInvokerKey(invoker);
		}
		#endregion //CreateLogicalInvoker

		#region OnEventInvoked

#if DEBUG
		/// <summary>
		/// Invoked when a method on the invoker has been raised.
		/// </summary>
		/// <param name="sender">Object whose event was raised</param>
		/// <param name="e">Event arguments for the raised event.</param>
#endif
		internal override void OnEventInvoked(object sender, EventArgs e)
		{
			UltraStatusPanel eventItem = this.GetItem(e);
			UltraStatusPanel item = this.Invoker;

			bool isSameItem = eventItem != null && eventItem == item;

			if (isSameItem)
				this.FireCommand();
		}

		#endregion //OnEventInvoked

		#endregion //Base class overrides

		#region Methods

		#region GetItem
		private UltraStatusPanel GetItem(EventArgs e)
		{
			if (e is PanelEventArgs)
				return ((PanelEventArgs)e).Panel;
			else if (e is PanelClickEventArgs)
				return ((PanelClickEventArgs)e).Panel;

			Debug.Assert(false, string.Format("Unexpected event args type: " + e.GetType()));

			return null;
		}
		#endregion //GetItem

		#endregion //Methods

		#region PanelInvokerKey nested class
		private class PanelInvokerKey : IUIElement
		{
			#region Base class overrides

			private UltraStatusPanel panel;

			#endregion //Base class overrides

			#region Constructor
			public PanelInvokerKey(UltraStatusPanel panel)
			{
				this.panel = panel;
			}
			#endregion //Constructor

			#region Equals
			public override bool Equals(object obj)
			{
				PanelInvokerKey item = obj as PanelInvokerKey;

				if (item != null)
				{
					return item.panel == this.panel;
				}

				return false;
			}
			#endregion //Equals

			#region GetHashCode
			public override int GetHashCode()
			{
				return this.panel.GetHashCode();
			}
			#endregion //GetHashCode

			#region IUIElement

			void IUIElement.UpdateState(CommandStatus newStatus)
			{
				this.panel.Enabled = newStatus == CommandStatus.Enabled;
				this.panel.Visible = newStatus != CommandStatus.Unavailable;
			}

			#endregion // IUIElement
		}
		#endregion //PanelInvokerKey nested class
	}
}
