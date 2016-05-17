using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using TraningDAL.InterfaceBasics;

namespace Training
{
    public partial class Training : Form
    {
        public enum TableType
        {
            CoWorkerPositions = 0x0,
            CoWorkerQualifications = 0x2,
            Normatives = 0x4,
            SportQualifications = 0x8,
        }


        public Training()
        {
            InitializeComponent();

            this.Icon = new Icon(Assembly.GetEntryAssembly().GetManifestResourceStream("Training.Images.SportBase.ico"));

            this.Treeview.Nodes.Add("rootNode", "Co-wokers");
            this.Treeview.Nodes[0].Nodes.Add("directors", "Directors");
            this.Treeview.Nodes[0].Nodes.Add("trainers", "Trainers");
            this.Treeview.Nodes[0].Nodes.Add("athletes", "Athletes");

            this.DBview.AllowUserToAddRows = false;
            this.DBview.AutoGenerateColumns = false;
            this.DBview.AllowUserToDeleteRows = false;
            this.DBview.RowHeadersWidth = 5;
            this.DBview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DBview.ReadOnly = true;

            this.DBviewFirstName.DataPropertyName = "first_name";
            this.DBviewSecondName.DataPropertyName = "second_name";
            this.DBviewPosition.DataPropertyName = "name";
            this.DBviewSex.DataPropertyName = "sex_name";
            this.DBviewAge.DataPropertyName = "age";
            this.DBview.SelectionChanged += new EventHandler(this.DBviewSelectionChanged);
            this.RefreshData(0);

            this.ToolButtonAdd.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Training.Images.Add.png"));
            this.ToolButtonEdit.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Training.Images.Edit.jpg"));
            this.ToolButtonDelete.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Training.Images.Delete.png"));
            this.ToolButtonTest.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Training.Images.Test.jpg"));
            this.ToolButtonReport.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Training.Images.Report.jpg"));
            this.ToolButtonEdit.Enabled = this.ToolButtonDelete.Enabled = this.ToolButtonTest.Enabled = this.ToolButtonReport.Enabled = false;

            this.ToolButtonAdd.Click += new EventHandler(this.ToolClick);
            this.ToolButtonEdit.Click += new EventHandler(this.ToolClick);
            this.ToolButtonDelete.Click += new EventHandler(this.ToolClickDelete);

            this.Treeview.ExpandAll();
            // Hookup a DrawMode Event Handler
            this.Treeview.DrawNode += this.TreeviewDrawNode;
            // Set DrawMode and HideSelection
            this.Treeview.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.Treeview.SelectedNode = this.Treeview.Nodes[0];
            this.Treeview.HideSelection = false;
            this.Treeview.AfterSelect += new TreeViewEventHandler(this.TreeviewAfterSelect);

            this.Options.Click += new EventHandler(this.OptionsClick);
            this.About.Click += new EventHandler(this.AboutClick);
            this.Quit.Click += new EventHandler(this.QuitClick);

            this.CoWorkerPositions.Click += new EventHandler(this.MenuEditClick);
            this.CoWorkerQualifications.Click += new EventHandler(this.MenuEditClick);
            this.Normativs.Click += new EventHandler(this.MenuEditClick);
            this.SportQualifications.Click += new EventHandler(this.MenuEditClick);
        }

        private void AboutClick(object sender, EventArgs e)
        {
            var frm = new Forms.About();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void MenuEditClick(object sender, EventArgs e)
        {
            var type = sender == this.CoWorkerPositions ? TableType.CoWorkerPositions : sender == this.CoWorkerQualifications ? TableType.CoWorkerQualifications : sender == this.Normativs ? TableType.Normatives : TableType.SportQualifications;
            var frm = new Forms.TablesForm(type);
            frm.Icon = new Icon(Assembly.GetEntryAssembly().GetManifestResourceStream("Training.Images.SportBase.ico"));
            frm.Owner = this;
            frm.ShowDialog();
        }


        private void TreeviewDrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // first, let .NET draw the Node with its defaults
            e.DrawDefault = true;
            // Now update the highlighting or not
            if (e.State == TreeNodeStates.Selected)
            {
                e.Node.BackColor = SystemColors.Highlight;
                e.Node.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                e.Node.BackColor = ((TreeView)sender).BackColor;
                e.Node.ForeColor = ((TreeView)sender).ForeColor;
            }
        }

        private void TreeviewAfterSelect(object sender, TreeViewEventArgs e)
        {
            this.setFilter(e.Node);
        }

        private void setFilter(TreeNode node)
        {
            if (this.DBview.DataSource == null)
                return;
            if (node == null || node.Parent == null)
                (this.DBview.DataSource as BindingSource).Filter = "";
            else
                (this.DBview.DataSource as BindingSource).Filter = string.Concat("name = '", node.Text.Substring(0, node.Text.Length - 1), "'");
        }

        private void QuitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolClick(object sender, EventArgs e)
        {
            var frm = new Forms.CoWoker(sender == this.ToolButtonEdit && this.DBview.CurrentRow != null ? (this.DBview.CurrentRow.DataBoundItem as DataRowView).Row : null);
            var bitMap = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(string.Concat("Training.Images.", (sender == this.ToolButtonEdit ? "Edit.jpg" : "Add.png"))));
            bitMap.MakeTransparent(Color.White);
            frm.Icon = Icon.FromHandle(bitMap.GetHicon());
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void ToolClickDelete(object sender, EventArgs e)
        {
            var row = this.DBview.CurrentRow != null ? (this.DBview.CurrentRow.DataBoundItem as DataRowView).Row : null;
            if (row == null)
                return;
            var comm = string.Concat("delete from co_worker where id=", row["id"].ToString());
            if (!Program.Command(comm))
                return;
            row.Delete();
        }

        private void OptionsClick(object sender, EventArgs e)
        {
            var frm = new Forms.Settings();
            frm.Owner = this;
            frm.OkClick += this.OkClick;
            frm.ShowDialog();
        }

        private void OkClick(object sender, EventArgs e)
        {
            MessageBox.Show("Save settings");
        }

        public void RefreshData(int index)
        {
            var source = new BindingSource();
            source.DataSource = Program.GetData("SELECT c.*, t.name, s.name as sex_name FROM co_worker c left outer join co_worker_qualification_type t on c.id_qualification_co_worker_type=t.Id left outer join sex_type s on c.id_sex_type=s.Id");
            this.setFilter(this.Treeview.SelectedNode);
            this.DBview.DataSource = source;
            if (this.DBview.Rows.Count > 0 && index < this.DBview.Rows.Count)
                this.DBview.Rows[index == -1 ? this.DBview.Rows.Count - 1: index].Selected = true;
            this.DBview.Select();
        }

        private void DBviewSelectionChanged(object sender, EventArgs e)
        {
            this.ToolButtonEdit.Enabled = this.ToolButtonDelete.Enabled = this.ToolButtonTest.Enabled = this.ToolButtonReport.Enabled = this.DBview.CurrentRow != null;
        }
    }
}
