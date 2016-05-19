namespace Training.Forms
{
    partial class Report
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 9D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 9.2D);
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Area3DStyle.WallWidth = 1;
            chartArea3.AxisX.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX2.LineColor = System.Drawing.Color.LightGray;
            chartArea3.AxisY.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY2.LineColor = System.Drawing.Color.LightGray;
            chartArea3.Name = "ChartArea1";
            chartArea4.Name = "ChartArea2";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.DockedToChartArea = "ChartArea1";
            legend4.IsDockedInsideChartArea = false;
            legend4.Name = "Legend1";
            legend5.DockedToChartArea = "ChartArea2";
            legend5.IsDockedInsideChartArea = false;
            legend5.Name = "Legend2";
            legend6.Name = "Legend3";
            this.chart1.Legends.Add(legend4);
            this.chart1.Legends.Add(legend5);
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.LegendText = "Running";
            series3.Name = "Series1";
            dataPoint3.AxisLabel = "2016 05 16";
            dataPoint3.BorderWidth = 1;
            dataPoint3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataPoint3.IsValueShownAsLabel = false;
            dataPoint3.Label = "9";
            dataPoint3.LegendText = "";
            dataPoint4.AxisLabel = "2016 05 15";
            dataPoint4.Label = "9.2";
            series3.Points.Add(dataPoint3);
            series3.Points.Add(dataPoint4);
            series4.ChartArea = "ChartArea2";
            series4.Legend = "Legend2";
            series4.Name = "Series3";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(695, 302);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title3.DockedToChartArea = "ChartArea1";
            title3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title3.IsDockedInsideChartArea = false;
            title3.Name = "Title1";
            title3.Text = "123";
            title4.DockedToChartArea = "ChartArea2";
            title4.Name = "Title2";
            title4.Text = "234";
            this.chart1.Titles.Add(title3);
            this.chart1.Titles.Add(title4);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 302);
            this.Controls.Add(this.chart1);
            this.Name = "Report";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}