using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Training.Forms
{
    public partial class Exam : Form
    {
        public DataRow RowEdit = null;

        public Exam(DataRow rowEdit)
        {
            this.RowEdit = rowEdit;

            InitializeComponent();

            this.DBview.AllowUserToAddRows = false;
            this.DBview.AutoGenerateColumns = false;
            this.DBview.AllowUserToDeleteRows = false;
            this.DBview.MultiSelect = false;
            //this.DBview.ReadOnly = true;
            this.DBview.RowHeadersWidth = 5;
            this.DBview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.DBviewSport.DataPropertyName = "sport";
            this.DBviewSport.ReadOnly = true;
            this.DBviewWorker.ReadOnly = true;
            this.DBviewMark.DataPropertyName = "mark";

            this.RefreshData(0);

            this.button1.Click += new EventHandler(this.buttonClick);
            this.button2.Click += new EventHandler(this.buttonClick);
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if (sender == this.button1)
            {
                foreach (var row in this.DBview.Rows)
                {
                    var rowD = ((row as DataGridViewRow).DataBoundItem as DataRowView).Row;
                    var isOld = rowD["old"].ToString().Equals("1");

                    var comm = "";
                    if (!isOld)
                        comm = string.Concat("insert into co_worker_exam(id_co_worker, id_sports_qualification_type, date, mark, id_examinator) values(", rowD["id_co_worker"], ",", rowD["id_sports_qualification_type"], ",'", rowD["date"], "',", rowD["mark"], ",", rowD["id_examinator"], ")");
                    else
                        comm = string.Concat("update co_worker_exam set id_co_worker=", rowD["id_co_worker"], ", id_sports_qualification_type=", rowD["id_sports_qualification_type"], ", date='", rowD["date"], "', mark=", rowD["mark"], ", id_examinator=", rowD["id_examinator"],
                                    " where id_co_worker=", rowD["id_co_worker"], " and id_sports_qualification_type=", rowD["id_sports_qualification_type"], " and date='", rowD["date"], "'");

                    if (string.IsNullOrWhiteSpace(comm) || !Program.Command(comm))
                        return;
                }
            }
            this.Close();
        }



        public void RefreshData(int index)
        {
            //concat_ws(' ',second_name,first_name)
            var date = DateTime.Now.ToString("yyyy MM dd");
            var source = new BindingSource();
            var strSelect = string.Concat("select e.id_co_worker, e.id_sports_qualification_type, e.date, e.mark, e.id_examinator, s.name as sport, true as old",
                        " from co_worker_exam e left outer join sports_qualification_type s on e.id_sports_qualification_type=s.id",
                        " where id_co_worker=", this.RowEdit["id"], " and date='", date, "'",
                        " union all select ", this.RowEdit["id"], " as id_co_worker, s.id as id_sports_qualification_type, '", date, "' as date, 0 as mark, CAST(0 AS SIGNED) as id_examinator, s.name as sport, false as old",
                        " from sports_qualification_type s where s.id != 1 and s.id not in(select id_sports_qualification_type from co_worker_exam where id_co_worker=", this.RowEdit["id"], " and date='", date, "')");
            source.DataSource = Program.GetData(strSelect);
            //(source.DataSource as DataTable).Columns["id_co_woker"].DataType = typeof(Int32);
            this.DBview.DataSource = source;

            if (this.DBview.Rows.Count > 0 && index < this.DBview.Rows.Count)
                this.DBview.Rows[index == -1 ? this.DBview.Rows.Count - 1 : index].Selected = true;
            this.DBview.Select();

            var co_workerTable = Program.GetData("select CAST(id AS SIGNED) as id, concat_ws(' ',second_name,first_name) as name from co_worker where id_qualification_co_worker_type = 3 or id_qualification_co_worker_type = 4");
            this.DBviewWorker.ValueMember = "id";
            this.DBviewWorker.DisplayMember = "name";
            this.DBviewWorker.DataSource = co_workerTable;
            this.DBviewWorker.DataPropertyName = "id_co_worker";

            var examinatorTable = Program.GetData("select CAST(id AS SIGNED) as id, concat_ws(' ',second_name,first_name) as name from co_worker where id_qualification_co_worker_type = 3 || id = 0");
            this.DBviewExaminator.ValueMember = "id";
            this.DBviewExaminator.DisplayMember = "name";
            this.DBviewExaminator.DataSource = examinatorTable;
            this.DBviewExaminator.DataPropertyName = "id_examinator";
            
            //this.setFilter(this.Treeview.SelectedNode);
        }
    }
}
