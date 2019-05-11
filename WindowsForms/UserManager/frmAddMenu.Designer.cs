namespace WindowsForms.UserManager
{
    partial class frmAddMenu
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtmenuname = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtpath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comboxparentno = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtsort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtmenuname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsort.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(55, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "菜单名称：";
            // 
            // txtmenuname
            // 
            this.txtmenuname.Location = new System.Drawing.Point(121, 51);
            this.txtmenuname.Name = "txtmenuname";
            this.txtmenuname.Size = new System.Drawing.Size(249, 20);
            this.txtmenuname.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(121, 221);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(80, 36);
            this.btnSure.TabIndex = 7;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(55, 89);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "窗体路径：";
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(121, 86);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(249, 20);
            this.txtpath.TabIndex = 12;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(55, 122);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "根菜单：";
            // 
            // comboxparentno
            // 
            this.comboxparentno.FormattingEnabled = true;
            this.comboxparentno.Location = new System.Drawing.Point(121, 121);
            this.comboxparentno.Name = "comboxparentno";
            this.comboxparentno.Size = new System.Drawing.Size(249, 20);
            this.comboxparentno.TabIndex = 15;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(55, 160);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "窗体排序：";
            // 
            // txtsort
            // 
            this.txtsort.Location = new System.Drawing.Point(121, 157);
            this.txtsort.Name = "txtsort";
            this.txtsort.Size = new System.Drawing.Size(249, 20);
            this.txtsort.TabIndex = 16;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(21, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(192, 14);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "添加根节点菜单，根菜单留空即可！";
            // 
            // frmAddMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 285);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtsort);
            this.Controls.Add(this.comboxparentno);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtmenuname);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Name = "frmAddMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "菜单维护";
            this.Load += new System.EventHandler(this.frmAddMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtmenuname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsort.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtmenuname;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtpath;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox comboxparentno;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtsort;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}