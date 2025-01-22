using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace MainModule {

    [SmartPart]
    public partial class RowListView : CABUserControl {
        private WorkItem parentWorkItem;

        /// <summary>
        /// Get access to the WorkItem that created this part.
        /// </summary>
        [ServiceDependency]
        public WorkItem ParentWorkItem {
            set { parentWorkItem = value; }
        }

        /// <summary>
        /// Docks the SmartPart, and initializes the columns in the ListView control, then
        /// calls the 'PopulateList' method to take the initial row and list out its contents.
        /// </summary>
        /// <param name="row"></param>
        public RowListView(UltraGridRow row) {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.ultraListView1.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            this.ultraListView1.SubItemColumns.Add("Field");
            this.ultraListView1.SubItemColumns.Add("Value");
            this.ultraListView1.SubItemColumns["Field"].HeaderAppearance = this.ultraListView1.ViewSettingsDetails.ColumnHeaderAppearance;
            this.ultraListView1.SubItemColumns["Value"].HeaderAppearance = this.ultraListView1.ViewSettingsDetails.ColumnHeaderAppearance;
            this.PopulateList(row);
        }

        /// <summary>
        /// Called by the WorkItem when a row in a TableGridView has been activated.
        /// </summary>
        /// <param name="row"></param>
        public void ChangeRow(UltraGridRow row) {
            this.ultraListView1.Items.Clear();
            this.PopulateList(row);
        }

        /// <summary>
        /// Loops through the cells in a row and adds subitems to the ListView, checking
        /// the checkbox if any columns are hidden in the grid.
        /// </summary>
        /// <param name="row"></param>
        private void PopulateList(UltraGridRow row) {
            UltraListViewItem item;
            this.ultraListView1.EventManager.Disable(UltraListViewEventIds.ItemCheckStateChanged);
            foreach (UltraGridCell cell in row.Cells) {
                // Assign the field values to the Value property of the
                // corresponding UltraListViewSubItem
                item = this.ultraListView1.Items.Add(cell.Column.Key);
                item.CheckState = cell.Column.Hidden ? CheckState.Checked : CheckState.Unchecked;
                item.SubItems["Field"].Value = cell.Column.Key;
                item.SubItems["Value"].Value = cell.Value;
            }
            this.ultraListView1.EventManager.Enable(UltraListViewEventIds.ItemCheckStateChanged);
        }

        /// <summary>
        /// If a checkbox in a ListView row was checked, we want to go back to the parent
        /// WorkItem and let it know that we want to hide the associated column.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraListView1_ItemCheckStateChanged(object sender, ItemCheckStateChangedEventArgs e) {
            MainWorkItem mainWorkItem = (MainWorkItem)parentWorkItem;
            mainWorkItem.ToggleColumnVisibility(e.Item.Key, e.Item.CheckState == CheckState.Checked);
        }
    }
}
