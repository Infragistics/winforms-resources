using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinTree;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="UltraTreeNodesCollection"/> for use as an <see cref="IUIElementAdapter"/> and uses 
	/// the location of the wrapped item to determine where new items are positioned.
	/// </summary>
	public class TreeNodeOwnerUIAdapter : TreeNodesCollectionUIAdapter
	{
		#region Member Variables

		private UltraTreeNode node;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ExplorerBarItemOwnerUIAdapter"/>
		/// </summary>
		/// <param name="node">Node whose owning collection will be updated with any added elements.</param>
		public TreeNodeOwnerUIAdapter(UltraTreeNode node)
			: base(node.ParentNodesCollection)
		{
			Guard.ArgumentNotNull(node, "node");

			this.node = node;
		}
		#endregion //Constructor

		#region Base class overrides

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which an item will be added.
		/// </summary>
		/// <param name="node">Item to evaluate</param>
		/// <returns>By default, items are added at the end of the associated <see cref="Items"/> collection.</returns>
		protected override int GetNewElementIndex(UltraTreeNode node)
		{
			return this.Nodes.IndexOf(this.node) + 1;
		}
		#endregion //GetNewElementIndex

		#endregion //Base class overrides
	}
}
