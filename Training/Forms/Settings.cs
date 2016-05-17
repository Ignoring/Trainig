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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            this.textBox1.Text = Properties.Settings.Default.server;
            this.textBox2.Text = Properties.Settings.Default.port.ToString();
            this.textBox3.Text = Properties.Settings.Default.user;
            this.textBox4.Text = Properties.Settings.Default.password;
            this.textBox5.Text = Properties.Settings.Default.db;

            this.button1.Click += new EventHandler(this.buttonClick);
            this.button2.Click += new EventHandler(this.buttonClick);
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Properties.Settings.Default.server = this.textBox1.Text;
            Properties.Settings.Default.port = int.Parse(this.textBox2.Text);
            Properties.Settings.Default.user = this.textBox3.Text;
            Properties.Settings.Default.password = this.textBox4.Text;
            Properties.Settings.Default.db = this.textBox5.Text;

            this.Close();

            if (sender == this.button1 && this.OkClick != null)
                this.OkClick(this, new EventArgs());
        }

        public EventHandler OkClick;
    }
}
