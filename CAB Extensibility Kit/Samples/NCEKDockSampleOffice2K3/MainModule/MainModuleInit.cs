using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Services;
using System.Windows.Forms;

namespace MainModule {
    /// <summary>
    /// This class gets instantiated when the ProfileCatalog.xml file gets processed
    /// </summary>
    public class MainModuleInit : ModuleInit {
        private WorkItem parentWorkItem;

        /// <summary>
        /// Just like in the Shell, we create a global variable to hold our root WorkItem
        /// </summary>
        [ServiceDependency]
        public WorkItem ParentWorkItem {
            set { parentWorkItem = value; }
        }

        /// <summary>
        /// For this DLL, we want the 'MainWorkItem' WorkItem to direct our SmartParts and
        /// the Workspaces they will get placed in.  We pass in the UltraWinExplorerBarWorkspace,
        /// but we could have passed in all three Workspaces in use on the shell if had 
        /// wanted.
        /// </summary>
        public override void Load() {
            base.Load();
            MainWorkItem mainWorkItem = parentWorkItem.WorkItems.AddNew<MainWorkItem>("mainWorkItem");
            mainWorkItem.Run(parentWorkItem.Workspaces["ultraExplorerBarWorkspace1"]);
        }
    }
}
