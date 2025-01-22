using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinExplorerBar;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="UltraExplorerBarGroupsCollection"/> for use as an <see cref="IUIElementAdapter"/>.
	/// </summary>
	public class ExplorerBarGroupsCollectionUIAdapter : UIElementAdapter<UltraExplorerBarGroup>
	{
		#region Member Variables

		private UltraExplorerBarGroupsCollection groups;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ExplorerBarItemsCollectionUIAdapter"/>
		/// </summary>
		/// <param name="groups">Groups collection represented by the ui adapter</param>
		public ExplorerBarGroupsCollectionUIAdapter(UltraExplorerBarGroupsCollection groups)
		{
			Guard.ArgumentNotNull(groups, "groups");

			this.groups = groups;
		}
		#endregion //Constructor

		#region Properties

		#region Items
		/// <summary>
		/// The <see cref="UltraExplorerBarGroupsCollection"/> that is represented by the adapter.
		/// </summary>
		protected UltraExplorerBarGroupsCollection Groups
		{
			get { return this.groups; }
		}
		#endregion //Items

		#endregion //Properties

		#region Methods

		#region Add
		/// <summary>
		/// Adds an <see cref="UltraExplorerBarItem"/> to the <see cref="UltraExplorerBarGroup"/> associated with the adapter.
		/// </summary>
		/// <param name="uiElement">ExplorerBar group to add to the group</param>
		/// <returns>The group that was added.</returns>
		protected override UltraExplorerBarGroup Add(UltraExplorerBarGroup uiElement)
		{
			this.groups.Insert(this.GetNewElementIndex(uiElement), uiElement);
			return uiElement;
		}

		#endregion //Add

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which a group will be added.
		/// </summary>
		/// <param name="item">Group to evaluate</param>
		/// <returns>By default, groups are added at the end of the associated <see cref="Groups"/> collection.</returns>
		protected virtual int GetNewElementIndex(UltraExplorerBarGroup group)
		{
			return this.groups.Count;
		}
		#endregion //GetNewElementIndex

		#region Remove
		/// <summary>
		/// Removes the specified <see cref="UltraExplorerBarGroup"/> from the associated <see cref="UltraExplorerBar"/>
		/// </summary>
		/// <param name="uiElement">ExplorerBar group that should be removed.</param>
		protected override void Remove(UltraExplorerBarGroup uiElement)
		{
			this.groups.Remove(uiElement);
		}
		#endregion //Remove

		#endregion // Methods
	}
}
