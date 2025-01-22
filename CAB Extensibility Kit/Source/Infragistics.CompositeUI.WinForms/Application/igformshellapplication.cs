using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;

namespace Infragistics.Practices.CompositeUI.WinForms
{
    /// <summary>
    /// A CAB shell application class used to start an application using a specified Form.
    /// </summary>
    /// <typeparam name="TWorkItem">The type of the root application work item.</typeparam>
    /// <typeparam name="TShell">The type of the form for the shell to use.</typeparam>
    public class IGFormShellApplication<TWorkItem, TShell> : IGWindowsFormsApplicationBase<TWorkItem, TShell>
		where TWorkItem : WorkItem, new()
        where TShell : Form
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
