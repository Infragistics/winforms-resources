using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	#region LocalizedCategoryAttribute

	internal class LocalizedCategoryAttribute : CategoryAttribute
	{
		public LocalizedCategoryAttribute(string resourceName)
			: base(resourceName)
		{
		}

		protected override string GetLocalizedString(string value)
		{
			return Properties.Resources.ResourceManager.GetString(value);
		}
	}
	#endregion //LocalizedCategoryAttribute

	#region LocalizedDescriptionAttribute

	internal class LocalizedDescriptionAttribute : DescriptionAttribute
	{
		public LocalizedDescriptionAttribute(string resourceName)
			: base(resourceName)
		{
		}

		public override string Description
		{
			get
			{
				return Properties.Resources.ResourceManager.GetString(base.DescriptionValue);
			}
		}
	}
	#endregion //LocalizedDescriptionAttribute
}
