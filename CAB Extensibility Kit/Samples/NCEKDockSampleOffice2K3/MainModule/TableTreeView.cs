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
    public partial class TableTreeView : CABUserControl {

        private WorkItem parentWorkItem;
        public string DatabaseName;

        /// <summary>
        /// Get access to the WorkItem that created this part.
        /// </summary>
        [ServiceDependency]
        public WorkItem ParentWorkItem {
            set { parentWorkItem = value; }
        }

        /// <summary>
        /// We're placing this SmartPart in a Workspace by itself, so we set the dock property
        /// to fill.  We use our DataAccess class to retrieve our Database table list, and
        /// populate the tree with a list of tables, and each table's column list.
        /// </summary>
        /// <param name="db"></param>
        public TableTreeView(string db) {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.ultraTree1.Tag = db;
            this.DatabaseName = db;
            Infragistics.Win.UltraWinTree.UltraTreeNode node;
            foreach (DataTable dt in DataAccess.GetDataSet(db).Tables) {
                node = this.ultraTree1.Nodes.Add(dt.TableName);
                foreach (DataColumn dc in dt.Columns) {
                    node.Nodes.Add(node.Key + "-" + dc.ColumnName, dc.ColumnName);
                }                
            }
        }

        /// <summary>
        /// After a user has selected a tree node, we check to make sure that it's a top
        /// level node.  If it is, we call the 'LoadTable' method on our WorkItem to create
        /// a TableGridView SmartPart, and load this tables row data into it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraTree1_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e) {
            if (e.NewSelections.Count > 0 && e.NewSelections[0].Level == 0) {
                MainWorkItem mainWorkItem = (MainWorkItem)parentWorkItem;
                mainWorkItem.LoadTable(this.ultraTree1.Tag.ToString(), e.NewSelections[0].Text);
            }
        }
    }
}
