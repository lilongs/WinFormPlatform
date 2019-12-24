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
    public partial class frmUserManager : Form
    {
        public frmUserManager()
        {
            InitializeComponent();
        }
        BaseCommon bc = new BaseCommon();

        private void frmUserManager_Load(object sender, EventArgs e)
        {
            LoadUserInfo(string.Empty);
        }

        private void LoadUserInfo(string username)
        {
            IService client = bc.GetWcfService();
            DataTable dtData = client.GetUserInfo(username);
            this.gdcInfo.DataSource = dtData;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUser frmAddUser = new frmAddUser();
            frmAddUser.username = this.Tag.ToString().Split(',')[0];
            frmAddUser.flag = 0;
            frmAddUser.ShowDialog();
            if (frmAddUser.DialogResult == DialogResult.OK)
            {
                LoadUserInfo(string.Empty);
            }
        }

        private void btnStopUser_Click(object sender, EventArgs e)
        {
            List<string> listusername = new List<string>();
            int[] rowIndex = this.gdvInfo.GetSelectedRows();

            if (rowIndex.Length <= 0)
            {
                MessageBox.Show("请选择要禁用的用户！");
                return;
            }
            else
            {
                foreach (int num in rowIndex)
                {
                    listusername.Add(gdvInfo.GetDataRow(num)["username"].ToString());
                }
                IService client = bc.GetWcfService();
                MessageBox.Show(client.StopUser(listusername)?"禁用成功":"禁用失败");
            }
        }

        private void gdvInfo_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "status")
            {
                switch(Convert.ToInt32(e.Value))
                {
                    case 0:
                        e.DisplayText = "离职";
                        break;
                    case 1:
                        e.DisplayText = "在职";
                        break;
                    default:
                        e.DisplayText = "";
                        break;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUserInfo(txtusername.Text.Trim());
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (gdvInfo.GetSelectedRows().Count() <= 0)
            {
                MessageBox.Show("请选择要修改的用户信息");
                return;
            }
            frmAddUser frmAddUser = new frmAddUser();
            frmAddUser.username = this.Tag.ToString().Split(',')[0];
            frmAddUser.username2 = gdvInfo.GetFocusedRowCellValue("username").ToString();
            frmAddUser.realname = gdvInfo.GetFocusedRowCellValue("realname").ToString();
            frmAddUser.telephone = gdvInfo.GetFocusedRowCellValue("telephone").ToString();
            frmAddUser.rolename = gdvInfo.GetFocusedRowCellValue("rolename").ToString();
            frmAddUser.deptname = gdvInfo.GetFocusedRowCellValue("deptname").ToString();
            frmAddUser.flag = 1;
            frmAddUser.ShowDialog();
            if (frmAddUser.DialogResult == DialogResult.OK)
            {
                LoadUserInfo(string.Empty);
            }
        }
    }
}
