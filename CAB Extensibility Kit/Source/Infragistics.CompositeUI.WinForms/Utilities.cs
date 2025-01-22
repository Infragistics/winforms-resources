using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI;
using System.Drawing;
using Microsoft.Practices.CompositeUI.SmartParts;
using System.Windows.Forms;
using System.Reflection;
using Infragistics.Shared;
using System.Diagnostics;

namespace Infragistics.Practices.CompositeUI.WinForms
{
    internal static class Utilities
    {
		#region Output
		[Conditional("DEBUG")]
		internal static void Output(string message)
		{
			Debug.WriteLine(message, string.Empty);
		}

		[Conditional("DEBUG")]
		internal static void Output(string message, string category)
		{
			Debug.WriteLine(message, category);
		}

		[Conditional("DEBUG")]
		internal static void Output(string message, Control smartPart)
		{
			Output(message, (string)null, smartPart);
		}

		[Conditional("DEBUG")]
		internal static void Output(string message, string category, Control smartPart)
		{
			Output(string.Format("{0} - SmartPart={1}", message, smartPart), category);
		}

		[Conditional("DEBUG")]
		internal static void Output(string message, Control smartPart, ISmartPartInfo smartPartInfo)
		{
			Output(message, (string)null, smartPart, smartPartInfo);
		}

		[Conditional("DEBUG")]
		internal static void Output(string message, string category, Control smartPart, ISmartPartInfo smartPartInfo)
		{
			Output(string.Format("{0} - SmartPart={1}, Info={2}", message, smartPart, smartPartInfo), category);
		}

		#endregion //Output		
    }

	internal static class ExceptionFactory
	{
		public static Exception CreateInvalidAdapterElementType(Type elementType, Type factoryType)
		{
			return new ArgumentException(
				string.Format(Properties.Resources.ResourceManager.GetString("InvalidAdapterElementType"), 
					elementType.FullName, 
					factoryType.Name)
			);
		}

		public static Exception CreateInvalidElementHost(Type potentialElementHost)
		{
			return new ArgumentException(
				string.Format(Properties.Resources.ResourceManager.GetString("InvalidElementHost"),
					potentialElementHost.Name)
			);
		}
	}
}
