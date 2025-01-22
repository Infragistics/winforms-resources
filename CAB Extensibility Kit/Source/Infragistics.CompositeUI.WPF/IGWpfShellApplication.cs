using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Infragistics.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.WPF.BuilderStrategies;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.WPF;
using Microsoft.Practices.CompositeUI;

namespace Infragistics.Practices.CompositeUI.WPF
{
	/// <summary>
	/// Extends the <see cref="IGFormShellApplication<TWorkItem, TShell>"/> to support an application which uses 
	/// Infragistics controls in a Windows Forms <see cref="Form"/> as its shell and WPF views.
	/// </summary>
	/// <typeparam name="TWorkItem"></typeparam>
	/// <typeparam name="TShell"></typeparam>
	public abstract class IGWpfShellApplication<TWorkItem, TShell> : IGFormShellApplication<TWorkItem, TShell>
		where TWorkItem : WorkItem, new()
		where TShell : Form
	{
		/// <summary>
		/// Adds the <see cref="WPFControlSmartPartStrategy"/> Builder Strategy.
		/// </summary>
		protected override void AddBuilderStrategies(Microsoft.Practices.ObjectBuilder.Builder builder)
		{
			base.AddBuilderStrategies(builder);
			builder.Strategies.AddNew<WPFControlSmartPartStrategy>(BuilderStage.Initialization);
		}

		/// <summary>
		/// Adds the <see cref="WPFUIElementAdapter"/> service to the RootWorkItem.
		/// </summary>
		protected override void AddServices()
		{
			base.AddServices();
			RootWorkItem.Services.AddNew<WPFUIElementAdapter, IWPFUIElementAdapter>();
		}
	}
}
