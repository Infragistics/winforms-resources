using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.WinForms;
using Infragistics.Win;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinStatusBar;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Practices.CompositeUI.WinForms.Commands;
using Infragistics.Practices.CompositeUI.WinForms.UIElements;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// Defines an abstact cab application which shows a shell based on a Form that uses Infragistics WinForms components.
	/// </summary>
	/// <typeparam name="TWorkItem">The type of the root application work item.</typeparam>
	/// <typeparam name="TShell">The type for the shell to use.</typeparam>
    public abstract class IGWindowsFormsApplicationBase<TWorkItem, TShell> : WindowsFormsApplication<TWorkItem, TShell>
		where TWorkItem : WorkItem, new()
	{
        #region Constructor
        /// <summary>
        /// Initializes a new <see cref="IGWindowsFormsApplicationBase"/>
        /// </summary>
        protected IGWindowsFormsApplicationBase()
            : base()
        {
			// We could allow the default to be controlled here.
			//Infragistics.Win.DrawUtility.UseGDIPlusTextRendering = true;
        }

        #endregion //Constructor

        #region Base Class Overrides

        #region AddBuilderStrategies
        /// <summary>
        /// Added Windows Forms specific strategies to the builder.
        /// </summary>
        protected override void AddBuilderStrategies(Builder builder)
        {
            base.AddBuilderStrategies(builder);

            // add strategies...

			// add a strategy that will register our workspaces, etc.
			builder.Strategies.AddNew<IGWorkItemStrategy>(BuilderStage.Initialization);

			// if ink should be supported by the application then we
			// should add the builder that will create the ink providers
			// for the application.
			if (this.ProvideInkSupportResolved)
			{
				builder.Strategies.AddNew<InkProviderStrategy>(BuilderStage.Initialization);
			}
        }
        #endregion //AddBuilderStrategies

        #region AfterShellCreated
        /// <summary>
        /// See <see cref="CabShellApplication{T,S}.AfterShellCreated"/>
        /// </summary>
        protected override void AfterShellCreated()
        {
            base.AfterShellCreated();

			// register the command adapters
            ICommandAdapterMapService mapService = this.RootWorkItem.Services.Get<ICommandAdapterMapService>();

			mapService.Register(typeof(ToolBase), typeof(ToolBaseCommandAdapter));
			mapService.Register(typeof(UltraExplorerBarItem), typeof(ExplorerBarCommandAdapter));
			mapService.Register(typeof(UltraStatusPanel), typeof(StatusPanelCommandAdapter));
			mapService.Register(typeof(UltraExplorerBarGroup), typeof(ExplorerBarGroupCommandAdapter));

			// register the uiadapter factories
			IUIElementAdapterFactoryCatalog catalog = this.RootWorkItem.Services.Get<IUIElementAdapterFactoryCatalog>();
			catalog.RegisterFactory(new ExplorerBarUIAdapterFactory());
			catalog.RegisterFactory(new StatusBarUIAdapterFactory());
			catalog.RegisterFactory(new ToolbarsManagerUIAdapterFactory());
			catalog.RegisterFactory(new TreeUIAdapterFactory());
		}
        #endregion //AfterShellCreated

        #endregion //Base Class Overrides

		#region Properties

		#region ProvideInkSupport
		/// <summary>
		/// Indicates if the application should automatically provide ink enabled functionality 
		/// to the usercontrols and forms within the application.
		/// </summary>
		/// <remarks>
		/// <p class="body">By default, ink functionality will be enabled if ink recognition is supported.</p>
		/// </remarks>
		protected virtual ShowInkButton ProvideInkSupport
		{
			get { return ShowInkButton.Default; }
		} 

		/// <summary>
		/// Returns the resolved value for whether ink support should be extended to the application.
		/// </summary>
		protected bool ProvideInkSupportResolved
		{
			get
			{
				switch (this.ProvideInkSupport)
				{
					case ShowInkButton.Always:
						return InkProviderStrategy.IsInkAssemblyLoaded;
					case ShowInkButton.Never:
						return false;
					default:
					case ShowInkButton.WhenInkAvailable:
						return InkProviderStrategy.IsInkRecognitionAvailable;
				}
			}
		}
		#endregion //ProvideInkSupport

		#endregion //Properties    
	}
}