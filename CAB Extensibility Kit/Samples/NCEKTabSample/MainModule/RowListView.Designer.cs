namespace MainModule {
    partial class RowListView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowListView));
            this.ultraListView1 = new Infragistics.Win.UltraWinListView.UltraListView();
            ((System.ComponentModel.ISupportInitialize)(this.ultraListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraListView1
            // 
            this.ultraListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraListView1.Location = new System.Drawing.Point(0, 0);
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Transparent;
            appearance1.BorderColor = System.Drawing.Color.Transparent;
            appearance1.BorderColor3DBase = System.Drawing.Color.Transparent;
            this.ultraListView1.MainColumn.HeaderAppearance = appearance1;
            this.ultraListView1.MainColumn.Key = "Hide";
            this.ultraListView1.MainColumn.Text = "Hide";
            this.ultraListView1.MainColumn.Width = 34;
            this.ultraListView1.Name = "ultraListView1";
            this.ultraListView1.Size = new System.Drawing.Size(150, 150);
            this.ultraListView1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraListView1.TabIndex = 0;
            this.ultraListView1.Text = "ultraListView1";
            this.ultraListView1.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details;
            this.ultraListView1.ViewSettingsDetails.CheckBoxStyle = Infragistics.Win.UltraWinListView.CheckBoxStyle.CheckBox;
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance2.ImageBackground")));
            appearance2.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled;
            this.ultraListView1.ViewSettingsDetails.ColumnHeaderAppearance = appearance2;
            this.ultraListView1.ViewSettingsDetails.ColumnHeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraListView1.ViewSettingsDetails.ColumnHeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.ultraListView1.ViewSettingsDetails.ImageSize = new System.Drawing.Size(0, 0);
            this.ultraListView1.ViewSettingsDetails.SubItemColumnsVisibleByDefault = false;
            this.ultraListView1.ItemCheckStateChanged += new Infragistics.Win.UltraWinListView.ItemCheckStateChangedEventHandler(this.ultraListView1_ItemCheckStateChanged);
            // 
            // RowListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraListView1);
            this.Name = "RowListView";
            ((System.ComponentModel.ISupportInitialize)(this.ultraListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinListView.UltraListView ultraListView1;
    }
}
