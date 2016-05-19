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
            this.DBview.MultiSelect = false;
            this.DBview.ReadOnly = true;
            this.DBview.RowHeadersWidth = 5;
            this.DBview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                this.DBview.Columns.Add("start_time_sp", "Start time");
                this.DBview.Columns.Add("end_time_sp", "End time");
                this.DBview.Columns.Add("hours", "Hours");
                this.DBview.Columns[0].DataPropertyName = "name";
                this.DBview.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.DBview.Columns[1].DataPropertyName = "sex";
                this.DBview.Columns[2].DataPropertyName = "start_time_sp";
                this.DBview.Columns[3].DataPropertyName = "end_time_sp";
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
            var row = this.getSelectedRow();
            var frm = new Forms.EditTablesForm(this.type, sender == this.ToolButtonEdit && row != null ? (row.DataBoundItem as DataRowView).Row : null);
            var bitMap = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(string.Concat("Training.Images.", (sender == this.ToolButtonEdit ? "Edit.jpg" : "Add.png"))));
            bitMap.MakeTransparent(Color.White);
            frm.Icon = Icon.FromHandle(bitMap.GetHicon());
            frm.Owner = this;
            frm.OkClick += this.OkClick;
            frm.ShowDialog();
        }

        private void OkClick(object sender, EventArgs e)
        {
            var frm = sender as EditTablesForm;

            var comm = "";
            if (this.type == Training.TableType.CoWorkerPositions)
            {
                if (frm.RowEdit == null)
                    comm = string.Concat("insert into co_worker_qualification_type(name) values('", frm.Values["name"], "')");
                else
                    comm = string.Concat("update co_worker_qualification_type set name='", frm.RowEdit["name"], "' where id=", frm.RowEdit["id"]);
            }

            if (this.type == Training.TableType.CoWorkerQualifications)
            {
                if (frm.RowEdit == null)
                    comm = string.Concat("insert into co_woker_qualification_sports(id_co_woker, id_sports_qualification_type) values(", frm.Values["id_co_woker"], ",", frm.Values["id_sports_qualification_type"], ")");
                else
                    comm = string.Concat("update co_woker_qualification_sports set id_co_woker=", frm.RowEdit["id_co_woker"], ", id_sports_qualification_type=", frm.RowEdit["id_sports_qualification_type"], " where id_co_woker=", frm.RowEdit["id_co_woker"], " and id_sports_qualification_type=", frm.RowEdit["id_sports_qualification_type"]);
            }

            if (this.type == Training.TableType.Normatives)
            {
                if (frm.RowEdit == null)
                    comm = string.Concat("insert into normatives(id_sports_qualification_type, id_sex_type, start_time_sp, end_time_sp, hours) values(", frm.Values["id_sports_qualification_type"], ",", frm.Values["id_sex_type"], ",", frm.Values["start_time_sp"], ",", frm.Values["end_time_sp"], ",", frm.Values["hours"], ")");
                else
                    comm = string.Concat("update normatives set start_time_sp=", frm.RowEdit["start_time_sp"], ", end_time_sp=", frm.RowEdit["end_time_sp"], ", hours=", frm.RowEdit["hours"], " where id_sports_qualification_type=", frm.RowEdit["id_sports_qualification_type"], " and id_sex_type=", frm.RowEdit["id_sex_type"]);
            }

            if (this.type == Training.TableType.SportQualifications)
            {
                if (frm.RowEdit == null)
                    comm = string.Concat("insert into sports_qualification_type(name, name_sports) values('", frm.Values["name"], "','", frm.Values["name_sports"], "')");
                else
                    comm = string.Concat("update sports_qualification_type set name='", frm.RowEdit["name"], "', name_sports='", frm.RowEdit["name_sports"], "' where id=", frm.RowEdit["id"]);
            }

            if (string.IsNullOrWhiteSpace(comm) || !Program.Command(comm))
                return;

            if (frm.RowEdit == null)
                this.RefreshData(-1);
            
            if (frm != null)
                frm.Close();
        }


        private void ToolClickDelete(object sender, EventArgs e)
        {
            var rowGrid = this.getSelectedRow();
            var row = rowGrid != null ? (rowGrid.DataBoundItem as DataRowView).Row : null;
            if (row == null)
                return;
            var comm = "";
            if (this.type == Training.TableType.CoWorkerPositions)
                comm = string.Concat("delete from co_worker_qualification_type where id=", row["id"]);

            if (this.type == Training.TableType.CoWorkerQualifications)
                comm = string.Concat("delete from co_woker_qualification_sports where id_co_woker=", row["id_co_woker"], " and id_sports_qualification_type=", row["id_sports_qualification_type"]);

            if (this.type == Training.TableType.Normatives)
                comm = string.Concat("delete from normatives where id=", row["id"]);

            if (this.type == Training.TableType.SportQualifications)
                comm = string.Concat("delete from sports_qualification_type where id=", row["id"]);

            if (!Program.Command(comm))
                return;
            row.Delete();
        }

        public void RefreshData(int index)
        {
            if (this.type == Training.TableType.CoWorkerPositions)
                this.DBview.DataSource = Program.GetData("SELECT * FROM co_worker_qualification_type");

            if (this.type == Training.TableType.CoWorkerQualifications)
                this.DBview.DataSource = Program.GetData("SELECT c.*, w.first_name, w.second_name, s.name, s.name_sports FROM co_woker_qualification_sports c left outer join co_worker w on c.id_co_woker=w.Id left outer join sports_qualification_type s on c.id_sports_qualification_type=s.id");

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
            this.ToolButtonEdit.Enabled = this.ToolButtonDelete.Enabled = this.getSelectedRow() != null;
        }

        private DataGridViewRow getSelectedRow()
        {
            return this.DBview.SelectedRows != null && this.DBview.SelectedRows.Count > 0 ? this.DBview.SelectedRows[0] : null;
        }
    }
}
