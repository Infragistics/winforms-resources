using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI.UIElements;
using Infragistics.Win.UltraWinExplorerBar;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
    /// <summary>
    /// A <see cref="IUIElementAdapterFactory"/> that produces adapters for UltraExplorerBar-related UI Elements.
    /// </summary>
	public class ExplorerBarUIAdapterFactory : IUIElementAdapterFactory
	{
		#region GetAdapter
		/// <summary>
		/// Returns a <see cref="IUIElementAdapter"/> for the specified uielement.
		/// </summary>
		/// <param name="uiElement">UltraExplorerBarGroup for which to return a <see cref="IUIElementAdapter"/></param>
		/// <returns>A <see cref="IUIElementAdapter"/> that represents the specified <see cref="UltraExplorerBarGroup"/></returns>
		public IUIElementAdapter GetAdapter(object uiElement)
		{
			Guard.ArgumentNotNull(uiElement, "uiElement");

			if (uiElement is UltraExplorerBarItemsCollection)
				return new ExplorerBarItemsCollectionUIAdapter((UltraExplorerBarItemsCollection)uiElement);
			if (uiElement is UltraExplorerBarItem)
				return new ExplorerBarItemOwnerUIAdapter( ((UltraExplorerBarItem)uiElement) );
			if (uiElement is UltraExplorerBar)
				return new ExplorerBarGroupsCollectionUIAdapter( ((UltraExplorerBar)uiElement).Groups );
			if (uiElement is UltraExplorerBarGroup)
				return new ExplorerBarGroupOwnerUIAdapter( ((UltraExplorerBarGroup)uiElement) );

			throw ExceptionFactory.CreateInvalidAdapterElementType(uiElement.GetType(), this.GetType());
		} 
		#endregion //GetAdapter

		#region Supports
		/// <summary>
		/// Indicates if the specified ui element is supported by the adapter factory.
		/// </summary>
		/// <param name="uiElement">UI Element to evaluate</param>
		/// <returns>Returns true for <see cref="UltraExplorerBarGroup"/>, otherwise returns false.</returns>
		public bool Supports(object uiElement)
		{
			return uiElement is UltraExplorerBar				||
				uiElement is UltraExplorerBarGroup				||
				uiElement is UltraExplorerBarItemsCollection	||
				uiElement is UltraExplorerBarItem;
		} 
		#endregion //Supports
	}
}
