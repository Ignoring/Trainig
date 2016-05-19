namespace Training.Forms
{
    partial class TablesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablesForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DBview = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBview)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolButtonAdd,
            this.ToolButtonEdit,
            this.ToolButtonDelete,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(676, 31);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolButtonAdd
            // 
            this.ToolButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonAdd.Image")));
            this.ToolButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonAdd.Name = "ToolButtonAdd";
            this.ToolButtonAdd.Size = new System.Drawing.Size(28, 28);
            this.ToolButtonAdd.Text = "Add";
            // 
            // ToolButtonEdit
            // 
            this.ToolButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonEdit.Image")));
            this.ToolButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonEdit.Name = "ToolButtonEdit";
            this.ToolButtonEdit.Size = new System.Drawing.Size(28, 28);
            this.ToolButtonEdit.Text = "Edit";
            // 
            // ToolButtonDelete
            // 
            this.ToolButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonDelete.Image")));
            this.ToolButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonDelete.Name = "ToolButtonDelete";
            this.ToolButtonDelete.Size = new System.Drawing.Size(28, 28);
            this.ToolButtonDelete.Text = "Delete";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // DBview
            // 
            this.DBview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBview.BackgroundColor = System.Drawing.Color.White;
            this.DBview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBview.Location = new System.Drawing.Point(0, 34);
            this.DBview.Name = "DBview";
            this.DBview.Size = new System.Drawing.Size(676, 316);
            this.DBview.TabIndex = 5;
            // 
            // TablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(676, 352);
            this.Controls.Add(this.DBview);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TablesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditTablesForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolButtonAdd;
        private System.Windows.Forms.ToolStripButton ToolButtonEdit;
        private System.Windows.Forms.ToolStripButton ToolButtonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView DBview;
    }
}