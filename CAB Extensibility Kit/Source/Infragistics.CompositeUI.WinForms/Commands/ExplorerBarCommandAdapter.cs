using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinExplorerBar;
using Microsoft.Practices.CompositeUI.Commands;
using System.Diagnostics;
using Infragistics.Win;

namespace Infragistics.Practices.CompositeUI.WinForms.Commands
{
	/// <summary>
	/// Class for managing the relationship between a <b>UltraExplorerBarItem</b> instances and a <see cref="Command"/>.
	/// </summary>
	public class ExplorerBarCommandAdapter : CommandAdapterBase<UltraExplorerBarItem>
	{
		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ExplorerBarCommandAdapter"/>
		/// </summary>
		public ExplorerBarCommandAdapter()
		{
		}
		#endregion //Constructor

		#region Base class overrides

		#region GetEventSource
#if DEBUG
		/// <summary>
		/// Invoked to determine the object whose event should be hooked.
		/// </summary>
		/// <param name="invoker">Item for which the specified event will be hooked</param>
		/// <param name="eventName">Event that will be hooked.</param>
		/// <returns>The object whose event should be hooked.</returns>
#endif
		internal override object GetEventSource(UltraExplorerBarItem invoker, string eventName)
		{
			return invoker.ExplorerBar;
		}
		#endregion //GetEventSource

		#region CreateLogicalInvoker
		internal override IUIElement CreateLogicalInvoker(UltraExplorerBarItem invoker)
		{
			Debug.Assert(invoker != null && invoker.ExplorerBar != null, "Unexpected panel state to be creating an invoker key.");

			return new ExplorerItemInvokerKey(invoker);
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
			UltraExplorerBarItem eventItem = this.GetItem(e);
			UltraExplorerBarItem item = this.Invoker;

			bool isSameItem = eventItem != null && eventItem == item;

			if (isSameItem)
				this.FireCommand();
		}

		#endregion //OnEventInvoked

		#endregion //Base class overrides

		#region Methods

		#region GetItem
		private UltraExplorerBarItem GetItem(EventArgs e)
		{
			if (e is ItemEventArgs)
				return ((ItemEventArgs)e).Item;
			else if (e is CancelableItemEventArgs)
				return ((CancelableItemEventArgs)e).Item;
			else if (e is CancelableItemExitingEditModeEventArgs)
				return ((CancelableItemExitingEditModeEventArgs)e).Item;
			else if (e is ItemDragOverEventArgs)
				return ((ItemDragOverEventArgs)e).Item;
			else if (e is ItemDroppedEventArgs)
				return ((ItemDroppedEventArgs)e).Item;
			else if (e is CancelableContextMenuInitializingEventArgs)
				return ((CancelableContextMenuInitializingEventArgs)e).Item;
			else if (e is NavigationPaneFlyoutClosedEventArgs)
				return ((NavigationPaneFlyoutClosedEventArgs)e).SelectedItem;

			Debug.Assert(false, string.Format("Unexpected event args type: " + e.GetType()));

			return null;
		}
		#endregion //GetItem

		#endregion //Methods

		#region ExplorerItemInvokerKey nested class
		private class ExplorerItemInvokerKey : IUIElement
		{
			#region Base class overrides

			private UltraExplorerBarItem item;

			#endregion //Base class overrides

			#region Constructor
			public ExplorerItemInvokerKey(UltraExplorerBarItem item)
			{
				this.item = item;
			}
			#endregion //Constructor

			#region Equals
			public override bool Equals(object obj)
			{
				ExplorerItemInvokerKey item = obj as ExplorerItemInvokerKey;

				if (item != null)
				{
					return item.item == this.item;
				}

				return false;
			}
			#endregion //Equals

			#region GetHashCode
			public override int GetHashCode()
			{
				return this.item.GetHashCode();
			}
			#endregion //GetHashCode

			#region IUIElement

			void IUIElement.UpdateState(CommandStatus newStatus)
			{
				this.item.Settings.Enabled = newStatus == CommandStatus.Enabled ? DefaultableBoolean.Default : DefaultableBoolean.False;
				this.item.Visible = newStatus != CommandStatus.Unavailable;
			}

			#endregion // IUIElement
		}
		#endregion //ExplorerItemInvokerKey nested class
	}
}
