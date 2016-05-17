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
                this.Controls.Add(this.CreateL("Name positions:", top));
                this.Controls.Add(this.CreateT("name", this.RowEdit != null ? this.RowEdit["name"].ToString() : "", top));
                top += 25;
            }

            if (this.TableType == Training.TableType.CoWorkerQualifications)
            {
                this.Controls.Add(this.CreateL("Name co-worker:", top));
                this.Controls.Add(this.CreateC("select id, first_name + ' ' second_name as name", "name", "id_co_woker", this.RowEdit != null ? int.Parse(this.RowEdit["id_co_woker"].ToString()) : -1, top));
                top += 25;
                this.Controls.Add(this.CreateL("Name sport:", top));
                this.Controls.Add(this.CreateC("select * from sports_qualification_type", "name", "id_qualification_sports_type", this.RowEdit != null ? int.Parse(this.RowEdit["id_qualification_sports_type"].ToString()) : 0, top));
                top += 25;
            }

            if (this.TableType == Training.TableType.Normatives)
            {
            }

            if (this.TableType == Training.TableType.SportQualifications)
            {
                this.Controls.Add(this.CreateL("Name:", top));
                this.Controls.Add(this.CreateT("name", this.RowEdit != null ? this.RowEdit["name"].ToString() : "", top));
                top += 25;
                this.Controls.Add(this.CreateL("Name sport:", top));
                this.Controls.Add(this.CreateT("name_sports", this.RowEdit != null ? this.RowEdit["name_sports"].ToString() : "", top));
                top += 25;
            }

            this.button1.Top = this.button2.Top = top + 5;
            this.Height = this.button1.Top + this.button1.Height + 40;
        }

        private Label CreateL(string text, int top)
        {
            var lb = new Label();
            lb.Left = 10;
            lb.Text = text;
            lb.AutoSize = false;
            lb.TextAlign = ContentAlignment.MiddleRight;
            lb.Top = top;
            return lb;
        }

        private TextBox CreateT(string field, string text, int top)
        {
            var tb = new TextBox();
            tb.Left = 120;
            tb.Text = text;
            tb.Top = top;
            tb.Tag = field;
            return tb;
        }

        private ComboBox CreateC(string sel, string showfield, string field, int index, int top)
        {
            var cb = new ComboBox();
            cb.DataSource = Program.GetData(sel);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.DisplayMember = showfield;
            cb.Left = 120;
            cb.Top = top;
            cb.Tag = field;
            return cb;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if (sender == this.button1 && this.RowEdit == null)
            {
                var controlsT = this.Controls.OfType<TextBox>();
                if (controlsT != null)
                    foreach (var cnt in controlsT)
                        this.Values.Add(cnt.Tag.ToString(), cnt.Text);
                var controlsB = this.Controls.OfType<ComboBox>();
                if (controlsB != null)
                    foreach (var cnt in controlsB)
                        this.Values.Add(cnt.Tag.ToString(), cnt.SelectedIndex);
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
