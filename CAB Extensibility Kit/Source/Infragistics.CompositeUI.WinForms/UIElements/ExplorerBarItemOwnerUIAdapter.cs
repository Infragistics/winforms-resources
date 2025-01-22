using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinExplorerBar;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="UltraExplorerBarItemsCollection"/> for use as an <see cref="IUIElementAdapter"/> and uses 
	/// the location of the wrapped item to determine where new items are positioned.
	/// </summary>
	public class ExplorerBarItemOwnerUIAdapter : ExplorerBarItemsCollectionUIAdapter
	{
		#region Member Variables

		private UltraExplorerBarItem item;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ExplorerBarItemOwnerUIAdapter"/>
		/// </summary>
		/// <param name="item">Item whose owning collection will be updated with any added elements.</param>
		public ExplorerBarItemOwnerUIAdapter(UltraExplorerBarItem item)
			: base(item.Group.Items)
		{
			Guard.ArgumentNotNull(item, "item");

			this.item = item;
		}
		#endregion //Constructor

		#region Base class overrides

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which an item will be added.
		/// </summary>
		/// <param name="item">Item to evaluate</param>
		/// <returns>By default, items are added at the end of the associated <see cref="Items"/> collection.</returns>
		protected override int GetNewElementIndex(UltraExplorerBarItem item)
		{
			return this.Items.IndexOf(this.item) + 1;
		}
		#endregion //GetNewElementIndex

		#endregion //Base class overrides
	}
}
