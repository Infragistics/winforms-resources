using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinTree;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="UltraExplorerBarGroup"/> for use as an <see cref="IUIElementAdapter"/>.
	/// </summary>
	public class TreeNodesCollectionUIAdapter : UIElementAdapter<UltraTreeNode>
	{
		#region Member Variables

		private TreeNodesCollection nodes;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="TreeNodesCollectionUIAdapter"/>
		/// </summary>
		/// <param name="nodes">Nodes collection represented by the ui adapter</param>
		public TreeNodesCollectionUIAdapter(TreeNodesCollection nodes)
		{
			Guard.ArgumentNotNull(nodes, "nodes");

			this.nodes = nodes;
		}
		#endregion //Constructor

		#region Properties

		#region nodes
		/// <summary>
		/// The <see cref="TreeNodesCollection"/> that is represented by the adapter.
		/// </summary>
		protected TreeNodesCollection Nodes
		{
			get { return this.nodes; }
		}
		#endregion //nodes

		#endregion //Properties

		#region Methods

		#region Add
		/// <summary>
		/// Adds an <see cref="UltraTreeNode"/> to the <see cref="UltraExplorerBarGroup"/> associated with the adapter.
		/// </summary>
		/// <param name="uiElement">UltraTree node to add to the collection</param>
		/// <returns>The node that was added.</returns>
		protected override UltraTreeNode Add(UltraTreeNode uiElement)
		{
			this.nodes.Insert(this.GetNewElementIndex(uiElement), uiElement);
			return uiElement;
		}

		#endregion //Add

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which an item will be added.
		/// </summary>
		/// <param name="item">Item to evaluate</param>
		/// <returns>By default, nodes are added at the end of the associated <see cref="nodes"/> collection.</returns>
		protected virtual int GetNewElementIndex(UltraTreeNode item)
		{
			return this.nodes.Count;
		}
		#endregion //GetNewElementIndex

		#region Remove
		/// <summary>
		/// Removes the specified <see cref="UltraTreeNode"/> from the associated <see cref="UltraExplorerBarGroup"/>
		/// </summary>
		/// <param name="uiElement">UltraTree node that should be removed.</param>
		protected override void Remove(UltraTreeNode uiElement)
		{
			// AS 12/6/07 BR28731
			if (uiElement.ParentNodesCollection != null)
				this.nodes.Remove(uiElement);
		}
		#endregion //Remove

		#endregion // Methods
	}
}
