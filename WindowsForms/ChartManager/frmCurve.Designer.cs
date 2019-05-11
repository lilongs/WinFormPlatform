namespace WindowsForms.ChartManager
{
    partial class frmCurve
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
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.spineChart = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.spineChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // spineChart
            // 
            this.spineChart.DataBindings = null;
            this.spineChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spineChart.Legend.Name = "Default Legend";
            this.spineChart.Location = new System.Drawing.Point(0, 0);
            this.spineChart.Name = "spineChart";
            this.spineChart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.spineChart.SeriesTemplate.View = lineSeriesView1;
            this.spineChart.Size = new System.Drawing.Size(800, 450);
            this.spineChart.TabIndex = 0;
            // 
            // frmCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.spineChart);
            this.Name = "frmCurve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCurve";
            this.Load += new System.EventHandler(this.frmCurve_Load);
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spineChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl spineChart;
    }
}