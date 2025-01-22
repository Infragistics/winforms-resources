using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="RibbonGroupCollection"/> for use as an <see cref="IUIElementAdapter"/> and uses 
	/// the location of the wrapped tab to determine where new groups are positioned.
	/// </summary>
	public class RibbonGroupOwnerUIAdapter : RibbonGroupsCollectionUIAdapter
	{
		#region Member Variables

		private RibbonGroup group;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="RibbonGroupOwnerUIAdapter"/>
		/// </summary>
		/// <param name="group">RibbonGroup whose owning collection will be updated with any added elements.</param>
		public RibbonGroupOwnerUIAdapter(RibbonGroup group)
			: base(group.Tab.Groups)
		{
			Guard.ArgumentNotNull(group, "group");

			this.group = group;
		}
		#endregion //Constructor

		#region Base class overrides

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which an group will be added.
		/// </summary>
		/// <param name="group">Group to evaluate</param>
		protected override int GetNewElementIndex(RibbonGroup group)
		{
			return this.Groups.IndexOf(this.group) + 1;
		}
		#endregion //GetNewElementIndex

		#endregion //Base class overrides
	}
}
