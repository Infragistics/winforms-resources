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
	partial class CustomerHeaderView
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
            this.lblFirstName = new Infragistics.Win.Misc.UltraLabel();
            this.lblLastName = new Infragistics.Win.Misc.UltraLabel();
            this.lblCustomerID = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerID = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtFirstName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtLastName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.Name = "Verdana";
            appearance1.FontData.SizeInPoints = 7.5F;
            appearance1.ForeColor = System.Drawing.Color.White;
            this.lblFirstName.Appearance = appearance1;
            this.lblFirstName.Location = new System.Drawing.Point(14, 36);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(71, 14);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.Name = "Verdana";
            appearance2.FontData.SizeInPoints = 7.5F;
            appearance2.ForeColor = System.Drawing.Color.White;
            this.lblLastName.Appearance = appearance2;
            this.lblLastName.Location = new System.Drawing.Point(15, 63);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(69, 14);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblCustomerID
            // 
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "Verdana";
            appearance3.FontData.SizeInPoints = 7.5F;
            appearance3.ForeColor = System.Drawing.Color.White;
            this.lblCustomerID.Appearance = appearance3;
            this.lblCustomerID.Location = new System.Drawing.Point(5, 10);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(81, 14);
            this.lblCustomerID.TabIndex = 2;
            this.lblCustomerID.Text = "Customer ID:";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "ID", true));
            this.txtCustomerID.Location = new System.Drawing.Point(88, 6);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(168, 21);
            this.txtCustomerID.TabIndex = 3;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(BankTellerCommon.Customer);
            // 
            // txtFirstName
            // 
            this.txtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "FirstName", true));
            this.txtFirstName.Location = new System.Drawing.Point(88, 32);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(168, 21);
            this.txtFirstName.TabIndex = 4;
            // 
            // txtLastName
            // 
            this.txtLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "LastName", true));
            this.txtLastName.Location = new System.Drawing.Point(88, 59);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(168, 21);
            this.txtLastName.TabIndex = 5;
            // 
            // CustomerHeaderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Name = "CustomerHeaderView";
            this.Size = new System.Drawing.Size(387, 94);
            this.Load += new System.EventHandler(this.CustomerHeaderView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraLabel lblCustomerID;
		private Infragistics.Win.Misc.UltraLabel lblFirstName;
		private Infragistics.Win.Misc.UltraLabel lblLastName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCustomerID;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFirstName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLastName;
		private System.Windows.Forms.BindingSource customerBindingSource;
	}
}
