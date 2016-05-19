using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Training.Forms
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }


        public bool CreateGraphics(DataRow[] rows)
        {
            this.chart1.ChartAreas.Clear();
            this.chart1.Series.Clear();
            this.chart1.Titles.Clear();
            this.chart1.Legends.Clear();

            if (rows == null || rows.Length == 0)
                return true;

            foreach (var row in rows)
            {
                var strSelect = string.Concat("select e.id_co_worker, e.id_sports_qualification_type, e.date, e.mark, e.id_examinator, s.name as sport, true as old",
                            " from co_worker_exam e left outer join sports_qualification_type s on e.id_sports_qualification_type=s.id",
                            " where id_co_worker=", row["id"]);
                var tab = Program.GetData(strSelect);

                var groupT = from t in tab.AsEnumerable()
                              group t by new { Id = t.Field<int>("id_sports_qualification_type") } into g
                             select new { g.Key.Id };

                if (groupT == null || groupT.Count() == 0)
                    continue;

                // Add elements
                this.chart1.ChartAreas.Add(row["id"].ToString());
                this.chart1.Legends.Add(row["id"].ToString());
                this.chart1.Titles.Add(row["id"].ToString());

                // Set variables
                var chartAr = this.chart1.ChartAreas[this.chart1.ChartAreas.Count - 1];
                var leg = this.chart1.Legends[this.chart1.Legends.Count - 1];
                var titl = this.chart1.Titles[this.chart1.Titles.Count - 1];

                // Set relationship
                titl.DockedToChartArea = row["id"].ToString();
                leg.DockedToChartArea = row["id"].ToString();

                /*chartAr.AxisX.LabelStyle.Interval = 10;
                chartAr.AxisY.LabelStyle.Interval = 1;
                chartAr.AxisY.Minimum = 0;
                chartAr.AxisY.Maximum = 10;*/
                chartAr.AxisY.LabelStyle.Interval = 1;
                chartAr.AxisY.MajorGrid.LineColor = chartAr.AxisX.MajorGrid.LineColor = Color.Gainsboro;

                titl.Docking = Docking.Left;
                titl.IsDockedInsideChartArea = false;
                titl.Text = string.Concat(row["second_name"], " ", row["first_name"], " [", row["name"], "]");

                leg.IsDockedInsideChartArea = false;
                leg.Title = "Sports";

                foreach (var gr in groupT)
                {
                    var rowsS = tab.Select(string.Concat("id_sports_qualification_type=", gr.Id));
                    if (rowsS == null || rowsS.Length == 0)
                        continue;

                    this.chart1.Series.Add(string.Concat(row["id"].ToString(), " ", gr.Id));
                    var ser = this.chart1.Series[this.chart1.Series.Count - 1];

                    ser.ChartArea = row["id"].ToString();
                    ser.Legend = row["id"].ToString();
                    ser.ChartType = SeriesChartType.Spline;
                    ser.LegendText = rowsS[0]["sport"].ToString();

                    //ser.IsXValueIndexed = true;
                    ser.IsValueShownAsLabel = true;
                    ser.LabelAngle = 90;
                    ser["BarLabelStyle"] = "Center";
                    ser["DrawingStyle"] = "Cylinder";
                    ser["ShowMarkerLines"] = "true";
                    ser["PointWidth"] = "0.9";

                    foreach (var rowS in rowsS)
                    {
                        var point= new DataPoint();
                        point.YValues = new double[] { double.Parse(rowS["mark"].ToString()) };
                        point.Label = rowS["mark"].ToString();
                        point.AxisLabel = rowS["date"].ToString();
                        ser.Points.Add(point);
                    }
                }

                //
            }

            return true;
        }
    }
}
