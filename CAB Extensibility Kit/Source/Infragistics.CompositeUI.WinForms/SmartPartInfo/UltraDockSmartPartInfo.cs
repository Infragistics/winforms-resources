using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI.WinForms;
using Infragistics.Win.UltraWinDock;
using System.ComponentModel;
using System.Drawing;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// Provides smart part information for an <see cref="UltraDockWorkspace"/>
	/// </summary>
	public class UltraDockSmartPartInfo : ImageSmartPartInfo
	{
		#region Member Variables

		internal const ChildPaneStyle DefaultChildPaneStyle = ChildPaneStyle.TabGroup;
		internal const DockedLocation DefaultPaneLocation = DockedLocation.DockedLeft;

		private string preferredGroup;
		private DockedLocation defaultLocation = DefaultPaneLocation;
		private ChildPaneStyle defaultPaneStyle = DefaultChildPaneStyle;

		private Size preferredSize = Size.Empty; 

		#endregion // Member Variables

		#region Constructor
		/// <summary>
		/// Initializes the smart part info without any values.
		/// </summary>
		public UltraDockSmartPartInfo() : base()
		{
		}

		/// <summary>
		/// Initializes the smart part info with the title and description values.
		/// </summary>
		public UltraDockSmartPartInfo(string title, string description) : base(title, description)
		{
		}

		public UltraDockSmartPartInfo(string title, string description, 
            DockedLocation defaultLocation) : this(title, description)
		{
			this.defaultLocation = defaultLocation;
		}

		public UltraDockSmartPartInfo(string title, string description, 
            DockedLocation defaultLocation, string preferredGroup) : this(title, description, defaultLocation)
		{
			this.preferredGroup = preferredGroup;
		}

		public UltraDockSmartPartInfo(string title, string description, 
            DockedLocation defaultLocation, ChildPaneStyle defaultPaneStyle) : this(title, description, defaultLocation)
		{
			this.defaultPaneStyle = defaultPaneStyle;
		}

		public UltraDockSmartPartInfo(string title, string description, 
            DockedLocation defaultLocation, ChildPaneStyle defaultPaneStyle, 
            string preferredGroup) : this(title, description, defaultLocation, defaultPaneStyle)
		{
			this.preferredGroup = preferredGroup;
		}
		#endregion // Constructor

		#region Properties
		/// <summary>
		/// Returns or sets the key of the group to which the pane should be 
		/// added if the group already exists. Otherwise this is used to 
		/// initialize the key of the group to which the smart part will be added.
		/// </summary>
		[DefaultValue(null)]
		[LocalizedCategory("Category_Layout")]
		[LocalizedDescription("Desc_UltraDockSmartPartInfo_PreferredGroup")]
		public string PreferredGroup
		{
			get { return this.preferredGroup; }
			set { this.preferredGroup = value; }
		}

		/// <summary>
		/// Returns or sets the location at which the smart part should be positioned.
		/// </summary>
		/// <remarks>
		/// Note: This property is not used if the <see cref="PreferredGroup"/> is specified and exists.
		/// </remarks>
		[DefaultValue(DefaultPaneLocation)]
		[LocalizedCategory("Category_Layout")]
		[LocalizedDescription("Desc_UltraDockSmartPartInfo_DefaultLocation")]
		public DockedLocation DefaultLocation
		{
			get { return this.defaultLocation; }
			set { this.defaultLocation = value; }
		}

		/// <summary>
		/// Returns or sets the pane style of the group in which the pane will be added.
		/// </summary>
		/// <remarks>
		/// Note: This property is not used if the <see cref="PreferredGroup"/> is specified and exists.
		/// </remarks>
		[DefaultValue(DefaultChildPaneStyle)]
		[LocalizedCategory("Category_Layout")]
		[LocalizedDescription("Desc_UltraDockSmartPartInfo_DefaultPaneStyle")]
		public ChildPaneStyle DefaultPaneStyle
		{
			get { return this.defaultPaneStyle; }
			set { this.defaultPaneStyle = value; }
		}

		/// <summary>
		/// Returns or sets the preferred size for the control pane created for the smart part.
		/// </summary>
		[DefaultValue(typeof(Size), "")]
		[LocalizedCategory("Category_Layout")]
		[LocalizedDescription("Desc_UltraDockSmartPartInfo_PreferredSize")]
		public Size PreferredSize
		{
			get { return this.preferredSize; }
			set { this.preferredSize = value; }
		}
		#endregion // Properties
	}
}
