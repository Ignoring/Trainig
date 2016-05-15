using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TraningDAL.InterfaceBasics;

namespace Training
{
    public partial class Training : Form
    {
        public Training()
        {
            InitializeComponent();
            this.Treeview.Nodes.Add("rootNode", "Co-wokers");
            this.Treeview.Nodes[0].Nodes.Add("directors", "Directors");
            this.Treeview.Nodes[0].Nodes.Add("trainers", "Trainers");
            this.Treeview.Nodes[0].Nodes.Add("athletes", "Athletes");

            this.DBview.AllowUserToAddRows = false;
            this.DBview.AutoGenerateColumns = false;
            this.DBview.AllowUserToDeleteRows = false;
            this.DBview.RowHeadersWidth = 5;
            this.DBview.DataSource = MySqlConnectorBase.GetData("127.0.0.1", Program.MySqlPort, "root", "", "select * from co_worker");

            this.DBviewFirstName.DataPropertyName = "first_name";
            this.DBviewSecondName.DataPropertyName = "second_name";
            this.DBviewSex.DataPropertyName = "sex_name";
            this.DBviewAge.DataPropertyName = "age";

            this.Shown += new EventHandler(this.TrainingShown);
        }

        private void TrainingShown(object sender, EventArgs e)
        {
            this.Treeview.Select();
            this.Treeview.Nodes[0].Collapse();
            this.Treeview.CollapseAll();
        }
    }
}
