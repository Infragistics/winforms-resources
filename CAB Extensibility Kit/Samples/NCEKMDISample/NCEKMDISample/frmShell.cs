using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.ObjectBuilder;
using MainModule;

namespace NCEKMDISample {
    public partial class frmShell : Form {
        //Create a global variable storing our root WorkItem
        private WorkItem workItem;

        public frmShell() {
            InitializeComponent();
        }

        /// <summary>
        /// This constructor will be called by ObjectBuilder when the Form is created
        /// by calling WorkItem.Items.AddNew.
        /// </summary>
        [InjectionConstructor]
        public frmShell(WorkItem workItem, IWorkItemTypeCatalogService workItemTypeCatalog)
			: this()
		{
			this.workItem = workItem;
		}

        /// <summary>
        /// Call the 'GetTables' method on our 'MainWorkItem' WorkItem, which retrieves a list
        /// of tables in the Database we've selected through the menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraToolbarsManagerWorkspace1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e) {
            MainWorkItem mainWorkItem = (MainWorkItem) this.workItem.WorkItems["mainWorkItem"];
            
            switch (e.Tool.Key) {
                case "Northwind":
                    mainWorkItem.GetTables("Northwind");
                    break;
                case "Pubs":
                    mainWorkItem.GetTables("Pubs");
                    break;
                case "Exit":
                    this.Close();
                    break;
            }
        }

        //Set the initial position of the TaskPane
        private void frmShell_Load(object sender, EventArgs e) {
            this.ultraToolbarsManagerWorkspace1.Toolbars["TaskPane"].FloatingLocation = new Point((this.Right - this.ultraToolbarsManagerWorkspace1.Toolbars["TaskPane"].FloatingSize.Width) + 25, (this.Bottom - this.ultraToolbarsManagerWorkspace1.Toolbars["TaskPane"].FloatingSize.Height) + 25);
        }

        private void ultraMdiTabWorkspace1_InitializeTab(object sender, Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs e) {
            this.ultraLabel1.Visible = false;
        }

        private void ultraMdiTabWorkspace1_TabClosing(object sender, Infragistics.Win.UltraWinTabbedMdi.CancelableMdiTabEventArgs e) {
            if (this.MdiChildren.Length == 1)
                this.ultraLabel1.Visible = true;
        }
    }
}