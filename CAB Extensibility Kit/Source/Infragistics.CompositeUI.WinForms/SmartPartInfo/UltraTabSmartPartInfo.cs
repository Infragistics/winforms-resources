using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// Provides smart part information for an <see cref="UltraTabSmartPartInfo"/>
	/// </summary>
	public class UltraTabSmartPartInfo : ImageSmartPartInfo
	{
		#region Member Variables

		private const bool ActivateTabDefault = true;
		private bool activateTab = ActivateTabDefault;

		#endregion // Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="UltraTabSmartPartInfo"/>
		/// </summary>
		public UltraTabSmartPartInfo()
			: base()
		{
		}
		#endregion // Constructor

		#region Properties

		/// <summary>
		/// Returns or sets whether the tab should be activated when the smart part is shown.
		/// </summary>
		[LocalizedCategory("Category_Behavior")]
		[DefaultValue(ActivateTabDefault)]
		[LocalizedDescription("Desc_UltraTabSmartPartInfo_ActivateTab")]
		public bool ActivateTab
		{
			get { return this.activateTab; }
			set { this.activateTab = value; }
		}

		#endregion // Properties
	}
}
