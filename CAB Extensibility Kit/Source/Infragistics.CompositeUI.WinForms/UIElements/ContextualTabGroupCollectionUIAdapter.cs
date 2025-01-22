using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="ContextualTabGroupCollection"/> for use as an <see cref="IUIElementAdapter"/>.
	/// </summary>
	public class ContextualTabGroupCollectionUIAdapter : UIElementAdapter<ContextualTabGroup>
	{
		#region Member Variables

		private ContextualTabGroupCollection groups;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ContextualTabGroupCollectionUIAdapter"/>
		/// </summary>
		/// <param name="groups">ContextualTabGroup collection represented by the ui adapter</param>
		public ContextualTabGroupCollectionUIAdapter(ContextualTabGroupCollection groups)
		{
			Guard.ArgumentNotNull(groups, "groups");

			this.groups = groups;
		}
		#endregion //Constructor

		#region Properties

		#region Items
		/// <summary>
		/// The <see cref="ContextualTabGroupCollection"/> that is represented by the adapter.
		/// </summary>
		protected ContextualTabGroupCollection Groups
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
		/// Adds an <see cref="ContextualTabGroup"/> to the <see cref="Ribbon"/> associated with the adapter.
		/// </summary>
		/// <param name="uiElement">ContextualTabGroup to add to the ribbon</param>
		/// <returns>The contextual tab group that was added.</returns>
		protected override ContextualTabGroup Add(ContextualTabGroup uiElement)
		{
			this.groups.Insert(this.GetNewElementIndex(uiElement), uiElement);
			return uiElement;
		}

		#endregion //Add

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which a contextual tab group will be added.
		/// </summary>
		/// <param name="contextual tab group">Tab to evaluate</param>
		/// <returns>By default, contextual tab groups are added at the end of the associated <see cref="Tabs"/> collection.</returns>
		protected virtual int GetNewElementIndex(ContextualTabGroup group)
		{
			return this.groups.Count;
		}
		#endregion //GetNewElementIndex

		#region Remove
		/// <summary>
		/// Removes the specified <see cref="ContextualTabGroup"/> from the associated <see cref="Ribbon"/>
		/// </summary>
		/// <param name="uiElement">Ribbon contextual tab group that should be removed.</param>
		protected override void Remove(ContextualTabGroup uiElement)
		{
			this.groups.Remove(uiElement);
		}
		#endregion //Remove

		#endregion // Methods
	}
}
