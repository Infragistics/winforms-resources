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

namespace BankTellerModule
{
	partial class CustomerAccountsView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Standard");
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("PlaceHolder");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("PlaceHolder");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerAccountsView));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CustomerAccount", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CurrentBalance");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AccountType");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AccountNumber");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            this.CustomerAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._CustomerAccountsView_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._CustomerAccountsView_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._CustomerAccountsView_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._CustomerAccountsView_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerAccountBindingSource
            // 
            this.CustomerAccountBindingSource.DataSource = typeof(BankTellerCommon.CustomerAccount);
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 0;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            appearance22.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance22.ImageBackground")));
            ultraToolbar1.Settings.Appearance = appearance22;
            ultraToolbar1.Settings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.Text = "Standard";
            ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool1});
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool2});
            // 
            // _CustomerAccountsView_Toolbars_Dock_Area_Left
            // 
            this._CustomerAccountsView_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CustomerAccountsView_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._CustomerAccountsView_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._CustomerAccountsView_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CustomerAccountsView_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 25);
            this._CustomerAccountsView_Toolbars_Dock_Area_Left.Name = "_CustomerAccountsView_Toolbars_Dock_Area_Left";
            this._CustomerAccountsView_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 246);
            this._CustomerAccountsView_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _CustomerAccountsView_Toolbars_Dock_Area_Right
            // 
            this._CustomerAccountsView_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CustomerAccountsView_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._CustomerAccountsView_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._CustomerAccountsView_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CustomerAccountsView_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(445, 25);
            this._CustomerAccountsView_Toolbars_Dock_Area_Right.Name = "_CustomerAccountsView_Toolbars_Dock_Area_Right";
            this._CustomerAccountsView_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 246);
            this._CustomerAccountsView_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _CustomerAccountsView_Toolbars_Dock_Area_Top
            // 
            this._CustomerAccountsView_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CustomerAccountsView_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._CustomerAccountsView_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._CustomerAccountsView_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CustomerAccountsView_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._CustomerAccountsView_Toolbars_Dock_Area_Top.Name = "_CustomerAccountsView_Toolbars_Dock_Area_Top";
            this._CustomerAccountsView_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(445, 25);
            this._CustomerAccountsView_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _CustomerAccountsView_Toolbars_Dock_Area_Bottom
            // 
            this._CustomerAccountsView_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CustomerAccountsView_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._CustomerAccountsView_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._CustomerAccountsView_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CustomerAccountsView_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 271);
            this._CustomerAccountsView_Toolbars_Dock_Area_Bottom.Name = "_CustomerAccountsView_Toolbars_Dock_Area_Bottom";
            this._CustomerAccountsView_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(445, 0);
            this._CustomerAccountsView_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DataSource = this.CustomerAccountBindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            this.ultraGrid1.DisplayLayout.AddNewBox.Appearance = appearance1;
            this.ultraGrid1.DisplayLayout.AddNewBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance2.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance2.ImageBackground")));
            appearance2.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            appearance2.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3);
            appearance2.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.ultraGrid1.DisplayLayout.AddNewBox.ButtonAppearance = appearance2;
            this.ultraGrid1.DisplayLayout.AddNewBox.ButtonConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            this.ultraGrid1.DisplayLayout.AddNewBox.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            appearance3.BackColor = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.Appearance = appearance3;
            this.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.Header.VisiblePosition = 2;
            ultraGridColumn1.Width = 140;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 129;
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn3.Width = 146;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance4.FontData.Name = "Trebuchet MS";
            appearance4.FontData.SizeInPoints = 9F;
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid1.DisplayLayout.CaptionAppearance = appearance4;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.EmptyRowSettings.ShowEmptyRows = true;
            this.ultraGrid1.DisplayLayout.FixedHeaderOffImage = ((System.Drawing.Image)(resources.GetObject("ultraGrid1.DisplayLayout.FixedHeaderOffImage")));
            this.ultraGrid1.DisplayLayout.FixedHeaderOnImage = ((System.Drawing.Image)(resources.GetObject("ultraGrid1.DisplayLayout.FixedHeaderOnImage")));
            this.ultraGrid1.DisplayLayout.FixedRowOffImage = ((System.Drawing.Image)(resources.GetObject("ultraGrid1.DisplayLayout.FixedRowOffImage")));
            this.ultraGrid1.DisplayLayout.FixedRowOnImage = ((System.Drawing.Image)(resources.GetObject("ultraGrid1.DisplayLayout.FixedRowOnImage")));
            appearance5.FontData.BoldAsString = "True";
            appearance5.FontData.Name = "Trebuchet MS";
            appearance5.FontData.SizeInPoints = 10F;
            appearance5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(127)))), ((int)(((byte)(177)))));
            appearance5.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance5.ImageBackground")));
            appearance5.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(0, 2, 0, 3);
            appearance5.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.ultraGrid1.DisplayLayout.GroupByBox.Appearance = appearance5;
            this.ultraGrid1.DisplayLayout.GroupByBox.ButtonBorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
            this.ultraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True;
            this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraGrid1.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance6;
            appearance7.BorderColor = System.Drawing.Color.Transparent;
            appearance7.FontData.Name = "Verdana";
            this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance7;
            appearance8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance8.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance8.ImageBackground")));
            appearance8.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3);
            appearance8.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.ultraGrid1.DisplayLayout.Override.CellButtonAppearance = appearance8;
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.ultraGrid1.DisplayLayout.Override.FilterCellAppearance = appearance9;
            appearance10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance10.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance10.ImageBackground")));
            appearance10.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3);
            this.ultraGrid1.DisplayLayout.Override.FilterClearButtonAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            appearance11.BackColorAlpha = Infragistics.Win.Alpha.Opaque;
            this.ultraGrid1.DisplayLayout.Override.FilterRowPromptAppearance = appearance11;
            this.ultraGrid1.DisplayLayout.Override.FixedRowIndicator = Infragistics.Win.UltraWinGrid.FixedRowIndicator.Button;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance12.FontData.BoldAsString = "True";
            appearance12.FontData.Name = "Trebuchet MS";
            appearance12.FontData.SizeInPoints = 10F;
            appearance12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance12.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance12.ImageBackground")));
            appearance12.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled;
            appearance12.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance12.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance13.BorderColor = System.Drawing.Color.Transparent;
            this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorAppearance = appearance14;
            appearance15.BorderColor = System.Drawing.Color.Transparent;
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid1.DisplayLayout.Override.SelectedCellAppearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.Transparent;
            appearance16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance16.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance16.ImageBackground")));
            appearance16.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(1, 1, 1, 4);
            appearance16.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.ultraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance16;
            this.ultraGrid1.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            appearance17.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(2, 4, 2, 4);
            appearance17.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            scrollBarLook1.Appearance = appearance17;
            appearance18.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance18.ImageBackground")));
            appearance18.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(3, 2, 3, 2);
            scrollBarLook1.AppearanceHorizontal = appearance18;
            appearance19.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance19.ImageBackground")));
            appearance19.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(2, 3, 2, 3);
            appearance19.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            scrollBarLook1.AppearanceVertical = appearance19;
            appearance20.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance20.ImageBackground")));
            appearance20.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(0, 2, 0, 1);
            scrollBarLook1.TrackAppearanceHorizontal = appearance20;
            appearance21.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance21.ImageBackground")));
            appearance21.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(2, 0, 1, 0);
            appearance21.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            scrollBarLook1.TrackAppearanceVertical = appearance21;
            this.ultraGrid1.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.ultraGrid1.DisplayLayout.UseFixedHeaders = true;
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ultraGrid1.Location = new System.Drawing.Point(0, 25);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(445, 246);
            this.ultraGrid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.TabIndex = 6;
            this.ultraGrid1.Text = "Grid Caption Area";
            // 
            // CustomerAccountsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this._CustomerAccountsView_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._CustomerAccountsView_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._CustomerAccountsView_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._CustomerAccountsView_Toolbars_Dock_Area_Bottom);
            this.Name = "CustomerAccountsView";
            this.Size = new System.Drawing.Size(445, 271);
            this.Load += new System.EventHandler(this.CustomerAccountsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource CustomerAccountBindingSource;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CustomerAccountsView_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CustomerAccountsView_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CustomerAccountsView_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CustomerAccountsView_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;



	}
}
