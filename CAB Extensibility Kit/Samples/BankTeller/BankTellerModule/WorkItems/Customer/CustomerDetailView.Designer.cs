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
	partial class CustomerDetailView
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDetailView));
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Standard");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Comments");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Comments");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new Infragistics.Win.Misc.UltraLabel();
            this.txtAddress1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtAddress2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtCity = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtState = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label7 = new Infragistics.Win.Misc.UltraLabel();
            this.label8 = new Infragistics.Win.Misc.UltraLabel();
            this.txtZip = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtPhone1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtPhone2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtEmail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label10 = new Infragistics.Win.Misc.UltraLabel();
            this.label11 = new Infragistics.Win.Misc.UltraLabel();
            this.label12 = new Infragistics.Win.Misc.UltraLabel();
            this.label1 = new Infragistics.Win.Misc.UltraLabel();
            this.lastNameTextBox = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label2 = new Infragistics.Win.Misc.UltraLabel();
            this.firstNameTextBox = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.detailsToolbars = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.CustomerDetailView_Fill_Panel = new System.Windows.Forms.Panel();
            this._CustomerDetailView_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._CustomerDetailView_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._CustomerDetailView_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._CustomerDetailView_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ultraPictureBox2 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastNameTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstNameTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailsToolbars)).BeginInit();
            this.CustomerDetailView_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(BankTellerCommon.Customer);
            // 
            // label5
            // 
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.White;
            this.label5.Appearance = appearance1;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Address:";
            // 
            // txtAddress1
            // 
            this.txtAddress1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Address1", true));
            this.txtAddress1.Location = new System.Drawing.Point(97, 56);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(373, 21);
            this.txtAddress1.TabIndex = 7;
            // 
            // txtAddress2
            // 
            this.txtAddress2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Address2", true));
            this.txtAddress2.Location = new System.Drawing.Point(97, 82);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(373, 21);
            this.txtAddress2.TabIndex = 8;
            // 
            // txtCity
            // 
            this.txtCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "City", true));
            this.txtCity.Location = new System.Drawing.Point(96, 109);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(149, 21);
            this.txtCity.TabIndex = 9;
            // 
            // label6
            // 
            appearance2.FontData.BoldAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.White;
            this.label6.Appearance = appearance2;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "City:";
            // 
            // txtState
            // 
            this.txtState.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "State", true));
            this.txtState.Location = new System.Drawing.Point(305, 109);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(62, 21);
            this.txtState.TabIndex = 11;
            // 
            // label7
            // 
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.White;
            this.label7.Appearance = appearance3;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(262, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "State:";
            // 
            // label8
            // 
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.White;
            this.label8.Appearance = appearance4;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(367, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "Zip:";
            // 
            // txtZip
            // 
            this.txtZip.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "ZipCode", true));
            this.txtZip.Location = new System.Drawing.Point(400, 108);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(70, 21);
            this.txtZip.TabIndex = 14;
            // 
            // txtPhone1
            // 
            this.txtPhone1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Phone1", true));
            this.txtPhone1.Location = new System.Drawing.Point(97, 162);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(148, 21);
            this.txtPhone1.TabIndex = 16;
            // 
            // txtPhone2
            // 
            this.txtPhone2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Phone2", true));
            this.txtPhone2.Location = new System.Drawing.Point(314, 162);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(156, 21);
            this.txtPhone2.TabIndex = 17;
            // 
            // txtEmail
            // 
            this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "EmailAddress", true));
            this.txtEmail.Location = new System.Drawing.Point(97, 188);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(373, 21);
            this.txtEmail.TabIndex = 18;
            // 
            // label10
            // 
            appearance5.FontData.BoldAsString = "True";
            appearance5.ForeColor = System.Drawing.Color.White;
            this.label10.Appearance = appearance5;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(34, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 14);
            this.label10.TabIndex = 19;
            this.label10.Text = "Phone 1:";
            // 
            // label11
            // 
            appearance6.FontData.BoldAsString = "True";
            appearance6.ForeColor = System.Drawing.Color.White;
            this.label11.Appearance = appearance6;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(256, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 14);
            this.label11.TabIndex = 20;
            this.label11.Text = "Phone 2:";
            // 
            // label12
            // 
            appearance7.FontData.BoldAsString = "True";
            appearance7.ForeColor = System.Drawing.Color.White;
            this.label12.Appearance = appearance7;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(43, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 14);
            this.label12.TabIndex = 21;
            this.label12.Text = "E-mail:";
            // 
            // label1
            // 
            appearance8.FontData.BoldAsString = "True";
            appearance8.ForeColor = System.Drawing.Color.White;
            this.label1.Appearance = appearance8;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 27;
            this.label1.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "LastName", true));
            this.lastNameTextBox.Location = new System.Drawing.Point(321, 30);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(149, 21);
            this.lastNameTextBox.TabIndex = 26;
            // 
            // label2
            // 
            appearance9.FontData.BoldAsString = "True";
            appearance9.ForeColor = System.Drawing.Color.White;
            this.label2.Appearance = appearance9;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 25;
            this.label2.Text = "First Name:";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "FirstName", true));
            this.firstNameTextBox.Location = new System.Drawing.Point(98, 31);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(153, 21);
            this.firstNameTextBox.TabIndex = 24;
            // 
            // detailsToolbars
            // 
            appearance10.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance10.ImageBackground")));
            this.detailsToolbars.Appearance = appearance10;
            this.detailsToolbars.DesignerFlags = 0;
            this.detailsToolbars.DockWithinContainer = this;
            this.detailsToolbars.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.detailsToolbars.ShowQuickCustomizeButton = false;
            this.detailsToolbars.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.Settings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.Text = "Standard";
            ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            this.detailsToolbars.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            appearance11.Image = ((object)(resources.GetObject("appearance11.Image")));
            buttonTool2.SharedProps.AppearancesSmall.Appearance = appearance11;
            buttonTool2.SharedProps.Caption = "Comments";
            buttonTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.detailsToolbars.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2});
            this.detailsToolbars.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.detailsToolbars_ToolClick);
            // 
            // CustomerDetailView_Fill_Panel
            // 
            this.CustomerDetailView_Fill_Panel.AutoScroll = true;
            this.CustomerDetailView_Fill_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(111)))), ((int)(((byte)(168)))));
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.lastNameTextBox);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.firstNameTextBox);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.txtEmail);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.txtPhone2);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.txtPhone1);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.txtZip);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.txtState);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.txtCity);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.txtAddress2);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.txtAddress1);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.ultraPictureBox2);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.ultraPictureBox1);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.label1);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.label2);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.label12);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.label11);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.label10);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.label8);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.label7);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.label6);
            this.CustomerDetailView_Fill_Panel.Controls.Add(this.label5);
            this.CustomerDetailView_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.CustomerDetailView_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerDetailView_Fill_Panel.Location = new System.Drawing.Point(0, 27);
            this.CustomerDetailView_Fill_Panel.Name = "CustomerDetailView_Fill_Panel";
            this.CustomerDetailView_Fill_Panel.Size = new System.Drawing.Size(477, 223);
            this.CustomerDetailView_Fill_Panel.TabIndex = 24;
            // 
            // _CustomerDetailView_Toolbars_Dock_Area_Left
            // 
            this._CustomerDetailView_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CustomerDetailView_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._CustomerDetailView_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._CustomerDetailView_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CustomerDetailView_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
            this._CustomerDetailView_Toolbars_Dock_Area_Left.Name = "_CustomerDetailView_Toolbars_Dock_Area_Left";
            this._CustomerDetailView_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 223);
            this._CustomerDetailView_Toolbars_Dock_Area_Left.ToolbarsManager = this.detailsToolbars;
            // 
            // _CustomerDetailView_Toolbars_Dock_Area_Right
            // 
            this._CustomerDetailView_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CustomerDetailView_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._CustomerDetailView_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._CustomerDetailView_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CustomerDetailView_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(477, 27);
            this._CustomerDetailView_Toolbars_Dock_Area_Right.Name = "_CustomerDetailView_Toolbars_Dock_Area_Right";
            this._CustomerDetailView_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 223);
            this._CustomerDetailView_Toolbars_Dock_Area_Right.ToolbarsManager = this.detailsToolbars;
            // 
            // _CustomerDetailView_Toolbars_Dock_Area_Top
            // 
            this._CustomerDetailView_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CustomerDetailView_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._CustomerDetailView_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._CustomerDetailView_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CustomerDetailView_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._CustomerDetailView_Toolbars_Dock_Area_Top.Name = "_CustomerDetailView_Toolbars_Dock_Area_Top";
            this._CustomerDetailView_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(477, 27);
            this._CustomerDetailView_Toolbars_Dock_Area_Top.ToolbarsManager = this.detailsToolbars;
            // 
            // _CustomerDetailView_Toolbars_Dock_Area_Bottom
            // 
            this._CustomerDetailView_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CustomerDetailView_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._CustomerDetailView_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._CustomerDetailView_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CustomerDetailView_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 250);
            this._CustomerDetailView_Toolbars_Dock_Area_Bottom.Name = "_CustomerDetailView_Toolbars_Dock_Area_Bottom";
            this._CustomerDetailView_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(477, 0);
            this._CustomerDetailView_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.detailsToolbars;
            // 
            // ultraPictureBox1
            // 
            this.ultraPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox1.Image = ((object)(resources.GetObject("ultraPictureBox1.Image")));
            this.ultraPictureBox1.Location = new System.Drawing.Point(7, 6);
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            this.ultraPictureBox1.Size = new System.Drawing.Size(124, 17);
            this.ultraPictureBox1.TabIndex = 28;
            // 
            // ultraPictureBox2
            // 
            this.ultraPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox2.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox2.Image = ((object)(resources.GetObject("ultraPictureBox2.Image")));
            this.ultraPictureBox2.Location = new System.Drawing.Point(7, 143);
            this.ultraPictureBox2.Name = "ultraPictureBox2";
            this.ultraPictureBox2.Size = new System.Drawing.Size(124, 17);
            this.ultraPictureBox2.TabIndex = 29;
            // 
            // CustomerDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomerDetailView_Fill_Panel);
            this.Controls.Add(this._CustomerDetailView_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._CustomerDetailView_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._CustomerDetailView_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._CustomerDetailView_Toolbars_Dock_Area_Bottom);
            this.Name = "CustomerDetailView";
            this.Size = new System.Drawing.Size(477, 250);
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastNameTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstNameTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailsToolbars)).EndInit();
            this.CustomerDetailView_Fill_Panel.ResumeLayout(false);
            this.CustomerDetailView_Fill_Panel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private Infragistics.Win.Misc.UltraLabel label5;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtAddress1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtAddress2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCity;
		private Infragistics.Win.Misc.UltraLabel label6;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtState;
		private Infragistics.Win.Misc.UltraLabel label7;
		private Infragistics.Win.Misc.UltraLabel label8;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtZip;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPhone1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPhone2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
		private Infragistics.Win.Misc.UltraLabel label10;
		private Infragistics.Win.Misc.UltraLabel label11;
		private Infragistics.Win.Misc.UltraLabel label12;
		private System.Windows.Forms.BindingSource customerBindingSource;
		private Infragistics.Win.Misc.UltraLabel label1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor lastNameTextBox;
		private Infragistics.Win.Misc.UltraLabel label2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor firstNameTextBox;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager detailsToolbars;
		private System.Windows.Forms.Panel CustomerDetailView_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CustomerDetailView_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CustomerDetailView_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CustomerDetailView_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CustomerDetailView_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox2;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;




	}
}
