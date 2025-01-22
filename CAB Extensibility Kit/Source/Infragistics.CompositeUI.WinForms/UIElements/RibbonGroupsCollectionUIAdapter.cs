using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="RibbonGroupCollection"/> for use as an <see cref="IUIElementAdapter"/>.
	/// </summary>
	public class RibbonGroupsCollectionUIAdapter : UIElementAdapter<RibbonGroup>
	{
		#region Member Variables

		private RibbonGroupCollection groups;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="RibbonGroupCollectionUIAdapter"/>
		/// </summary>
		/// <param name="groups">Groups collection represented by the ui adapter</param>
		public RibbonGroupsCollectionUIAdapter(RibbonGroupCollection groups)
		{
			Guard.ArgumentNotNull(groups, "groups");

			this.groups = groups;
		}
		#endregion //Constructor

		#region Properties

		#region Items
		/// <summary>
		/// The <see cref="RibbonGroupCollection"/> that is represented by the adapter.
		/// </summary>
		protected RibbonGroupCollection Groups
		{
			get
			{
				return this.groups;
			}
		}
		#endregion //Items

		#endregion //Properties

		#region Methods

		#region Add
		/// <summary>
		/// Adds an <see cref="RibbonGroup"/> to the <see cref="Ribbon"/> associated with the adapter.
		/// </summary>
		/// <param name="uiElement">RibbonGroup to add to the ribbon</param>
		/// <returns>The group that was added.</returns>
		protected override RibbonGroup Add(RibbonGroup uiElement)
		{
			this.groups.Insert(this.GetNewElementIndex(uiElement), uiElement);
			return uiElement;
		}

		#endregion //Add

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which a group will be added.
		/// </summary>
		/// <param name="group">Group to evaluate</param>
		/// <returns>By default, groups are added at the end of the associated <see cref="Groups"/> collection.</returns>
		protected virtual int GetNewElementIndex(RibbonGroup group)
		{
			return this.groups.Count;
		}
		#endregion //GetNewElementIndex

		#region Remove
		/// <summary>
		/// Removes the specified <see cref="RibbonGroup"/> from the associated <see cref="Ribbon"/>
		/// </summary>
		/// <param name="uiElement">Ribbon group that should be removed.</param>
		protected override void Remove(RibbonGroup uiElement)
		{
			this.groups.Remove(uiElement);
		}
		#endregion //Remove

		#endregion // Methods
	}
}
