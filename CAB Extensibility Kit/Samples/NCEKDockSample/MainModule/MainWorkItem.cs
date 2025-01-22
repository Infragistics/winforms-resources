using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Infragistics.Practices.CompositeUI.WinForms;
using Infragistics.Win.UltraWinGrid;

namespace MainModule {
    public class MainWorkItem : WorkItem {

        //The Workspaces in use in our shell
        private UltraExplorerBarWorkspace explorerBarWorkspace;
        private UltraDockWorkspace dockWorkspace;
        private UltraToolbarsManagerWorkspace toolbarsManagerWorkspace;

        //Two panels that will get added using the UIElementSites collection; we need
        //access to the at other points, so to make it easier, we declare them up here.
        private Infragistics.Win.UltraWinStatusBar.UltraStatusPanel loadPanel;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusPanel rowInfoPanel;

        /// <summary>
        /// The entry point for our WorkItem.  It takes an incoming Workspace as a
        /// parameter, then stores it into our 'explorerBarWorkspace' variable.  We
        /// then go to the RootWorkItem, and get access to our other two Workspaces.
        /// </summary>
        /// <param name="ExplorerBarWorkspace"></param>
        public void Run(IWorkspace ExplorerBarWorkspace) {
            DataAccess.GetDataAccess();
            this.explorerBarWorkspace = (UltraExplorerBarWorkspace) ExplorerBarWorkspace;
            this.dockWorkspace = (UltraDockWorkspace)this.RootWorkItem.Workspaces["ultraDockWorkspace1"];
            this.toolbarsManagerWorkspace = (UltraToolbarsManagerWorkspace)this.RootWorkItem.Workspaces["ultraToolbarsManagerWorkspace1"];
        }

        /// <summary>
        /// This is called from our shell form, in the ToolbarManagerWorkspace's 'ToolClick'
        /// event, and gets a list of tables for the Database we've picked.  If the StatusBar panel has not yet been instantiated, we create it and
        /// set a few properties.
        /// 
        /// We create a 'TableTreeView' SmartPart, passing in the 'db' parameter, which
        /// specifies which Database we want to list out.  If the SmartPart has already been
        /// created, we just call the 'Show' method on the Workspace that contains it.
        /// 
        /// If the SmartPart doesn't exist, we not only create it, but we also go into our
        /// UIElement collection and create a context menu specifically for this instance
        /// of the 'TableTreeView'.
        /// </summary>
        /// <param name="db"></param>
        public void GetTables(string db) {
            //Creating the StatusBar panel
            if (loadPanel == null) {
                loadPanel = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
                loadPanel.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Text;
                loadPanel.Width = 140;
                loadPanel.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
                this.UIExtensionSites["Status"].Add(loadPanel);
            }
            loadPanel.Text = "Loading " + db + "...";
           
            if (!this.Items.Contains(db)) {
                //Creating and adding a smartpart
                TableTreeView tree = new TableTreeView(db);
                this.Items.Add(tree, db);

                UltraExplorerBarSmartPartInfo smartPartInfo = new UltraExplorerBarSmartPartInfo();
                smartPartInfo.Title = db;
                
                this.explorerBarWorkspace.Show(tree, smartPartInfo);
                
                //Creating and adding a context menu; note, we could've just as easily used the
                //add/remove capabilities of the ToolbarsManagerWorkspace, but this illustrates
                //how to do it in case we don't have access to the Workspace.
                Infragistics.Win.UltraWinToolbars.PopupMenuTool pmt = new Infragistics.Win.UltraWinToolbars.PopupMenuTool(db+"Context");
                Infragistics.Win.UltraWinToolbars.ButtonTool bt = new Infragistics.Win.UltraWinToolbars.ButtonTool(db+"Button");

                this.UIExtensionSites["Menus"].Add<Infragistics.Win.UltraWinToolbars.PopupMenuTool>(pmt);
                this.UIExtensionSites["Menus"].Add<Infragistics.Win.UltraWinToolbars.ButtonTool>(bt);

                bt.SharedProps.Caption = "Button context menu item for the " + db + " tree";
                pmt.Tools.AddTool(db + "Button");
                this.toolbarsManagerWorkspace.SetContextMenuUltra(tree, db + "Context");
            }
            else {
                this.explorerBarWorkspace.Show(this.Items.Get(db));
            }

            loadPanel.Text = db + " loaded";
        }
        
