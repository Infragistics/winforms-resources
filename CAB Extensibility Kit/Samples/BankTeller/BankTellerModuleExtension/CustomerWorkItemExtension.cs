using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI;
using BankTellerModule;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.SmartParts;
using System.Windows.Forms;
using BankTellerCommon;
using Microsoft.Practices.CompositeUI.UIElements;
using Infragistics.Practices.CompositeUI.WinForms;

namespace CustomerMapExtensionModule
{
	[WorkItemExtension(typeof(CustomerWorkItem))]
	public class CustomerWorkItemExtension : WorkItemExtension
	{
		private CustomerMap mapView;

		protected override void OnActivated()
		{
			if (mapView == null)
			{
				mapView = WorkItem.Items.AddNew<CustomerMap>();

				UltraTabSmartPartInfo info = new UltraTabSmartPartInfo();
				info.Title = "Customer Map";
				info.Description = "Map of the customer location";
				WorkItem.Workspaces[CustomerWorkItem.CUSTOMERDETAIL_TABWORKSPACE].Show(mapView, info);
			}
		}
	}
}
