using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinStatusBar;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.CompositeUI.UIElements;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// A <see cref="IUIElementAdapterFactory"/> that produces adapters for UltraStatusBar-related UI Elements.
	/// </summary>
	public class StatusBarUIAdapterFactory : IUIElementAdapterFactory
	{
		#region GetAdapter
		/// <summary>
		/// Returns a <see cref="IUIElementAdapter"/> for the specified uielement.
		/// </summary>
		/// <param name="uiElement">UltraStatusBar for which to return a <see cref="IUIElementAdapter"/></param>
		/// <returns>A <see cref="IUIElementAdapter"/> that represents the specified <see cref="UltraStatusBar"/></returns>
		public IUIElementAdapter GetAdapter(object uiElement)
		{
			Guard.ArgumentNotNull(uiElement, "uiElement");

			if (uiElement is UltraStatusBar)
				return new StatusPanelsCollectionUIAdapter(((UltraStatusBar)uiElement).Panels);
			else if (uiElement is UltraStatusPanelsCollection)
				return new StatusPanelsCollectionUIAdapter((UltraStatusPanelsCollection)uiElement);
			else if (uiElement is UltraStatusPanel)
				return new StatusPanelOwnerUIAdapter((UltraStatusPanel)uiElement);

			throw ExceptionFactory.CreateInvalidAdapterElementType(uiElement.GetType(), this.GetType());
		}
		#endregion //GetAdapter

		#region Supports
		/// <summary>
		/// Indicates if the specified ui element is supported by the adapter factory.
		/// </summary>
		/// <param name="uiElement">UI Element to evaluate</param>
		/// <returns>Returns true for <see cref="UltraStatusBar"/>, <see cref="UltraStatusPanelsCollection"/>, and <see cref="UltraStatusPanel"/> otherwise returns false.</returns>
		public bool Supports(object uiElement)
		{
			return uiElement is UltraStatusPanelsCollection ||
				uiElement is UltraStatusBar ||
				uiElement is UltraStatusPanel;
		}
		#endregion //Supports
	}

}
