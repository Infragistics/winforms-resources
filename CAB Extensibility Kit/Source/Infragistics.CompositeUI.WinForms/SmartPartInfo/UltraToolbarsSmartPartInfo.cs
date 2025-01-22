using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using System.ComponentModel;
using Infragistics.Win;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// Provides smart part information for an <see cref="UltraToolbarsManagerWorkspace"/>
	/// </summary>
	public class UltraToolbarsSmartPartInfo : ImageSmartPartInfo
	{
		#region Member Variables

		internal const DockedPosition DefaultDockedPosition = DockedPosition.Right;
		internal const int DefaultExtent = 0;

		private DockedPosition preferredDockedPosition = DefaultDockedPosition;
		private string preferredTaskPane = null;
		private int preferredExtent = DefaultExtent;
		private string headerCaption = null;
		private TaskPaneToolResizeMode resizeMode = TaskPaneToolResizeMode.Default;
		private NavigationButtonStyle preferredNavigationStyle = NavigationButtonStyle.Default;
		private DefaultableBoolean preferredShowHomeButton = DefaultableBoolean.Default;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="UltraToolbarsSmartPartInfo"/>
		/// </summary>
		public UltraToolbarsSmartPartInfo()
		{
		} 
		#endregion //Constructor

		#region Properties
		/// <summary>
		/// Returns or sets the docked position of the taskpane that will be added.
		/// </summary>
		/// <remarks>
		/// Note: This property is not used if the <see cref="PreferredTaskPane"/> is specified and exists.
		/// </remarks>
		[DefaultValue(DefaultDockedPosition)]
		[LocalizedCategory("Category_Layout")]
		[LocalizedDescription("Desc_UltraToolbarsSmartPartInfo_PreferredDockedLocation")]
		public DockedPosition PreferredDockedPosition
		{
			get { return this.preferredDockedPosition; }
			set { this.preferredDockedPosition = value; }
		}

		/// <summary>
		/// Returns or sets the navigation button style of the taskpane toolbar that is created.
		/// </summary>
		/// <remarks>
		/// Note: This property is not used if the <see cref="PreferredTaskPane"/> is specified and exists.
		/// </remarks>
		[DefaultValue(NavigationButtonStyle.Default)]
		[LocalizedCategory("Category_Appearance")]
		[LocalizedDescription("Desc_UltraToolbarsSmartPartInfo_PreferredNavigationStyle")]
		public NavigationButtonStyle PreferredNavigationStyle
		{
			get { return this.preferredNavigationStyle; }
			set { this.preferredNavigationStyle = value; }
		}

		/// <summary>
		/// Returns or sets whether the home button will be displayed in the taskpane toolbar that is created.
		/// </summary>
		/// <remarks>
		/// Note: This property is not used if the <see cref="PreferredTaskPane"/> is specified and exists.
		/// </remarks>
		[DefaultValue(DefaultableBoolean.Default)]
		[LocalizedCategory("Category_Appearance")]
		[LocalizedDescription("Desc_UltraToolbarsSmartPartInfo_PreferredShowHomeButton")]
		public DefaultableBoolean PreferredShowHomeButton
		{
			get { return this.preferredShowHomeButton; }
			set { this.preferredShowHomeButton = value; }
		}

		/// <summary>
		/// Returns or sets the key of the task pane tool to which the task pane tool should be 
		/// added if the task pane already exists. Otherwise this is used to 
		/// initialize the key of the task pane to which the smart part will be added.
		/// </summary>
		[DefaultValue(null)]
		[LocalizedCategory("Category_Layout")]
		[LocalizedDescription("Desc_UltraToolbarsSmartPartInfo_PreferredTaskPane")]
		public string PreferredTaskPane
		{
			get { return this.preferredTaskPane; }
			set { this.preferredTaskPane = value; }
		}

		/// <summary>
		/// Returns or sets the preferred extent of the task pane toolbar that will be created 
		/// for the tool.
		/// </summary>
		/// <remarks>
		/// Note: This property is not used if the <see cref="PreferredTaskPane"/> is specified and exists.
		/// </remarks>
		[LocalizedCategory("Category_Layout")]
		[LocalizedDescription("Desc_UltraToolbarsSmartPartInfo_PreferredExtent")]
		public int PreferredExtent
		{
			get { return this.preferredExtent; }
			set { this.preferredExtent = value; }
		}

		/// <summary>
		/// Returns or sets the caption that is assigned to the <b>HeaderCaption</b> property of the <b>TaskPaneTool</b> that is created for the smart part.
		/// </summary>
		[DefaultValue(null)]
		[LocalizedCategory("Category_Appearance")]
		[LocalizedDescription("Desc_UltraToolbarsSmartPartInfo_HeaderCaption")]
		public string HeaderCaption
		{
			get { return this.headerCaption; }
			set { this.headerCaption = value; }
		}

		/// <summary>
		/// Returns or sets a value indicating how the smart part should be resized when the tool is selected and when the containing <see cref="UltraTaskPaneToolbar"/> is resized while the tool is selected.
		/// </summary>
		[DefaultValue(TaskPaneToolResizeMode.Default)]
		[LocalizedCategory("Category_Behavior")]
		[LocalizedDescription("Desc_UltraToolbarsSmartPartInfo_ResizeMode")]
		public TaskPaneToolResizeMode ResizeMode
		{
			get { return this.resizeMode; }
			set { this.resizeMode = value; }
		}
		#endregion //Properties
	}
}
