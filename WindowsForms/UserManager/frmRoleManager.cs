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
    public partial class frmRoleManager : Form
    {
        public frmRoleManager()
        {
            InitializeComponent();
        }
        BaseCommon bc = new BaseCommon();
        private void frmRoleManager_Load(object sender, EventArgs e)
        {
            LoadRoleInfo(string.Empty);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRoleInfo(txtrolename.Text.Trim());
        }

        private void LoadRoleInfo(string rolename)
        {
            IService client = bc.GetWcfService();
            DataTable dtData = client.GetAllRoleInfo(rolename);
            this.gdcInfo.DataSource = dtData;
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            frmAddRole frm = new frmAddRole
            {
                username = this.Tag.ToString().Split(',')[0],
                flag = 0//新增
            };
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadRoleInfo(string.Empty);
            }
        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            if (gdvInfo.GetSelectedRows().Count() <= 0)
            {
                MessageBox.Show("请点击选择要修改的行！");
                return;
            }
            frmAddRole frm = new frmAddRole
            {
                username = this.Tag.ToString().Split(',')[0],
                flag = 1,//更新
                roleid = Convert.ToInt32(gdvInfo.GetFocusedRowCellValue("roleid")),
                rolename = gdvInfo.GetFocusedRowCellValue("rolename").ToString(),
                remark = gdvInfo.GetFocusedRowCellValue("remark").ToString()
            };
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadRoleInfo(string.Empty);
            }
        }
        
    }
}