        /// <summary>
        /// Called by the TableTreeView SmartPart when a user selects a top level tree
        /// node.  The SmartPart passes the Database name, and the table from the DB it 
        /// wants.  We then load the corresponding table's information into a TableGridView
        /// SmartPart, and add a context menu for it.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="table"></param>
        public void LoadTable(string db, string table) {
            loadPanel.Text = "Loading " + table + "...";
            
            if (!this.Items.Contains(db + " - " + table)) {
                TableGridView grid = new TableGridView(db, table);
                this.Items.Add(grid, db + " - " + table);

                UltraDockSmartPartInfo smartPartInfo = new UltraDockSmartPartInfo();
                smartPartInfo.DefaultLocation = Infragistics.Win.UltraWinDock.DockedLocation.DockedTop;
                smartPartInfo.DefaultPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.TabGroup;
                smartPartInfo.PreferredGroup = "gridPane";
                smartPartInfo.Title = db + "-" + table;

                dockWorkspace.Show(grid, smartPartInfo);
                dockWorkspace.Activate(grid);

                Infragistics.Win.UltraWinToolbars.PopupMenuTool pmt = new Infragistics.Win.UltraWinToolbars.PopupMenuTool(db + " - " + table + "Context");
                Infragistics.Win.UltraWinToolbars.ButtonTool bt = new Infragistics.Win.UltraWinToolbars.ButtonTool(db + " - " + table + "Button");

                this.UIExtensionSites["Menus"].Add<Infragistics.Win.UltraWinToolbars.PopupMenuTool>(pmt);
                this.UIExtensionSites["Menus"].Add<Infragistics.Win.UltraWinToolbars.ButtonTool>(bt);

                bt.SharedProps.Caption = "Button context menu item for the " + db + " - " + table + " grid";
                pmt.Tools.AddTool(db + " - " + table + "Button");
                this.toolbarsManagerWorkspace.SetContextMenuUltra(grid, db + " - " + table + "Context");
            }
            else {
                dockWorkspace.Show(this.Items.Get(db + " - " + table));
            }

            if (dockWorkspace.ControlPanes.Exists("ultraLabel1")) {
                dockWorkspace.ControlPanes["ultraLabel1"].Close();
            }

            loadPanel.Text = table + " loaded";
        }

        /// <summary>
        /// Called by the TableGridView SmartPart; this passes the ActiveRow information in the
        /// grid within the view back to us (the workitem), which then in turn passes that info
        /// to the RowListView SmartPart, creating it if it has been instantiated yet.  We also 
        /// add another StatusBar panel in this call in order to display Row\Table\Database
        /// information.
        /// </summary>
        /// <param name="row"></param>
        public void LoadRow(UltraGridRow row) {
            RowListView list;
           
            if (rowInfoPanel == null) {
                rowInfoPanel = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
                rowInfoPanel.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Text;
                rowInfoPanel.Width = 600;
                rowInfoPanel.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
                this.UIExtensionSites["Status"].Add(rowInfoPanel);
            }
            rowInfoPanel.Text = "Currently viewing the row at index " + row.Index.ToString() + " in the " + row.Band.Key + " table within the " + ((TableTreeView)this.explorerBarWorkspace.ActiveSmartPart).DatabaseName + " database";

            if (!this.Items.Contains("RowInfo")) {
                toolbarsManagerWorkspace.Toolbars["TaskPane"].Visible = true;

                UltraToolbarsSmartPartInfo smartPartInfo = new UltraToolbarsSmartPartInfo();
                smartPartInfo.PreferredTaskPane = "TaskPane";
                smartPartInfo.HeaderCaption = @"Column\Row Information";
                
                list = new RowListView(row);
                this.Items.Add(list, "RowInfo");
                toolbarsManagerWorkspace.Show(list, smartPartInfo);
            }
            else {
                toolbarsManagerWorkspace.Toolbars["TaskPane"].Visible = true;
                list = (RowListView)this.Items["RowInfo"];
                list.ChangeRow(row);
            }
        }

        /// <summary>
        /// Called from the RowListView SmartPart.  When the user checks off an item on the
        /// list, it will call this code to hide the appropriate column.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hidden"></param>
        public void ToggleColumnVisibility(string key, bool hidden) {
            TableGridView grid = (TableGridView) dockWorkspace.ActiveSmartPart;
            grid.ToggleColumnVisibility(key, hidden);
        }
    }
}
