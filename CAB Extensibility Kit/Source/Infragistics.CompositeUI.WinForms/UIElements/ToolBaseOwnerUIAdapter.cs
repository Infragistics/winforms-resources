using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="ToolsCollection"/> for use as an <see cref="IUIElementAdapter"/> and uses 
	/// the location of the wrapped tool to determine where new items are positioned.
	/// </summary>
	public class ToolBaseOwnerUIAdapter : ToolsCollectionUIAdapter
	{
		#region Member Variables

		private ToolBase tool;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="ToolsCollectionUIAdapter"/>
		/// </summary>
		/// <param name="tool">Tool whose owning collection will be updated with any added elements.</param>
		public ToolBaseOwnerUIAdapter(ToolBase tool) : base(tool.ParentCollection)
		{
			Guard.ArgumentNotNull(tool, "tool");
			
			if (tool is TaskPaneTool)
				throw new ArgumentException(Properties.Resources.CannotAcceptTaskPaneTool, "tools");

			this.tool = tool;
		}
		#endregion //Constructor

		#region Base class overrides

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which an item will be added.
		/// </summary>
		/// <param name="tool">Tool to evaluate</param>
		/// <returns>By default, tools are added at the end of the associated <see cref="Tools"/> collection.</returns>
		protected override int GetNewElementIndex(ToolBase tool)
		{
			return this.Tools.IndexOf(this.tool) + 1;
		}
		#endregion //GetNewElementIndex

		#endregion //Base class overrides
	}
}
