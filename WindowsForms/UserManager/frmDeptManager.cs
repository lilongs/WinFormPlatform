using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfService.Services;
using WindowsForms.Util;

namespace WindowsForms.UserManager
{
    public partial class frmDeptManager : Form
    {
        public frmDeptManager()
        {
            InitializeComponent();
        }
        BaseCommon bc = new BaseCommon();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDeptInfo(txtdeptname.Text.Trim());
        }

        private void LoadDeptInfo(string deptname)
        {
            IService client = bc.GetWcfService();
            DataTable dtData = client.GetAllDeptInfo(deptname);
            this.gdcInfo.DataSource = dtData;
        }

        private void frmDeptManager_Load(object sender, EventArgs e)
        {
            LoadDeptInfo(string.Empty);
        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            frmAddDept frm = new frmAddDept();
            frm.username = this.Tag.ToString().Split(',')[0];
            frm.flag = 0;//新增
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                LoadDeptInfo(string.Empty);
            }
        }

        private void btnUpdateDept_Click(object sender, EventArgs e)
        {
            if (gdvInfo.GetSelectedRows().Count() <= 0)
            {
                MessageBox.Show("请点击选择要修改的行！");
                return;
            }
            frmAddDept frm = new frmAddDept();
            frm.username = this.Tag.ToString().Split(',')[0];
            frm.flag = 1;//更新
            frm.deptno = Convert.ToInt32(gdvInfo.GetFocusedRowCellValue("deptno"));
            frm.deptname = gdvInfo.GetFocusedRowCellValue("deptname").ToString();
            frm.remark = gdvInfo.GetFocusedRowCellValue("remark").ToString();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadDeptInfo(string.Empty);
            }
        }
    }
}
