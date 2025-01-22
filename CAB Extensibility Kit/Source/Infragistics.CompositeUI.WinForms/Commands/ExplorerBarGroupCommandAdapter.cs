using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinExplorerBar;
using Microsoft.Practices.CompositeUI.Commands;
using System.Diagnostics;

namespace Infragistics.Practices.CompositeUI.WinForms.Commands
{
	/// <summary>
	/// Class for managing the relationship between a <b>UltraExplorerBarGroup</b> instances and a <see cref="Command"/>.
	/// </summary>
	public class ExplorerBarGroupCommandAdapter : CommandAdapterBase<UltraExplorerBarGroup>
	{
		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ExplorerBarGroupCommandAdapter"/>
		/// </summary>
		public ExplorerBarGroupCommandAdapter()
		{
		}
		#endregion //Constructor

		#region Base class overrides

		#region CreateLogicalInvoker
		internal override IUIElement CreateLogicalInvoker(UltraExplorerBarGroup invoker)
		{
			Debug.Assert(invoker != null && invoker.ExplorerBar != null, "Unexpected state to be creating an invoker key.");

			return new ExplorerGroupInvokerKey(invoker);
		}
		#endregion //CreateLogicalInvoker

		#region GetEventSource
#if DEBUG
		/// <summary>
		/// Invoked to determine the object whose event should be hooked.
		/// </summary>
		/// <param name="invoker">Group for which the specified event will be hooked</param>
		/// <param name="eventName">Event that will be hooked.</param>
		/// <returns>The object whose event should be hooked.</returns>
#endif
		internal override object GetEventSource(UltraExplorerBarGroup invoker, string eventName)
		{
			return invoker.ExplorerBar;
		}
		#endregion //GetEventSource

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
			UltraExplorerBarGroup eventItem = this.GetItem(e);
			UltraExplorerBarGroup item = this.Invoker;

			bool isSameItem = eventItem != null && eventItem == item;

			if (isSameItem)
				this.FireCommand();
		}

		#endregion //OnEventInvoked

		#endregion //Base class overrides

		#region Methods

		#region GetItem
		private UltraExplorerBarGroup GetItem(EventArgs e)
		{
			if (e is GroupEventArgs)
				return ((GroupEventArgs)e).Group;
			else if (e is CancelableGroupEventArgs)
				return ((CancelableGroupEventArgs)e).Group;
			else if (e is CancelableGroupExitingEditModeEventArgs)
				return ((CancelableGroupExitingEditModeEventArgs)e).Group;
			else if (e is GroupDragOverEventArgs)
				return ((GroupDragOverEventArgs)e).Group;
			else if (e is GroupDroppedEventArgs)
				return ((GroupDroppedEventArgs)e).Group;
			else if (e is CancelableContextMenuInitializingEventArgs)
				return ((CancelableContextMenuInitializingEventArgs)e).Group;

			Debug.Assert(false, string.Format("Unexpected event args type: " + e.GetType()));

			return null;
		}
		#endregion //GetItem

		#endregion //Methods

		#region ExplorerGroupInvokerKey nested class
		private class ExplorerGroupInvokerKey : IUIElement
		{
			#region Base class overrides

			private UltraExplorerBarGroup group;

			#endregion //Base class overrides

			#region Constructor
			public ExplorerGroupInvokerKey(UltraExplorerBarGroup group)
			{
				this.group = group;
			}
			#endregion //Constructor

			#region Equals
			public override bool Equals(object obj)
			{
				ExplorerGroupInvokerKey group = obj as ExplorerGroupInvokerKey;

				if (group != null)
				{
					return group.group == this.group;
				}

				return false;
			}
			#endregion //Equals

			#region GetHashCode
			public override int GetHashCode()
			{
				return this.group.GetHashCode();
			}
			#endregion //GetHashCode

			#region IUIElement

			void IUIElement.UpdateState(CommandStatus newStatus)
			{
				this.group.Enabled = newStatus == CommandStatus.Enabled;
				this.group.Visible = newStatus != CommandStatus.Unavailable;
			}

			#endregion // IUIElement
		}
		#endregion //ExplorerGroupInvokerKey nested class

	}
}
