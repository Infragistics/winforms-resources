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
	partial class CustomerSummaryView
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerSummaryView));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.SaveButton = new Infragistics.Win.Misc.UltraButton();
            this.customerContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabbedWorkspace1 = new Infragistics.Practices.CompositeUI.WinForms.UltraTabWorkspace();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.customerDetailView2 = new BankTellerModule.CustomerDetailView();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.customerAccountsView2 = new BankTellerModule.CustomerAccountsView();
            this.customerHeaderView1 = new BankTellerModule.CustomerHeaderView();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedWorkspace1)).BeginInit();
            this.tabbedWorkspace1.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BorderColor = System.Drawing.Color.Transparent;
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.Name = "Verdana";
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance1.ImageBackground")));
            appearance1.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 12, 5, 0);
            appearance1.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.SaveButton.Appearance = appearance1;
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            this.SaveButton.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            appearance2.BorderColor = System.Drawing.Color.Transparent;
            appearance2.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance2.ImageBackground")));
            appearance2.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 12, 5, 0);
            this.SaveButton.HotTrackAppearance = appearance2;
            this.SaveButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SaveButton.Location = new System.Drawing.Point(396, 369);
            this.SaveButton.Name = "SaveButton";
            appearance3.BorderColor = System.Drawing.Color.Transparent;
            appearance3.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance3.ImageBackground")));
            appearance3.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 12, 5, 0);
            this.SaveButton.PressedAppearance = appearance3;
            this.SaveButton.ShowFocusRect = false;
            this.SaveButton.ShowOutline = false;
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
			this.SaveButton.Click += new System.EventHandler(this.OnSave);
			// 
            // customerContextMenu
            // 
            this.customerContextMenu.Name = "customerContextMenu";
            this.customerContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // tabbedWorkspace1
            // 
            this.tabbedWorkspace1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance4.ImageBackground")));
            appearance4.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            appearance4.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 5, 6, 0);
            appearance4.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.tabbedWorkspace1.Appearance = appearance4;
            this.tabbedWorkspace1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tabbedWorkspace1.Controls.Add(this.ultraTabPageControl1);
            this.tabbedWorkspace1.Controls.Add(this.ultraTabPageControl2);
            this.tabbedWorkspace1.Location = new System.Drawing.Point(0, 84);
            this.tabbedWorkspace1.Name = "tabbedWorkspace1";
            appearance5.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance5.ImageBackground")));
            appearance5.ImageBackgroundAlpha = Infragistics.Win.Alpha.Opaque;
            appearance5.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 5, 6, 0);
            appearance5.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.tabbedWorkspace1.SelectedTabAppearance = appearance5;
            this.tabbedWorkspace1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.tabbedWorkspace1.Size = new System.Drawing.Size(476, 279);
            this.tabbedWorkspace1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Flat;
            this.tabbedWorkspace1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tabbedWorkspace1.TabButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            this.tabbedWorkspace1.TabIndex = 3;
            this.tabbedWorkspace1.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.tabbedWorkspace1.TabPageMargins.Bottom = 3;
            this.tabbedWorkspace1.TabPageMargins.Left = 3;
            this.tabbedWorkspace1.TabPageMargins.Right = 3;
            this.tabbedWorkspace1.TabPageMargins.Top = 3;
            ultraTab1.Key = "Summary";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Summary";
            ultraTab2.Key = "Accounts";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Accounts";
            this.tabbedWorkspace1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(468, 252);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.customerDetailView2);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(4, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(468, 252);
            // 
            // customerDetailView2
            // 
            this.customerDetailView2.AutoScroll = true;
            this.customerDetailView2.BackColor = System.Drawing.Color.Transparent;
            this.customerDetailView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerDetailView2.Location = new System.Drawing.Point(0, 0);
            this.customerDetailView2.MinimumSize = new System.Drawing.Size(445, 271);
            this.customerDetailView2.Name = "customerDetailView2";
            this.customerDetailView2.Size = new System.Drawing.Size(468, 271);
            this.customerDetailView2.TabIndex = 0;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.customerAccountsView2);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(468, 252);
            // 
            // customerAccountsView2
            // 
            this.customerAccountsView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerAccountsView2.Location = new System.Drawing.Point(0, 0);
            this.customerAccountsView2.Name = "customerAccountsView2";
            this.customerAccountsView2.Size = new System.Drawing.Size(468, 252);
            this.customerAccountsView2.TabIndex = 0;
            // 
            // customerHeaderView1
            // 
            this.customerHeaderView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customerHeaderView1.BackColor = System.Drawing.Color.Gray;
            this.customerHeaderView1.Location = new System.Drawing.Point(4, 4);
            this.customerHeaderView1.Name = "customerHeaderView1";
            this.customerHeaderView1.Size = new System.Drawing.Size(472, 85);
            this.customerHeaderView1.TabIndex = 0;
            // 
            // CustomerSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.customerContextMenu;
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tabbedWorkspace1);
            this.Controls.Add(this.customerHeaderView1);
            this.Name = "CustomerSummaryView";
            this.Size = new System.Drawing.Size(476, 412);
            ((System.ComponentModel.ISupportInitialize)(this.tabbedWorkspace1)).EndInit();
            this.tabbedWorkspace1.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private CustomerHeaderView customerHeaderView1;
		private Infragistics.Win.Misc.UltraButton SaveButton;
		private System.Windows.Forms.ContextMenuStrip customerContextMenu;
		private Infragistics.Practices.CompositeUI.WinForms.UltraTabWorkspace tabbedWorkspace1;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
		private CustomerDetailView customerDetailView2;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
		private CustomerAccountsView customerAccountsView2;
	}
}
