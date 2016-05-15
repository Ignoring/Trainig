namespace Training
{
    partial class Training
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Training));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.Options = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.Treeview = new System.Windows.Forms.TreeView();
            this.DBview = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonReport = new System.Windows.Forms.ToolStripButton();
            this.DBviewFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBviewSecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBviewSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBviewAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBview)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Options,
            this.Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(37, 20);
            this.File.Text = "File";
            // 
            // Options
            // 
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(61, 20);
            this.Options.Text = "Options";
            // 
            // Help
            // 
            this.Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpHelp,
            this.About});
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(44, 20);
            this.Help.Text = "Help";
            // 
            // HelpHelp
            // 
            this.HelpHelp.Name = "HelpHelp";
            this.HelpHelp.Size = new System.Drawing.Size(107, 22);
            this.HelpHelp.Text = "Help";
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(107, 22);
            this.About.Text = "About";
            // 
            // Treeview
            // 
            this.Treeview.Location = new System.Drawing.Point(0, 54);
            this.Treeview.Name = "Treeview";
            this.Treeview.Size = new System.Drawing.Size(218, 291);
            this.Treeview.TabIndex = 1;
            // 
            // DBview
            // 
            this.DBview.BackgroundColor = System.Drawing.Color.White;
            this.DBview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DBviewFirstName,
            this.DBviewSecondName,
            this.DBviewSex,
            this.DBviewAge});
            this.DBview.Location = new System.Drawing.Point(224, 54);
            this.DBview.Name = "DBview";
            this.DBview.Size = new System.Drawing.Size(613, 291);
            this.DBview.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolButtonAdd,
            this.ToolButtonEdit,
            this.ToolButtonDelete,
            this.toolStripSeparator1,
            this.ToolButtonTest,
            this.toolStripSeparator2,
            this.ToolButtonReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(837, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolButtonAdd
            // 
            this.ToolButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonAdd.Image")));
            this.ToolButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonAdd.Name = "ToolButtonAdd";
            this.ToolButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.ToolButtonAdd.Text = "Add";
            // 
            // ToolButtonEdit
            // 
            this.ToolButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonEdit.Image")));
            this.ToolButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonEdit.Name = "ToolButtonEdit";
            this.ToolButtonEdit.Size = new System.Drawing.Size(23, 22);
            this.ToolButtonEdit.Text = "Edit";
            // 
            // ToolButtonDelete
            // 
            this.ToolButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonDelete.Image")));
            this.ToolButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonDelete.Name = "ToolButtonDelete";
            this.ToolButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.ToolButtonDelete.Text = "Delete";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolButtonTest
            // 
            this.ToolButtonTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonTest.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonTest.Image")));
            this.ToolButtonTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonTest.Name = "ToolButtonTest";
            this.ToolButtonTest.Size = new System.Drawing.Size(23, 22);
            this.ToolButtonTest.Text = "Test";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolButtonReport
            // 
            this.ToolButtonReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonReport.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonReport.Image")));
            this.ToolButtonReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonReport.Name = "ToolButtonReport";
            this.ToolButtonReport.Size = new System.Drawing.Size(23, 22);
            this.ToolButtonReport.Text = "Report";
            // 
            // DBviewFirstName
            // 
            this.DBviewFirstName.HeaderText = "First name";
            this.DBviewFirstName.Name = "DBviewFirstName";
            this.DBviewFirstName.Width = 150;
            // 
            // DBviewSecondName
            // 
            this.DBviewSecondName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DBviewSecondName.HeaderText = "Second name";
            this.DBviewSecondName.Name = "DBviewSecondName";
            // 
            // DBviewSex
            // 
            this.DBviewSex.HeaderText = "Sex";
            this.DBviewSex.Name = "DBviewSex";
            this.DBviewSex.Width = 80;
            // 
            // DBviewAge
            // 
            this.DBviewAge.HeaderText = "Age";
            this.DBviewAge.Name = "DBviewAge";
            this.DBviewAge.Width = 50;
            // 
            // Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(837, 344);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.DBview);
            this.Controls.Add(this.Treeview);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Training";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sports base";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBview)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem Options;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.ToolStripMenuItem HelpHelp;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.TreeView Treeview;
        private System.Windows.Forms.DataGridView DBview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolButtonAdd;
        private System.Windows.Forms.ToolStripButton ToolButtonEdit;
        private System.Windows.Forms.ToolStripButton ToolButtonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ToolButtonTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ToolButtonReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBviewFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBviewSecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBviewSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBviewAge;
    }
}

