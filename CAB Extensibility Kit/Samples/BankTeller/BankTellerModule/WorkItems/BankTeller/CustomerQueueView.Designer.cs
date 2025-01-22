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
	partial class CustomerQueueView
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerQueueView));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.btnNextCustomer = new Infragistics.Win.Misc.UltraButton();
            this.listCustomers = new System.Windows.Forms.ListBox();
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNextCustomer
            // 
            appearance1.BorderColor = System.Drawing.Color.Transparent;
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.Name = "Verdana";
            appearance1.FontData.SizeInPoints = 7.5F;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.ImageAlpha = Infragistics.Win.Alpha.Transparent;
            appearance1.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance1.ImageBackground")));
            appearance1.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 12, 5, 0);
            this.btnNextCustomer.Appearance = appearance1;
            this.btnNextCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnNextCustomer.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            appearance2.BorderColor = System.Drawing.Color.Transparent;
            appearance2.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance2.ImageBackground")));
            appearance2.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 12, 5, 0);
            appearance2.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.btnNextCustomer.HotTrackAppearance = appearance2;
		    this.btnNextCustomer.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnNextCustomer.Location = new System.Drawing.Point(39, 27);
            this.btnNextCustomer.Name = "btnNextCustomer";
            appearance3.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance3.ImageBackground")));
            appearance3.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 12, 5, 0);
            appearance3.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.btnNextCustomer.PressedAppearance = appearance3;
            this.btnNextCustomer.ShowFocusRect = false;
            this.btnNextCustomer.ShowOutline = false;
            this.btnNextCustomer.Size = new System.Drawing.Size(129, 26);
            this.btnNextCustomer.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnNextCustomer.TabIndex = 5;
            this.btnNextCustomer.Text = "Accept Customer";
            this.btnNextCustomer.Click += new System.EventHandler(this.OnAcceptCustomer);
            // 
            // listCustomers
            // 
            this.listCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listCustomers.BackColor = System.Drawing.Color.White;
            this.listCustomers.DisplayMember = "Count";
            this.listCustomers.FormattingEnabled = true;
            this.listCustomers.IntegralHeight = false;
            this.listCustomers.Location = new System.Drawing.Point(4, 59);
            this.listCustomers.Name = "listCustomers";
            this.listCustomers.Size = new System.Drawing.Size(181, 338);
            this.listCustomers.TabIndex = 4;
            this.listCustomers.ValueMember = "Count";
            this.listCustomers.SelectedIndexChanged += new System.EventHandler(this.OnCustomerSelectionChanged);
            // 
            // ultraPictureBox1
            // 
            this.ultraPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox1.Image = ((object)(resources.GetObject("ultraPictureBox1.Image")));
            this.ultraPictureBox1.Location = new System.Drawing.Point(8, 6);
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            this.ultraPictureBox1.Size = new System.Drawing.Size(124, 17);
            this.ultraPictureBox1.TabIndex = 6;
            // 
            // ultraGroupBox1
            // 
            appearance4.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance4.ImageBackground")));
            this.ultraGroupBox1.Appearance = appearance4;
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.ultraGroupBox1.Controls.Add(this.ultraPictureBox1);
            this.ultraGroupBox1.Controls.Add(this.btnNextCustomer);
            this.ultraGroupBox1.Controls.Add(this.listCustomers);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(189, 401);
            this.ultraGroupBox1.SupportThemes = false;
            this.ultraGroupBox1.TabIndex = 1;
            // 
            // CustomerQueueView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "CustomerQueueView";
            this.Size = new System.Drawing.Size(189, 401);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private Infragistics.Win.Misc.UltraButton btnNextCustomer;
        private System.Windows.Forms.ListBox listCustomers;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;

	}
}
