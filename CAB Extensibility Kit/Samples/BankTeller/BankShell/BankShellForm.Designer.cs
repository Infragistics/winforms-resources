//===============================================================================
// Microsoft patterns & practices
// CompositeUI Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

namespace BankShell
{
	partial class BankShellForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenuBar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File");
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("98a6a965-acbb-456e-b3cd-7c4ea89e70de"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("7e76bed0-26c6-4931-b66d-acaffc26759f"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("98a6a965-acbb-456e-b3cd-7c4ea89e70de"), -1);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankShellForm));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedRight, new System.Guid("0790c5e4-057e-457d-b203-379a2bd08033"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("d89006c4-3c43-4537-a5a0-57052e2cfefb"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("0790c5e4-057e-457d-b203-379a2bd08033"), -1);
            this.sideBarWorkspace = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.contentWorkspace = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.MainStatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._BankShellForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._BankShellForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._BankShellForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._BankShellForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraDockWorkspace1 = new Infragistics.Practices.CompositeUI.WinForms.UltraDockWorkspace(this.components);
            this._BankShellFormUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BankShellFormUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BankShellFormUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BankShellFormUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BankShellFormAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.windowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            ((System.ComponentModel.ISupportInitialize)(this.MainStatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockWorkspace1)).BeginInit();
            this.windowDockingArea1.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.windowDockingArea2.SuspendLayout();
            this.dockableWindow2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideBarWorkspace
            // 
            this.sideBarWorkspace.Location = new System.Drawing.Point(0, 26);
            this.sideBarWorkspace.Name = "sideBarWorkspace";
            this.sideBarWorkspace.Size = new System.Drawing.Size(240, 464);
            this.sideBarWorkspace.TabIndex = 0;
            this.sideBarWorkspace.Text = "deckWorkspace1";
            // 
            // contentWorkspace
            // 
            this.contentWorkspace.Location = new System.Drawing.Point(0, 0);
            this.contentWorkspace.Name = "contentWorkspace";
            this.contentWorkspace.Size = new System.Drawing.Size(494, 490);
            this.contentWorkspace.TabIndex = 0;
            this.contentWorkspace.Text = "deckedWorkspace1";
            // 
            // MainStatusBar
            // 
            this.MainStatusBar.Location = new System.Drawing.Point(0, 512);
            this.MainStatusBar.Name = "MainStatusBar";
            ultraStatusPanel1.Key = "StatusPanel";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            this.MainStatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1});
            this.MainStatusBar.Size = new System.Drawing.Size(739, 23);
            this.MainStatusBar.TabIndex = 3;
            this.MainStatusBar.Text = "ultraStatusBar1";
            // 
            // ToolbarsManager
            // 
            this.ToolbarsManager.DesignerFlags = 1;
            this.ToolbarsManager.DockWithinContainer = this;
            this.ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ToolbarsManager.ShowFullMenusDelay = 500;
            this.ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1});
            ultraToolbar1.Text = "MenuBar";
            this.ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            popupMenuTool2.SharedPropsInternal.Caption = "&File";
            this.ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool2});
            // 
            // _BankShellForm_Toolbars_Dock_Area_Left
            // 
            this._BankShellForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BankShellForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._BankShellForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._BankShellForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BankShellForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 22);
            this._BankShellForm_Toolbars_Dock_Area_Left.Name = "_BankShellForm_Toolbars_Dock_Area_Left";
            this._BankShellForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 490);
            this._BankShellForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolbarsManager;
            // 
            // _BankShellForm_Toolbars_Dock_Area_Right
            // 
            this._BankShellForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BankShellForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._BankShellForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._BankShellForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BankShellForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(739, 22);
            this._BankShellForm_Toolbars_Dock_Area_Right.Name = "_BankShellForm_Toolbars_Dock_Area_Right";
            this._BankShellForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 490);
            this._BankShellForm_Toolbars_Dock_Area_Right.ToolbarsManager = this.ToolbarsManager;
            // 
            // _BankShellForm_Toolbars_Dock_Area_Top
            // 
            this._BankShellForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BankShellForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._BankShellForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._BankShellForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BankShellForm_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._BankShellForm_Toolbars_Dock_Area_Top.Name = "_BankShellForm_Toolbars_Dock_Area_Top";
            this._BankShellForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(739, 22);
            this._BankShellForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolbarsManager;
            // 
            // _BankShellForm_Toolbars_Dock_Area_Bottom
            // 
            this._BankShellForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BankShellForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._BankShellForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._BankShellForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BankShellForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 512);
            this._BankShellForm_Toolbars_Dock_Area_Bottom.Name = "_BankShellForm_Toolbars_Dock_Area_Bottom";
            this._BankShellForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(739, 0);
            this._BankShellForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolbarsManager;
            // 
            // ultraDockWorkspace1
            // 
            this.ultraDockWorkspace1.DefaultPaneSettings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.DockedBefore = new System.Guid("0790c5e4-057e-457d-b203-379a2bd08033");
            dockableControlPane1.Control = this.sideBarWorkspace;
            dockableControlPane1.Key = "SideBar";
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(24, 29, 222, 465);
            appearance1.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance1.ImageBackground")));
            dockableControlPane1.Settings.CaptionAppearance = appearance1;
            appearance2.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance2.ImageBackground")));
            dockableControlPane1.Settings.SelectedTabAppearance = appearance2;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "SideBar";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(240, 490);
            dockableControlPane2.Control = this.contentWorkspace;
            dockableControlPane2.Key = "Content";
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(149, 41, 513, 465);
            dockableControlPane2.Settings.ShowCaption = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "contentWorkspace";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(494, 490);
            dockAreaPane2.UnfilledSize = new System.Drawing.Size(497, 489);
            this.ultraDockWorkspace1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.ultraDockWorkspace1.HostControl = this;
            this.ultraDockWorkspace1.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.ultraDockWorkspace1.ShowDisabledButtons = false;
            this.ultraDockWorkspace1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _BankShellFormUnpinnedTabAreaLeft
            // 
            this._BankShellFormUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._BankShellFormUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BankShellFormUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 22);
            this._BankShellFormUnpinnedTabAreaLeft.Name = "_BankShellFormUnpinnedTabAreaLeft";
            this._BankShellFormUnpinnedTabAreaLeft.Owner = this.ultraDockWorkspace1;
            this._BankShellFormUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 490);
            this._BankShellFormUnpinnedTabAreaLeft.TabIndex = 7;
            // 
            // _BankShellFormUnpinnedTabAreaRight
            // 
            this._BankShellFormUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._BankShellFormUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BankShellFormUnpinnedTabAreaRight.Location = new System.Drawing.Point(739, 22);
            this._BankShellFormUnpinnedTabAreaRight.Name = "_BankShellFormUnpinnedTabAreaRight";
            this._BankShellFormUnpinnedTabAreaRight.Owner = this.ultraDockWorkspace1;
            this._BankShellFormUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 490);
            this._BankShellFormUnpinnedTabAreaRight.TabIndex = 8;
            // 
            // _BankShellFormUnpinnedTabAreaTop
            // 
            this._BankShellFormUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._BankShellFormUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BankShellFormUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 22);
            this._BankShellFormUnpinnedTabAreaTop.Name = "_BankShellFormUnpinnedTabAreaTop";
            this._BankShellFormUnpinnedTabAreaTop.Owner = this.ultraDockWorkspace1;
            this._BankShellFormUnpinnedTabAreaTop.Size = new System.Drawing.Size(739, 0);
            this._BankShellFormUnpinnedTabAreaTop.TabIndex = 9;
            // 
            // _BankShellFormUnpinnedTabAreaBottom
            // 
            this._BankShellFormUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._BankShellFormUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BankShellFormUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 512);
            this._BankShellFormUnpinnedTabAreaBottom.Name = "_BankShellFormUnpinnedTabAreaBottom";
            this._BankShellFormUnpinnedTabAreaBottom.Owner = this.ultraDockWorkspace1;
            this._BankShellFormUnpinnedTabAreaBottom.Size = new System.Drawing.Size(739, 0);
            this._BankShellFormUnpinnedTabAreaBottom.TabIndex = 10;
            // 
            // _BankShellFormAutoHideControl
            // 
            this._BankShellFormAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BankShellFormAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._BankShellFormAutoHideControl.Name = "_BankShellFormAutoHideControl";
            this._BankShellFormAutoHideControl.Owner = this.ultraDockWorkspace1;
            this._BankShellFormAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._BankShellFormAutoHideControl.TabIndex = 11;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Controls.Add(this.dockableWindow1);
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea1.Location = new System.Drawing.Point(0, 22);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.ultraDockWorkspace1;
            this.windowDockingArea1.Size = new System.Drawing.Size(245, 490);
            this.windowDockingArea1.TabIndex = 12;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.sideBarWorkspace);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.ultraDockWorkspace1;
            this.dockableWindow1.Size = new System.Drawing.Size(240, 490);
            this.dockableWindow1.TabIndex = 18;
            // 
            // windowDockingArea2
            // 
            this.windowDockingArea2.Controls.Add(this.dockableWindow2);
            this.windowDockingArea2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea2.Location = new System.Drawing.Point(245, 22);
            this.windowDockingArea2.Name = "windowDockingArea2";
            this.windowDockingArea2.Owner = this.ultraDockWorkspace1;
            this.windowDockingArea2.Size = new System.Drawing.Size(494, 490);
            this.windowDockingArea2.TabIndex = 13;
            // 
            // dockableWindow2
            // 
            this.dockableWindow2.Controls.Add(this.contentWorkspace);
            this.dockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow2.Name = "dockableWindow2";
            this.dockableWindow2.Owner = this.ultraDockWorkspace1;
            this.dockableWindow2.Size = new System.Drawing.Size(494, 490);
            this.dockableWindow2.TabIndex = 19;
            // 
            // BankShellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 535);
            this.Controls.Add(this._BankShellFormAutoHideControl);
            this.Controls.Add(this.windowDockingArea2);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._BankShellFormUnpinnedTabAreaTop);
            this.Controls.Add(this._BankShellFormUnpinnedTabAreaBottom);
            this.Controls.Add(this._BankShellFormUnpinnedTabAreaLeft);
            this.Controls.Add(this._BankShellFormUnpinnedTabAreaRight);
            this.Controls.Add(this._BankShellForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._BankShellForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._BankShellForm_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.MainStatusBar);
            this.Controls.Add(this._BankShellForm_Toolbars_Dock_Area_Top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BankShellForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bank Shell";
            ((System.ComponentModel.ISupportInitialize)(this.MainStatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockWorkspace1)).EndInit();
            this.windowDockingArea1.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.windowDockingArea2.ResumeLayout(false);
            this.dockableWindow2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace sideBarWorkspace;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _BankShellForm_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _BankShellForm_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _BankShellForm_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _BankShellForm_Toolbars_Dock_Area_Bottom;
		internal Infragistics.Win.UltraWinStatusBar.UltraStatusBar MainStatusBar;
		internal Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ToolbarsManager;
		public Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace contentWorkspace;
		private Infragistics.Win.UltraWinDock.AutoHideControl _BankShellFormAutoHideControl;
		private Infragistics.Practices.CompositeUI.WinForms.UltraDockWorkspace ultraDockWorkspace1;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _BankShellFormUnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _BankShellFormUnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _BankShellFormUnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _BankShellFormUnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea2;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow2;
	}
}

