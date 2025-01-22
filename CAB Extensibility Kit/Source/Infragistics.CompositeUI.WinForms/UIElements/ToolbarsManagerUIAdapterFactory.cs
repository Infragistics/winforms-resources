using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.CompositeUI.UIElements;
using System.Diagnostics;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// A <see cref="IUIElementAdapterFactory"/> that produces adapters for UltraToolbarsManager-related UI Elements.
	/// </summary>
	public class ToolbarsManagerUIAdapterFactory : IUIElementAdapterFactory
	{
		#region GetAdapter
		/// <summary>
		/// Returns a <see cref="IUIElementAdapter"/> for the specified uielement.
		/// </summary>
		/// <remarks>
		/// <p class="body">The GetAdapter method can be used with any of the following items:</p>
		/// <list type="bullet">
		/// <item>
		///		<term>UltraToolbar</term>
		///		<description>Creates an adapter (<see cref="ToolsCollectionUIAdapter"/>) that adds ToolBase instances to the end of the toolbar's Tools collection.</description>
		/// </item>
		/// <item>
		///		<term>ApplicationMenuArea</term>
		///		<description>Creates an adapter (<see cref="ToolsCollectionUIAdapter"/>) that adds ToolBase instances to the end of the ApplicationMenuArea's Tools collection.</description>
		/// </item>
		/// <item>
		///		<term>ApplicationMenuFooterToolbar</term>
		///		<description>Creates an adapter (<see cref="ToolsCollectionUIAdapter"/>) that adds ToolBase instances to the end of the ApplicationMenuFooterToolbar's Tools collection.</description>
		/// </item>
		/// <item>
		///		<term>ToolsCollection</term>
		///		<description>Creates an adapter (<see cref="ToolsCollectionUIAdapter"/>) for the Tools collection of a UltraToolbarBase derived class, RibbonGroup, ApplicationMenuArea or PopupMenuTool that will add ToolBase instance to the end of the collection.</description>
		/// </item>
		/// <item>
		///		<term>ToolBase</term>
		///		<description>Creates an adapter (<see cref="ToolBaseOwnerUIAdapter"/>) that adds ToolBase instances in the owning Tools collection after the position at which the specified tool exists.</description>
		/// </item>
		/// <item>
		///		<term>Ribbon</term>
		///		<description>Create an adapter (<see cref="RibbonTabsCollectionUIAdapter"/>) that can be used to add RibbonTab instances to the Tabs collection of the specified Ribbon.</description>
		/// </item>
		/// <item>
		///		<term>RibbonTabCollection</term>
		///		<description>Creates an adapter (<see cref="RibbonTabsCollectionUIAdapter"/>) that can be used to add RibbonTab instances to the Ribbon.</description>
		/// </item>
		/// <item>
		///		<term>RibbonTab</term>
		///		<description>Creates an adapter (<see cref="RibbonTabOwnerUIAdapter"/>) that can be used to add RibbonTab instances to the ribbon at the position after the specified tab. If the tab belongs to a contextual tab group then the added tabs will be added to the same contextual tab group.</description>
		/// </item>
		/// <item>
		///		<term>RibbonGroupCollection</term>
		///		<description>Creates an adapter (<see cref="RibbonGroupsCollectionUIAdapter"/>) that can be used to add RibbonGroup instances to the specified groups collection.</description>
		/// </item>
		/// <item>
		///		<term>RibbonGroup</term>
		///		<description>Creates an adapter (<see cref="RibbonGroupOwnerUIAdapter"/>) that can be used to add RibbonGroup instances in the owning tab's Groups collection at the position directly after the specified group.</description>
		/// </item>
		/// <item>
		///		<term>ContextualTabGroup</term>
		///		<description>Creates an adapter (<see cref="ContextualTabGroupUIAdapter"/>) that can be used to add RibbonTab instances to the Ribbon's Tabs collection and also makes the RibbonTab part of the ContextualTab's Tabs collection.</description>
		/// </item>
		/// <item>
		///		<term>ContextualTabGroupCollection</term>
		///		<description>Creates an adapter (<see cref="ContextualTabGroupCollectionUIAdapter"/>) that can be used to add ContextualTabGroup instances to the Ribbon's contextual tab groups collection.</description>
		/// </item>
		/// <item>
		///		<term>MiniToolbar</term>
		///		<description>Creates an adapter (<see cref="ToolsCollectionUIAdapter"/>) that adds ToolBase instances to the end of the MiniToolbar's Tools collection.</description>
		/// </item>
		/// <item>
		///		<term>RibbonTabItemToolbar</term>
		///		<description>Creates an adapter (<see cref="ToolsCollectionUIAdapter"/>) that adds ToolBase instances to the end of the RibbonTabItemToolbar's Tools collection.</description>
		/// </item>
		/// <item>
		///		<term>QuickAccessToolbar</term>
		///		<description>Creates an adapter (<see cref="ToolsCollectionUIAdapter"/>) that adds ToolBase instances to the end of the QuickAccessToolbar's Tools collection.</description>
		/// </item>
		/// </list>
		/// </ul>
		/// </remarks>
		/// <param name="uiElement">ToolbarsManager related object for which to return a <see cref="IUIElementAdapter"/></param>
		/// <returns>A <see cref="IUIElementAdapter"/> that represents the specified object</returns>
		public IUIElementAdapter GetAdapter(object uiElement)
		{
			Guard.ArgumentNotNull(uiElement, "uiElement");

			if (uiElement is UltraTaskPaneToolbar)
			{
				throw ExceptionFactory.CreateInvalidElementHost(uiElement.GetType());
			}
			else if (uiElement is UltraToolbarBase)
			{
				Debug.Assert(uiElement is UltraToolbar ||
					uiElement is ApplicationMenuFooterToolbar ||
					uiElement is RibbonTabItemToolbar ||
					uiElement is MiniToolbar ||
					uiElement is QuickAccessToolbar, "Unexpected toolbar type");

				// AS 3/26/07 BR21000
				//return new ToolsCollectionUIAdapter( ((UltraToolbar)uiElement).Tools );
				return new ToolsCollectionUIAdapter( ((UltraToolbarBase)uiElement).Tools );
			}
			else if (uiElement is ApplicationMenuArea)
			{
				return new ToolsCollectionUIAdapter( ((ApplicationMenuArea)uiElement).Tools );
			}
			else if (uiElement is ToolsCollection)
			{
				return new ToolsCollectionUIAdapter( (ToolsCollection)uiElement );
			}
			else if (uiElement is ToolBase)
			{
				return new ToolBaseOwnerUIAdapter( (ToolBase)uiElement );
			}
			else if (uiElement is Ribbon)
			{
				return new RibbonTabsCollectionUIAdapter( ((Ribbon)uiElement).Tabs );
			}
			else if (uiElement is RibbonTabCollection)
			{
				return new RibbonTabsCollectionUIAdapter( ((RibbonTabCollection)uiElement) );
			}
			else if (uiElement is RibbonTab)
			{
				return new RibbonTabOwnerUIAdapter( ((RibbonTab)uiElement) );
			}
			else if (uiElement is RibbonGroupCollection)
			{
				return new RibbonGroupsCollectionUIAdapter( ((RibbonGroupCollection)uiElement) );
			}
			else if (uiElement is RibbonGroup)
			{
				return new RibbonGroupOwnerUIAdapter( ((RibbonGroup)uiElement) );
			}
			else if (uiElement is ContextualTabGroup)
			{
				return new ContextualTabGroupUIAdapter(((ContextualTabGroup)uiElement));
			}
			else if (uiElement is ContextualTabGroupCollection)
			{
				return new ContextualTabGroupCollectionUIAdapter( ((ContextualTabGroupCollection)uiElement) );
			}

			throw ExceptionFactory.CreateInvalidAdapterElementType(uiElement.GetType(), this.GetType());
		}
		#endregion //GetAdapter

		#region Supports
		/// <summary>
		/// Indicates if the specified ui element is supported by the adapter factory.
		/// </summary>
		/// <param name="uiElement">UI Element to evaluate</param>
		/// <returns>Returns true for <see cref="UltraToolbar"/> and <see cref="PopupMenuTool"/>, otherwise returns false.</returns>
		public bool Supports(object uiElement)
		{
			if (uiElement is UltraTaskPaneToolbar)
				return false;

			if (uiElement is ToolsCollection)
			{
				object owner = ((ToolsCollection)uiElement).Owner;

				if (owner is UltraTaskPaneToolbar)
					return false;

				return owner is UltraToolbarBase || 
					owner is RibbonGroup ||
					owner is ApplicationMenuArea ||
					owner is PopupMenuTool;
			}

			if (uiElement is TaskPaneTool)
				return false;

			return uiElement is UltraToolbarBase
				|| uiElement is ToolBase
				|| uiElement is Ribbon
				|| uiElement is RibbonTabCollection
				|| uiElement is RibbonTab
				|| uiElement is RibbonGroupCollection
				|| uiElement is RibbonGroup
				|| uiElement is ApplicationMenuArea
				|| uiElement is ContextualTabGroup
				|| uiElement is ContextualTabGroupCollection;
		}
		#endregion //Supports
	}
}
