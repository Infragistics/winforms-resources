using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.Commands;
using System.Diagnostics;

namespace Infragistics.Practices.CompositeUI.WinForms.Commands
{
	/// <summary>
	/// Class for managing the relationship between a <b>ToolBase</b> and a <see cref="Command"/>
	/// </summary>
	public class ToolBaseCommandAdapter : CommandAdapterBase<ToolBase>
	{
		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ToolBaseCommandAdapter"/>
		/// </summary>
		public ToolBaseCommandAdapter()
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
		internal override object GetEventSource(ToolBase invoker, string eventName)
		{
			return invoker.ToolbarsManager;
		}
		#endregion //GetEventSource

		#region CreateLogicalInvoker
		internal override IUIElement CreateLogicalInvoker(ToolBase invoker)
		{
			Debug.Assert(invoker != null && invoker.ToolbarsManager != null && invoker.Key != null, "Unexpected tool state to be creating an invoker key.");

			return new ToolInvokerKey(invoker.ToolbarsManager, invoker.Key);
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
			ToolBase eventItem = this.GetItem(e);
			ToolBase item = this.Invoker;

			if (null != item)
			{
				bool isSameItem = eventItem != null &&
					(eventItem == item || (item.Key != null && item.Key.Length > 0 && item.Key == eventItem.Key));

				if (isSameItem)
					this.FireCommand();
			}
		}

		#endregion //OnEventInvoked

		#endregion //Base class overrides

		#region Methods

		#region GetItem
		private ToolBase GetItem(EventArgs e)
		{
			if (e is ToolEventArgs)
				return ((ToolEventArgs)e).Tool;
			else if (e is CancelableToolEventArgs)
				return ((CancelableToolEventArgs)e).Tool;
			else if (e is ToolKeyEventArgs)
				return ((ToolKeyEventArgs)e).Tool;
			else if (e is ToolKeyPressEventArgs)
				return ((ToolKeyPressEventArgs)e).Tool;

			Debug.Assert(false, string.Format("Unexpected event args type: " + e.GetType()));

			return null;
		}
		#endregion //GetItem

		#endregion //Methods

		#region ToolInvokerKey nested class
		private class ToolInvokerKey : IUIElement
		{
			#region Base class overrides

			private string key;
			private UltraToolbarsManager manager;

			#endregion //Base class overrides

			#region Constructor
			public ToolInvokerKey(UltraToolbarsManager manager, string toolKey)
			{
				this.key = toolKey;
				this.manager = manager;
			}
			#endregion //Constructor

			#region Equals
			public override bool Equals(object obj)
			{
				ToolInvokerKey toolKey = obj as ToolInvokerKey;

				if (toolKey != null)
				{
					return toolKey.manager == this.manager &&
						toolKey.key == this.key;
				}

				return false;
			}
			#endregion //Equals

			#region GetHashCode
			public override int GetHashCode()
			{
				return this.key.GetHashCode();
			}
			#endregion //GetHashCode

			#region IUIElement

			void IUIElement.UpdateState(CommandStatus newStatus)
			{
				ToolBase tool = this.manager.Tools[this.key];

				tool.SharedProps.Enabled = newStatus == CommandStatus.Enabled;
				tool.SharedProps.Visible = newStatus != CommandStatus.Unavailable;
			}

			#endregion // IUIElement
		}
		#endregion //ToolInvokerKey nested class
	}
}
