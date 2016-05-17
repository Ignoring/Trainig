using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Training.Forms
{
    public partial class TablesForm : Form
    {
        private Training.TableType type = Training.TableType.CoWorkerPositions;
        public TablesForm(Training.TableType t)
        {
            this.type = t;

            InitializeComponent();

            this.ToolButtonAdd.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Training.Images.Add.png"));
            this.ToolButtonEdit.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Training.Images.Edit.jpg"));
            this.ToolButtonDelete.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Training.Images.Delete.png"));
            this.ToolButtonEdit.Enabled = this.ToolButtonDelete.Enabled = false;

            this.ToolButtonAdd.Click += new EventHandler(this.ToolClick);
            this.ToolButtonEdit.Click += new EventHandler(this.ToolClick);
            this.ToolButtonDelete.Click += new EventHandler(this.ToolClickDelete);

            this.DBview.AllowUserToAddRows = false;
            this.DBview.AutoGenerateColumns = false;
            this.DBview.AllowUserToDeleteRows = false;
            this.DBview.RowHeadersWidth = 5;
            this.DBview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DBview.ReadOnly = true;
            this.DBview.SelectionChanged += new EventHandler(this.DBviewSelectionChanged);

            if (this.type == Training.TableType.CoWorkerPositions)
            {
                this.Text = "Co-worker positions";
                this.DBview.Columns.Add("name", "Name");
                this.DBview.Columns[0].DataPropertyName = "name";
                this.DBview.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (this.type == Training.TableType.CoWorkerQualifications)
            {
                this.Text = "Co-worker qualifications";
                this.DBview.Columns.Add("first_name", "First name");
                this.DBview.Columns.Add("second_name", "Second name");
                this.DBview.Columns.Add("name", "Name");
                this.DBview.Columns[0].DataPropertyName = "first_name";
                this.DBview.Columns[1].DataPropertyName = "second_name";
                this.DBview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.DBview.Columns[2].DataPropertyName = "name";
            }

            if (this.type == Training.TableType.Normatives)
            {
                this.Text = "Normatives";
                this.DBview.Columns.Add("sport", "Sport name");
                this.DBview.Columns.Add("sex", "Sex");
                this.DBview.Columns.Add("from", "From");
                this.DBview.Columns.Add("to", "To");
                this.DBview.Columns.Add("hours", "Hours");
                this.DBview.Columns[0].DataPropertyName = "sport";
                this.DBview.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.DBview.Columns[1].DataPropertyName = "second_name";
                this.DBview.Columns[2].DataPropertyName = "from";
                this.DBview.Columns[3].DataPropertyName = "to";
                this.DBview.Columns[4].DataPropertyName = "hours";
            }

            if (this.type == Training.TableType.SportQualifications)
            {
                this.Text = "Sport qualifications";
                this.DBview.Columns.Add("name", "Name");
                this.DBview.Columns.Add("name_sports", "Name sport");
                this.DBview.Columns[0].DataPropertyName = "name";
                this.DBview.Columns[1].DataPropertyName = "name_sports";
                this.DBview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            this.RefreshData(0);
        }

        private void ToolClick(object sender, EventArgs e)
        {
            var frm = new Forms.EditTablesForm(this.type, sender == this.ToolButtonEdit && this.DBview.CurrentRow != null ? (this.DBview.CurrentRow.DataBoundItem as DataRowView).Row : null);
            var bitMap = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(string.Concat("Training.Images.", (sender == this.ToolButtonEdit ? "Edit.jpg" : "Add.png"))));
            bitMap.MakeTransparent(Color.White);
            frm.Icon = Icon.FromHandle(bitMap.GetHicon());
            frm.Owner = this;
            frm.OkClick += this.OkClick;
            frm.ShowDialog();
        }

        private void OkClick(object sender, EventArgs e)
        {
            MessageBox.Show("Save");

            var frm = sender as EditTablesForm;

            if (frm != null)
                frm.Close();
        }


        private void ToolClickDelete(object sender, EventArgs e)
        {
            var row = this.DBview.CurrentRow != null ? (this.DBview.CurrentRow.DataBoundItem as DataRowView).Row : null;
            if (row == null)
                return;
            var comm = string.Concat("delete from sports_qualification_type where id=", row["id"].ToString());
            if (this.type == Training.TableType.CoWorkerPositions)
                comm = string.Concat("delete from co_worker_qualification_type where id=", row["id"].ToString());

            if (this.type == Training.TableType.CoWorkerQualifications)
                comm = string.Concat("delete from co_woker_qualification_sports where id=", row["id"].ToString());

            if (this.type == Training.TableType.Normatives)
                comm = string.Concat("delete from normatives where id=", row["id"].ToString());

            if (!Program.Command(comm))
                return;
            row.Delete();
        }

        public void RefreshData(int index)
        {
            if (this.type == Training.TableType.CoWorkerPositions)
                this.DBview.DataSource = Program.GetData("SELECT * FROM co_worker_qualification_type");

            if (this.type == Training.TableType.CoWorkerQualifications)
                this.DBview.DataSource = Program.GetData("SELECT c.*, w.first_name, w.second_name, s.name, s.name_sports FROM co_woker_qualification_sports c left outer join co_worker w on c.id_co_woker=w.Id left outer join sports_qualification_type s on c.id_qualification_sports_type=s.id");

            if (this.type == Training.TableType.Normatives)
                this.DBview.DataSource = Program.GetData("SELECT c.*, w.name, w.name_sports, s.name as sex FROM normatives c left outer join sports_qualification_type w on c.id_sports_qualification_type=w.Id left outer join sex_type s on c.id_sex_type=s.id");

            if (this.type == Training.TableType.SportQualifications)
                this.DBview.DataSource = Program.GetData("SELECT * FROM sports_qualification_type");

            if (this.DBview.Rows.Count > 0 && index < this.DBview.Rows.Count)
                this.DBview.Rows[index == -1 ? this.DBview.Rows.Count - 1 : index].Selected = true;

            this.DBview.Select();
        }

        private void DBviewSelectionChanged(object sender, EventArgs e)
        {
            this.ToolButtonEdit.Enabled = this.ToolButtonDelete.Enabled = this.DBview.CurrentRow != null;
        }
    }
}
