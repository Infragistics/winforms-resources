using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Infragistics.Win.Design;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// Specialized <see cref="SmartPartInfo"/> that allows an <see cref="System.Drawing.Image"/> to be associated with the smart part when it is displayed by a <see cref="IWorkspace"/>
	/// </summary>
	public class ImageSmartPartInfo : SmartPartInfo
	{
		#region Member Variables

		private Image image;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes the smart part info without any values.
		/// </summary>
		public ImageSmartPartInfo() : base()
		{
		}

		/// <summary>
		/// Initializes the smart part info with the title and description values.
		/// </summary>
        /// <param name="title">Display name used by the <see cref="IWorkspace"/> for the associated smart part</param>
        /// <param name="description">String used to describe the associated smart part.</param>
        public ImageSmartPartInfo(string title, string description)
            : this(title, description, null)
		{
		}

		/// <summary>
		/// Initializes the smart part info with the title, description and image values.
		/// </summary>
        /// <param name="title">Display name used by the <see cref="IWorkspace"/> for the associated smart part</param>
        /// <param name="description">String used to describe the associated smart part.</param>
        /// <param name="image">Image displayed by the <see cref="IWorkspace"/> to represent the associated smart part.</param>
        public ImageSmartPartInfo(string title, string description, Image image)
            : base(title, description)
		{
			this.image = image;
		}
		#endregion //Constructor

		#region Properties
		/// <summary>
		/// Returns or sets the image that is displayed in associated with the smart part.
		/// </summary>
		[DefaultValue(null)]
		[Editor(typeof(ImageEditorEx), typeof(UITypeEditor))]
		[LocalizedDescription("Desc_ImageSmartPartInfo_Image")]
		[LocalizedCategory("Category_Appearance")]
		public Image Image
		{
			get { return this.image; }
			set { this.image = value; }
		}
		#endregion //Properties
	}
}
