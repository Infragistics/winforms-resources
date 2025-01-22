using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinExplorerBar;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="UltraExplorerBarGroupsCollection"/> for use as an <see cref="IUIElementAdapter"/> and uses 
	/// the location of the wrapped group to determine where new groups are positioned.
	/// </summary>
	public class ExplorerBarGroupOwnerUIAdapter : ExplorerBarGroupsCollectionUIAdapter
	{
		#region Member Variables

		private UltraExplorerBarGroup group;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ExplorerBarGroupOwnerUIAdapter"/>
		/// </summary>
		/// <param name="group">Group whose owning collection will be updated with any added elements.</param>
		public ExplorerBarGroupOwnerUIAdapter(UltraExplorerBarGroup group)
			: base(group.ExplorerBar.Groups)
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
		/// <returns>By default, groups are added at the end of the associated <see cref="Groups"/> collection.</returns>
		protected override int GetNewElementIndex(UltraExplorerBarGroup group)
		{
			return this.Groups.IndexOf(this.group) + 1;
		}
		#endregion //GetNewElementIndex

		#endregion //Base class overrides
	}
}
