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
    public partial class EditTablesForm : Form
    {
        public DataRow RowEdit = null;
        public Training.TableType TableType = Training.TableType.CoWorkerPositions;
        public Dictionary<string, object> Values = new Dictionary<string, object>();

        public EditTablesForm(Training.TableType type, DataRow row)
        {
            this.TableType = type;
            this.RowEdit = row;
            InitializeComponent();

            this.setData();

            this.button1.Click += new EventHandler(this.buttonClick);
            this.button2.Click += new EventHandler(this.buttonClick);
        }

        private void setData()
        {
            var top = 10;
            if (this.TableType == Training.TableType.CoWorkerPositions)
            {
                this.CreateL("Name positions:", top);
                this.CreateT("name", this.RowEdit != null ? this.RowEdit["name"].ToString() : "", top);
                top += 25;
            }

            if (this.TableType == Training.TableType.CoWorkerQualifications)
            {
                this.CreateL("Name co-worker:", top);
                this.CreateC("select id, first_name, second_name, CONCAT_WS(' ',first_name,second_name) as full_name from co_worker", "full_name", "id_co_woker", this.RowEdit != null ? int.Parse(this.RowEdit["id_co_woker"].ToString()) : -1, top);
                top += 25;
                this.CreateL("Name sport:", top);
                this.CreateC("select * from sports_qualification_type", "name", "id_sports_qualification_type", this.RowEdit != null ? int.Parse(this.RowEdit["id_sports_qualification_type"].ToString()) : 0, top);
                top += 25;
            }

            if (this.TableType == Training.TableType.Normatives)
            {
                this.CreateL("Name sport:", top);
                this.CreateC("select * from sports_qualification_type", "name", "id_sports_qualification_type", this.RowEdit != null ? int.Parse(this.RowEdit["id_sports_qualification_type"].ToString()) : 0, top);
                top += 25;
                this.CreateL("Sex:", top);
                this.CreateC("select * from sex_type", "name", "id_sex_type", this.RowEdit != null ? int.Parse(this.RowEdit["id_sex_type"].ToString()) : 0, top);
                top += 25;
                this.CreateL("Start time:", top);
                this.CreateT("start_time_sp", this.RowEdit != null ? this.RowEdit["start_time_sp"].ToString() : "0.00", top);
                top += 25;
                this.CreateL("End time:", top);
                this.CreateT("end_time_sp", this.RowEdit != null ? this.RowEdit["end_time_sp"].ToString() : "0.00", top);
                top += 25;
                this.CreateL("Hours:", top);
                this.CreateT("hours", this.RowEdit != null ? this.RowEdit["hours"].ToString() : "0.00", top);
                top += 25;
            }

            if (this.TableType == Training.TableType.SportQualifications)
            {
                this.CreateL("Name:", top);
                this.CreateT("name", this.RowEdit != null ? this.RowEdit["name"].ToString() : "", top);
                top += 25;
                this.CreateL("Name sport:", top);
                this.CreateT("name_sports", this.RowEdit != null ? this.RowEdit["name_sports"].ToString() : "", top);
                top += 25;
            }

            this.button1.Top = this.button2.Top = top + 5;
            this.Height = this.button1.Top + this.button1.Height + 40;
        }

        private void CreateL(string text, int top)
        {
            var lb = new Label();
            lb.Left = 10;
            lb.Text = text;
            lb.AutoSize = false;
            lb.TextAlign = ContentAlignment.MiddleRight;
            lb.Top = top;
            this.Controls.Add(lb);
        }

        private void CreateT(string field, string text, int top)
        {
            var tb = new TextBox();
            tb.Left = 120;
            tb.Text = text;
            tb.Top = top;
            tb.Tag = field;
            this.Controls.Add(tb);
        }

        private void CreateC(string sel, string showfield, string field, int id, int top)
        {
            var table = Program.GetData(sel);
            var rows = table != null ? table.Select(string.Concat("id=", id)) : null;
            var cb = new ComboBox();
            this.Controls.Add(cb);
            cb.DataSource = table;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.DisplayMember = showfield;
            cb.Left = 120;
            cb.Top = top;
            cb.Tag = field;
            if (rows != null && rows.Length > 0)
                cb.SelectedIndex = table.Rows.IndexOf(rows[0]);
        }

        private void buttonClick(object sender, EventArgs e)
        {
            this.Values.Clear();
            if (sender == this.button1)
            {
                var fields = new string[] { "start_time_sp", "end_time_sp", "hours" };
                var controlsT = this.Controls.OfType<TextBox>();
                if (controlsT != null)
                    foreach (var cnt in controlsT)
                    {
                        var field = cnt.Tag.ToString();
                        var value = !fields.Contains(field) ? (object)cnt.Text : string.IsNullOrEmpty(cnt.Text) ? 0.00 : double.Parse(cnt.Text);
                        if (this.RowEdit == null)
                            this.Values.Add(field, value);
                        else
                            this.RowEdit[field] = value;
                    }
                var controlsB = this.Controls.OfType<ComboBox>();
                if (controlsB != null)
                    foreach (var cnt in controlsB)
                    {
                        var field = cnt.Tag.ToString();
                        var value = cnt.SelectedIndex + 1;
                        var row = cnt.SelectedItem as DataRowView;
                        if (this.RowEdit == null)
                            this.Values.Add(field, value);
                        else
                        {
                            if (field == "id_co_woker")
                            {
                                this.RowEdit["id_co_woker"] = row["id"];
                                this.RowEdit["first_name"] = row["first_name"];
                                this.RowEdit["second_name"] = row["second_name"];
                            }
                            if (field == "id_sports_qualification_type")
                            {
                                this.RowEdit["id_sports_qualification_type"] = row["id"];
                                this.RowEdit["name"] = row["name"];
                                this.RowEdit["name_sports"] = row["name_sports"];
                            }
                            if (field == "id_sex_type")
                            {
                                this.RowEdit["id_sex_type"] = row["id"];
                                this.RowEdit["sex"] = row["name"];
                            }
                        }
                    }
            }
            if (sender == this.button1 && this.OkClick != null)
                this.OkClick(this, new EventArgs());
            else
                if (sender == this.button2)
                    this.Close();
        }

        public EventHandler OkClick;
    }
}
