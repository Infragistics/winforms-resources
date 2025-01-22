using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace MainModule {

    [SmartPart]
    public partial class TableGridView : CABUserControl {

        private WorkItem parentWorkItem;
        
        /// <summary>
        /// Get access to the WorkItem that created this part.
        /// </summary>
        [ServiceDependency]
        public WorkItem ParentWorkItem {
            set { parentWorkItem = value; }
        }


        /// <summary>
        /// Init the SmartPart, binds the grid to the appropriate table and 
        /// sets the DockStyle to Fill.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="table"></param>
        public TableGridView(string db, string table) {
            InitializeComponent();
            this.ultraGrid1.DataSource = DataAccess.GetDataSet(db).Tables[table];
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Once a row has been activated, send that row information to the WorkItem
        /// so that it can load up the RowListView SmartPart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_AfterRowActivate(object sender, EventArgs e) {
            MainWorkItem mainWorkItem = (MainWorkItem)parentWorkItem;
            mainWorkItem.LoadRow(this.ultraGrid1.ActiveRow);
        }

        /// <summary>
        /// Called by WorkItem to show\hide grid columns
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hidden"></param>
        public void ToggleColumnVisibility(string key, bool hidden) {
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[key].Hidden = hidden;
        }

        /// <summary>
        /// When this SmartPart is shown after having already been created, we want
        /// to make sure that the ActiveRow on this grid is shown in the RowListView,
        /// as opposed to whatever row is currently visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableGridView_Enter(object sender, EventArgs e) {
            if (this.Visible && this.ultraGrid1.ActiveRow != null) {
                MainWorkItem mainWorkItem = (MainWorkItem)parentWorkItem;
                mainWorkItem.LoadRow(this.ultraGrid1.ActiveRow);
            }
        }
    }
}
