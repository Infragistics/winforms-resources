using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinExplorerBar;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="UltraExplorerBarGroup"/> for use as an <see cref="IUIElementAdapter"/>.
	/// </summary>
	public class ExplorerBarItemsCollectionUIAdapter : UIElementAdapter<UltraExplorerBarItem>
	{
		#region Member Variables

		private UltraExplorerBarItemsCollection items;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ExplorerBarItemsCollectionUIAdapter"/>
		/// </summary>
		/// <param name="items">Items collection represented by the ui adapter</param>
		public ExplorerBarItemsCollectionUIAdapter(UltraExplorerBarItemsCollection items)
		{
			Guard.ArgumentNotNull(items, "items");

			this.items = items;
		} 
		#endregion //Constructor

		#region Properties

		#region Items
		/// <summary>
		/// The <see cref="UltraExplorerBarGroup"/> that is represented by the adapter.
		/// </summary>
		protected UltraExplorerBarItemsCollection Items
		{
			get { return this.items; }
		}
		#endregion //Items

		#endregion //Properties

		#region Methods

		#region Add
		/// <summary>
		/// Adds an <see cref="UltraExplorerBarItem"/> to the <see cref="UltraExplorerBarGroup"/> associated with the adapter.
		/// </summary>
		/// <param name="uiElement">ExplorerBar item to add to the group</param>
		/// <returns>The item that was added.</returns>
		protected override UltraExplorerBarItem Add(UltraExplorerBarItem uiElement)
		{
			this.items.Insert(this.GetNewElementIndex(uiElement), uiElement);
			return uiElement;
		}

		#endregion //Add

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which an item will be added.
		/// </summary>
		/// <param name="item">Item to evaluate</param>
		/// <returns>By default, items are added at the end of the associated <see cref="Items"/> collection.</returns>
		protected virtual int GetNewElementIndex(UltraExplorerBarItem item)
		{
			return this.items.Count;
		}
		#endregion //GetNewElementIndex

		#region Remove
		/// <summary>
		/// Removes the specified <see cref="UltraExplorerBarItem"/> from the associated <see cref="UltraExplorerBarGroup"/>
		/// </summary>
		/// <param name="uiElement">ExplorerBar item that should be removed.</param>
		protected override void Remove(UltraExplorerBarItem uiElement)
		{
			this.items.Remove(uiElement);
		}
		#endregion //Remove

		#endregion // Methods
	}
}
