using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinTree;
using Microsoft.Practices.CompositeUI.Commands;
using System.Diagnostics;

namespace Infragistics.Practices.CompositeUI.WinForms.Commands
{
	/// <summary>
	/// Class for managing the relationship between <b>UltraTreeNode</b> instances and a <see cref="Command"/>.
	/// </summary>
	public class TreeNodeCommandAdapter : CommandAdapterBase<UltraTreeNode>
	{
		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="TreeCommandAdapter"/>
		/// </summary>
		public TreeNodeCommandAdapter()
		{
		}
		#endregion //Constructor

		#region Base class overrides

		#region GetEventSource
#if DEBUG
		/// <summary>
		/// Invoked to determine the object whose event should be hooked.
		/// </summary>
		/// <param name="invoker">Node for which the specified event will be hooked</param>
		/// <param name="eventName">Event that will be hooked.</param>
		/// <returns>The object whose event should be hooked.</returns>
#endif
		internal override object GetEventSource(UltraTreeNode invoker, string eventName)
		{
			return invoker.Control;
		}
		#endregion //GetEventSource

		#region CreateLogicalInvoker
		internal override IUIElement CreateLogicalInvoker(UltraTreeNode invoker)
		{
			Debug.Assert(invoker != null && invoker.Control != null, "Unexpected node state to be creating an invoker key.");

			return new TreeNodeInvokerKey(invoker);
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
			bool isSameItem = false;
			UltraTreeNode item = this.Invoker;

			UltraTreeNode eventItem = this.GetItem(e);

			if (eventItem != null)
			{
				isSameItem = eventItem != null && eventItem == item;
			}
			else
			{
				SelectedNodesCollection nodes = this.GetSelectedNodes(e);

				if (nodes != null)
				{
					isSameItem = nodes.Contains(item);
				}
				else
				{
					UltraTreeNode[] nodeArray = this.GetNodeArray(e);

					if (nodeArray != null)
						isSameItem = Array.IndexOf<UltraTreeNode>(nodeArray, item) >= 0;
				}
			}

			if (isSameItem)
				this.FireCommand();
		}

		#endregion //OnEventInvoked

		#endregion //Base class overrides

		#region Methods

		private SelectedNodesCollection GetSelectedNodes(EventArgs e)
		{
			if (e is NodesEventArgs)
				return ((NodesEventArgs)e).Nodes;
			if (e is SelectEventArgs)
				return ((SelectEventArgs)e).NewSelections;
			else if (e is CancelableNodesEventArgs)
				return ((CancelableNodesEventArgs)e).Nodes;
			else if (e is BeforeSelectEventArgs)
				return ((BeforeSelectEventArgs)e).NewSelections;

			return null;
		}

		private UltraTreeNode[] GetNodeArray(EventArgs e)
		{
			if (e is BeforeNodesDeletedEventArgs)
				return ((BeforeNodesDeletedEventArgs)e).Nodes;

			return null;
		}

		#region GetItem
		private UltraTreeNode GetItem(EventArgs e)
		{
			if (e is NodeEventArgs)
				return ((NodeEventArgs)e).TreeNode;
			else if (e is CancelableNodeEventArgs)
				return ((CancelableNodeEventArgs)e).TreeNode;

			return null;
		}

		#endregion //GetItem

		#endregion //Methods

		#region TreeNodeInvokerKey nested class
		private class TreeNodeInvokerKey : IUIElement
		{
			#region Base class overrides

			private UltraTreeNode item;

			#endregion //Base class overrides

			#region Constructor
			public TreeNodeInvokerKey(UltraTreeNode item)
			{
				this.item = item;
			}
			#endregion //Constructor

			#region Equals
			public override bool Equals(object obj)
			{
				TreeNodeInvokerKey item = obj as TreeNodeInvokerKey;

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
				this.item.Enabled = newStatus == CommandStatus.Enabled;
				this.item.Visible = newStatus != CommandStatus.Unavailable;
			}

			#endregion // IUIElement
		}
		#endregion //TreeNodeInvokerKey nested class
	}
}
