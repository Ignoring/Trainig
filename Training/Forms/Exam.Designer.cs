namespace Training.Forms
{
    partial class Exam
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DBview = new System.Windows.Forms.DataGridView();
            this.DBviewWorker = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DBviewSport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBviewMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBviewExaminator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DBview)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(523, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DBview
            // 
            this.DBview.BackgroundColor = System.Drawing.Color.White;
            this.DBview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DBviewWorker,
            this.DBviewSport,
            this.DBviewMark,
            this.DBviewExaminator});
            this.DBview.Location = new System.Drawing.Point(1, 4);
            this.DBview.Name = "DBview";
            this.DBview.Size = new System.Drawing.Size(604, 173);
            this.DBview.TabIndex = 17;
            // 
            // DBviewWorker
            // 
            this.DBviewWorker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DBviewWorker.HeaderText = "Worker";
            this.DBviewWorker.Name = "DBviewWorker";
            this.DBviewWorker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DBviewWorker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DBviewSport
            // 
            this.DBviewSport.HeaderText = "Sport";
            this.DBviewSport.Name = "DBviewSport";
            this.DBviewSport.Width = 80;
            // 
            // DBviewMark
            // 
            this.DBviewMark.HeaderText = "Mark";
            this.DBviewMark.Name = "DBviewMark";
            this.DBviewMark.Width = 60;
            // 
            // DBviewExaminator
            // 
            this.DBviewExaminator.HeaderText = "Examinator";
            this.DBviewExaminator.Name = "DBviewExaminator";
            this.DBviewExaminator.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DBviewExaminator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DBviewExaminator.Width = 200;
            // 
            // Exam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 218);
            this.Controls.Add(this.DBview);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Exam";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exam";
            ((System.ComponentModel.ISupportInitialize)(this.DBview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DBview;
        private System.Windows.Forms.DataGridViewComboBoxColumn DBviewWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBviewSport;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBviewMark;
        private System.Windows.Forms.DataGridViewComboBoxColumn DBviewExaminator;
    }
}