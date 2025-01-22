using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinStatusBar;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="UltraStatusPanelsCollection"/> for use as an <see cref="IUIElementAdapter"/> and uses 
	/// the location of the wrapped panel to determine where new items are positioned.
	/// </summary>
	public class StatusPanelOwnerUIAdapter : StatusPanelsCollectionUIAdapter
	{
		#region Member Variables

		private UltraStatusPanel panel;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="StatusPanelOwnerUIAdapter"/>
		/// </summary>
		/// <param name="panel">Panel whose owning collection will be updated with any added elements.</param>
		public StatusPanelOwnerUIAdapter(UltraStatusPanel panel)
			: base(panel.UltraStatusBar.Panels)
		{
			Guard.ArgumentNotNull(panel, "panel");

			this.panel = panel;
		}
		#endregion //Constructor

		#region Base class overrides

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which an item will be added.
		/// </summary>
		/// <param name="panel">Panel to evaluate</param>
		/// <returns>By default, panels are added at the end of the associated <see cref="Panels"/> collection.</returns>
		protected override int GetNewElementIndex(UltraStatusPanel panel)
		{
			return this.Panels.IndexOf(this.panel) + 1;
		}
		#endregion //GetNewElementIndex

		#endregion //Base class overrides
	}
}
