namespace MainModule {
    partial class TableTreeView {
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
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            this.ultraTree1 = new Infragistics.Win.UltraWinTree.UltraTree();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTree1
            // 
            this.ultraTree1.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
            this.ultraTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTree1.Location = new System.Drawing.Point(0, 0);
            this.ultraTree1.Name = "ultraTree1";
            this.ultraTree1.Size = new System.Drawing.Size(174, 188);
            this.ultraTree1.TabIndex = 0;
            this.ultraTree1.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.ultraTree1_AfterSelect);
            // 
            // DBTableTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraTree1);
            this.Name = "DBTableTreeView";
            this.Size = new System.Drawing.Size(174, 188);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTree.UltraTree ultraTree1;
    }
}
