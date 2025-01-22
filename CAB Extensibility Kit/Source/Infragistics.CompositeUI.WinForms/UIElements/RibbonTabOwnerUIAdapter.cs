using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="RibbonTabCollection"/> for use as an <see cref="IUIElementAdapter"/> and uses 
	/// the location of the wrapped tab to determine where new tabs are positioned.
	/// </summary>
	public class RibbonTabOwnerUIAdapter : RibbonTabsCollectionUIAdapter
	{
		#region Member Variables

		private RibbonTab tab;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="RibbonTabOwnerUIAdapter"/>
		/// </summary>
		/// <param name="tab">RibbonTab whose owning collection will be updated with any added elements.</param>
		public RibbonTabOwnerUIAdapter(RibbonTab tab)
			: base(tab.Ribbon.Tabs)
		{
			Guard.ArgumentNotNull(tab, "tab");

			this.tab = tab;
		}
		#endregion //Constructor

		#region Base class overrides

		#region Add
		/// <summary>
		/// Adds an <see cref="RibbonTab"/> to the <see cref="Ribbon"/> associated with the adapter.
		/// </summary>
		/// <param name="uiElement">RibbonTab to add to the ribbon</param>
		/// <returns>The tab that was added.</returns>
		protected override RibbonTab Add(RibbonTab uiElement)
		{
			RibbonTab newTab = base.Add(uiElement);

			// if the registered tab belongs to a contextual tab group then 
			// be sure to make any added tabs part of the contextual tab group
			newTab.ContextualTabGroup = this.tab.ContextualTabGroup;

			return newTab;
		}

		#endregion //Add

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which an group will be added.
		/// </summary>
		/// <param name="tab">Tab to evaluate</param>
		protected override int GetNewElementIndex(RibbonTab tab)
		{
			return this.Tabs.IndexOf(this.tab) + 1;
		}
		#endregion //GetNewElementIndex

		#endregion //Base class overrides
	}
}
