using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinTree;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// A <see cref="IUIElementAdapterFactory"/> that produces adapters for UltraTree-related UI Elements.
	/// </summary>
	public class TreeUIAdapterFactory : IUIElementAdapterFactory
	{
		#region GetAdapter
		/// <summary>
		/// Returns a <see cref="IUIElementAdapter"/> for the specified uielement.
		/// </summary>
		/// <param name="uiElement">UltraToolbar or PopupMenuTool for which to return a <see cref="IUIElementAdapter"/></param>
		/// <returns>A <see cref="IUIElementAdapter"/> that represents the specified <see cref="UltraToolbar"/> or <see cref="PopupMenuTool"/></returns>
		public IUIElementAdapter GetAdapter(object uiElement)
		{
			Guard.ArgumentNotNull(uiElement, "uiElement");

			if (uiElement is TreeNodesCollection)
			{
				return new TreeNodesCollectionUIAdapter( (TreeNodesCollection)uiElement );
			}
			if (uiElement is UltraTree)
			{
				return new TreeNodesCollectionUIAdapter( ((UltraTree)uiElement).Nodes );
			}
			else if (uiElement is UltraTreeNode)
			{
				return new TreeNodeOwnerUIAdapter((UltraTreeNode)uiElement);
			}

			throw ExceptionFactory.CreateInvalidAdapterElementType(uiElement.GetType(), this.GetType());
		}
		#endregion //GetAdapter

		#region Supports
		/// <summary>
		/// Indicates if the specified ui element is supported by the adapter factory.
		/// </summary>
		/// <param name="uiElement">UI Element to evaluate</param>
		/// <returns>Returns true for <see cref="TreeNodesCollection"/> and <see cref="UltraTreeNode"/>, otherwise returns false.</returns>
		public bool Supports(object uiElement)
		{
			return uiElement is TreeNodesCollection ||
				uiElement is UltraTree				||
				uiElement is UltraTreeNode;
		}
		#endregion //Supports
	}
}
