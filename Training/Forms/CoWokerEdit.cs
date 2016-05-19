using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TraningDAL.InterfaceBasics;

namespace Training.Forms
{
    public partial class CoWoker : Form
    {
        private DataRow rowEdit = null;

        public CoWoker(DataRow row)
        {
            InitializeComponent();

            this.rowEdit = row;

            this.comboBox1.DataSource = Program.GetData("SELECT * FROM co_worker_qualification_type");
            this.comboBox2.DataSource = Program.GetData("SELECT * FROM sex_type");
            this.comboBox2.DropDownStyle = this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.DisplayMember = this.comboBox1.DisplayMember = "name";
            this.comboBox2.DisplayMember = this.comboBox1.DisplayMember = "name";
            this.comboBox2.SelectedIndex = this.comboBox1.SelectedIndex = 0;

            if (this.rowEdit != null)
            {
                this.comboBox1.SelectedIndex = int.Parse(this.rowEdit["id_qualification_co_worker_type"].ToString()) - 1;
                this.comboBox2.SelectedIndex = int.Parse(this.rowEdit["id_sex_type"].ToString()) - 1;

                this.textBox1.Text = this.rowEdit["first_name"].ToString();
                this.textBox2.Text = this.rowEdit["second_name"].ToString();
                this.textBox5.Text = this.rowEdit["age"].ToString();
            }

            this.button1.Click += new EventHandler(this.buttonClick);
            this.button2.Click += new EventHandler(this.buttonClick);
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if (sender == this.button1)
            {
                var fn = this.textBox1.Text;
                var sn = this.textBox2.Text;
                var age = this.textBox5.Text;
                var type = this.comboBox1.SelectedIndex + 1;
                var sex = this.comboBox2.SelectedIndex + 1;

                var comm = string.Concat("insert into co_worker(first_name,second_name,id_qualification_co_worker_type,id_sex_type,age) values('", fn, "','", sn, "',", type, ",", sex, ",", age, ")");
                if (this.rowEdit != null)
                    comm = string.Concat("update co_worker set first_name='", fn, "', second_name='", sn, "', id_qualification_co_worker_type=", type, ", id_sex_type=", sex, ", age=", age, " where id=", this.rowEdit["id"]);
                if (!Program.Command(comm))
                    return;

                if (this.rowEdit != null)
                {
                    this.rowEdit["id_qualification_co_worker_type"] = type;
                    this.rowEdit["id_sex_type"] = sex;

                    this.rowEdit["name"] = this.comboBox1.Text;
                    this.rowEdit["sex_name"] = this.comboBox2.Text;

                    this.rowEdit["first_name"] = fn;
                    this.rowEdit["second_name"] = sn;
                    this.rowEdit["age"] = int.Parse(age);
                }
                else
                {
                    (this.Owner as Training).RefreshData(-1);
                }
            }

            this.Close();
        }
    }
}
