using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="RibbonTabCollection"/> for use as an <see cref="IUIElementAdapter"/>.
	/// </summary>
	public class RibbonTabsCollectionUIAdapter : UIElementAdapter<RibbonTab>
	{
		#region Member Variables

		private RibbonTabCollection tabs;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="RibbonTabCollectionUIAdapter"/>
		/// </summary>
		/// <param name="tabs">Tabs collection represented by the ui adapter</param>
		public RibbonTabsCollectionUIAdapter(RibbonTabCollection tabs)
		{
			Guard.ArgumentNotNull(tabs, "tabs");

			this.tabs = tabs;
		}
		#endregion //Constructor

		#region Properties

		#region Items
		/// <summary>
		/// The <see cref="RibbonTabCollection"/> that is represented by the adapter.
		/// </summary>
		protected RibbonTabCollection Tabs
		{
			get
			{
				return this.tabs;
			}
		}
		#endregion //Items

		#endregion //Properties

		#region Methods

		#region Add
		/// <summary>
		/// Adds an <see cref="RibbonTab"/> to the <see cref="Ribbon"/> associated with the adapter.
		/// </summary>
		/// <param name="uiElement">RibbonTab to add to the ribbon</param>
		/// <returns>The tab that was added.</returns>
		protected override RibbonTab Add(RibbonTab uiElement)
		{
			this.tabs.Insert(this.GetNewElementIndex(uiElement), uiElement);
			return uiElement;
		}

		#endregion //Add

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which a tab will be added.
		/// </summary>
		/// <param name="tab">Tab to evaluate</param>
		/// <returns>By default, tabs are added at the end of the associated <see cref="Tabs"/> collection.</returns>
		protected virtual int GetNewElementIndex(RibbonTab tab)
		{
			return this.tabs.Count;
		}
		#endregion //GetNewElementIndex

		#region Remove
		/// <summary>
		/// Removes the specified <see cref="RibbonTab"/> from the associated <see cref="Ribbon"/>
		/// </summary>
		/// <param name="uiElement">Ribbon tab that should be removed.</param>
		protected override void Remove(RibbonTab uiElement)
		{
			this.tabs.Remove(uiElement);
		}
		#endregion //Remove

		#endregion // Methods
	}
}
