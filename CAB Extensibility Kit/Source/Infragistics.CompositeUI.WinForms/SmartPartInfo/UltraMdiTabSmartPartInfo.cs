using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// Provides smart part information for an <see cref="UltraMdiTabWorkspace"/>
	/// </summary>
	public class UltraMdiTabSmartPartInfo : ImageSmartPartInfo
	{
		#region Member Variables

		private string preferredGroup = null;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="UltraMdiTabSmartPartInfo"/>
		/// </summary>
		public UltraMdiTabSmartPartInfo()
		{
		} 
		#endregion //Constructor

		#region Properties

		/// <summary>
		/// Returns or sets the key of the MdiTabGroup to which the control should be 
		/// added if the tab group already exists. Otherwise this is used to 
		/// initialize the key of the tab group to which the smart part will be added.
		/// </summary>
		[DefaultValue(null)]
		[LocalizedCategory("Category_Layout")]
		[LocalizedDescription("Desc_UltraMdiTabSmartPartInfo_PreferredGroup")]
		public string PreferredGroup
		{
			get { return this.preferredGroup; }
			set { this.preferredGroup = value; }
		} 
		#endregion //Properties
	}
}
