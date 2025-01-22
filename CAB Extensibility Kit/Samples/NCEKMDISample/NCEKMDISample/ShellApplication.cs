using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI;
using Infragistics.Practices.CompositeUI.WinForms;

namespace NCEKMDISample {
    public class ShellApplication : IGFormShellApplication<WorkItem, frmShell> {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            new ShellApplication().Run();
        }

        /// <summary>
        /// This is where we register our UIElements.  Considering our UltraToolbarsManager is also
        /// a workspace, we don't necessarily need to register it here, as our hierarchy of
        /// workitems\workspaces isn't very deep.  However, in more complex applications, registering
        /// the tools collections of toolbars on the ToolbarsManager will make it easier to access.
        /// </summary>
        protected override void AfterShellCreated() {
            base.AfterShellCreated();

            //Register all known sites:
            this.RootWorkItem.UIExtensionSites.RegisterSite("Status", Shell.ultraStatusBar1.Panels);
            this.RootWorkItem.UIExtensionSites.RegisterSite("Menus", Shell.ultraToolbarsManagerWorkspace1.Toolbars["Context"].Tools);
        }
    }
}