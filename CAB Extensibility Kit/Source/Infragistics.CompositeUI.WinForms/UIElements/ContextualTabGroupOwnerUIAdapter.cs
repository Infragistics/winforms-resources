using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="ContextualTabGroup"/> for use in adding <see cref="RibbonTab"/> instances to a particular <see cref="RibbonGroup"/> in <see cref="Ribbon"/>.
	/// </summary>
	public class ContextualTabGroupUIAdapter : UIElementAdapter<RibbonTab>
	{
		#region Member Variables

		private ContextualTabGroup tabGroup;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ContextualTabGroupUIAdapter"/>
		/// </summary>
		/// <param name="tabGroup">ContextualTabGroup represented by the ui adapter</param>
		public ContextualTabGroupUIAdapter(ContextualTabGroup tabGroup)
		{
			Guard.ArgumentNotNull(tabGroup, "tabGroup");

			this.tabGroup = tabGroup;
		}
		#endregion //Constructor

		#region Properties

		#region Items
		/// <summary>
		/// The <see cref="ContextualTabGroup"/> that is represented by the adapter.
		/// </summary>
		protected ContextualTabGroup TabGroup
		{
			get
			{
				return this.tabGroup;
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
			// first add it to the ribbon
			this.tabGroup.Ribbon.Tabs.Add(uiElement);

			// then make it part of this tab group
			this.tabGroup.Tabs.Add(uiElement);

			return uiElement;
		}

		#endregion //Add

		#region Remove
		/// <summary>
		/// Removes the specified <see cref="RibbonTab"/> from the associated <see cref="Ribbon"/>
		/// </summary>
		/// <param name="uiElement">Ribbon tab that should be removed.</param>
		protected override void Remove(RibbonTab uiElement)
		{
			if (this.tabGroup.Tabs.Contains(uiElement) == false)
				throw new ArgumentException(Properties.Resources.TabNotPartOfContextualTabGroup);

			// just remove it from the ribbon since that will synchronize the tab group
			this.tabGroup.Ribbon.Tabs.Remove(uiElement);
		}
		#endregion //Remove

		#endregion // Methods
	}
}
