using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI;
using System.Windows.Forms;

namespace Infragistics.Practices.CompositeUI.WinForms
{
    /// <summary>
    /// A CAB shell application class used to start an application using a specified ApplicationContext.
    /// </summary>
    /// <typeparam name="TWorkItem">The type of the root application work item.</typeparam>
    /// <typeparam name="TShell">The type of the <see cref="ApplicationContext"/> for the shell to use.</typeparam>
    public class IGApplicationContextApplication<TWorkItem, TShell> : IGWindowsFormsApplicationBase<TWorkItem, TShell>
        where TWorkItem : WorkItem, new()
        where TShell : ApplicationContext
    {
        #region Start
        /// <summary>
        /// Used to start a message pump using the specified shell form.
        /// </summary>
        protected override void Start()
        {
            Application.Run(this.Shell);
        }
        #endregion // Start
    }
}
