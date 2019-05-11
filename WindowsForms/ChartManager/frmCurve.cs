using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using Common.DAL;

namespace WindowsForms.ChartManager
{
    public partial class frmCurve : Form
    {
        public frmCurve()
        {
            InitializeComponent();
        }
        public DataTable dt = new DataTable();
        pathValue pathValue = new pathValue();

        private void frmCurve_Load(object sender, EventArgs e)
        {
            LoadTestData();
            CreateCurve(dt);
            //CreateCurve();
        }

        private void CreateCurve(DataTable dt)
        {
            Dictionary<string, Dictionary<DateTime, decimal>> TestInfo = new Dictionary<string, Dictionary<DateTime, decimal>>();//测试项，测试时间，测试值
            foreach(DataRow dr in dt.Rows)
            {
                string testItem = dr["testItem"].ToString();
                DateTime testTime = Convert.ToDateTime(dr["testTime"]);
                decimal testValue = String.IsNullOrEmpty(dr["testValue"].ToString()) ? 0:Convert.ToDecimal(dr["testValue"]);
                Dictionary<DateTime, decimal> items=new Dictionary<DateTime, decimal>();
                if(!TestInfo.ContainsKey(testItem))
                {
                    items.Add(testTime, testValue);
                    TestInfo.Add(testItem, items);
                }                    
                else
                {
                    items = TestInfo[testItem];
                    if (!items.ContainsKey(testTime))
                    {
                        items.Add(testTime, testValue);
                    }
                }
            }

            foreach(var items in TestInfo)
            {
                Series series1 = new Series(items.Key, ViewType.Spline);
                foreach(var item in items.Value)
                {
                    series1.Points.Add(new SeriesPoint(item.Key, item.Value));
                }
                ((LineSeriesView)series1.View).LineMarkerOptions.Visible = false;
                spineChart.Series.Add(series1);
                series1.ArgumentScaleType = ScaleType.DateTime;
            }
            XYDiagram diagram = (XYDiagram)spineChart.Diagram;
            diagram.AxisX.Title.Visible = true;
            diagram.AxisX.Title.Alignment = StringAlignment.Center;
            diagram.AxisX.Title.Text = "测试时间";
            diagram.AxisX.Title.Antialiasing = true;
            diagram.AxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Second;
            diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
            diagram.AxisX.DateTimeOptions.FormatString = "HH:mm:ss";
            diagram.AxisX.Title.Font = new Font("Tahoma", 12, FontStyle.Bold);

            diagram.AxisY.Title.Visible = true;
            diagram.AxisY.Title.Alignment = StringAlignment.Center;
            diagram.AxisY.Title.Text = "测试值";
            diagram.AxisY.Title.Antialiasing = true;
            diagram.AxisY.Title.Font = new Font("Tahoma", 12, FontStyle.Bold);

            ((XYDiagram)spineChart.Diagram).EnableAxisXZooming = true;
            spineChart.Titles.Add(new ChartTitle());
            spineChart.Titles[0].Text = "2号机测试数据";
            spineChart.Titles[0].Font = new Font("Tahoma", 14, FontStyle.Bold);

        }
        private void LoadTestData()
        {
            dt= pathValue.LoadData();
        }
    }
}