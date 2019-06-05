using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.ServiceReference2;

namespace WindowsForms.UserManager
{
    public partial class frmAddRole : Form
    {
        public frmAddRole()
        {
            InitializeComponent();
        }
        RoleManagerInterfaceClient client = new RoleManagerInterfaceClient();
        public string username = string.Empty;
        public int roleid = -1;
        public string rolename = string.Empty;
        public string remark = string.Empty;
        public int flag = 0;

        private void frmAddRole_Load(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                txtrolename.Text = rolename;
                txtremark.Text = remark;
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                string rolename = this.txtrolename.Text.Trim();
                string remark = this.txtremark.Text.Trim();
                if (String.IsNullOrEmpty(rolename))
                {
                    MessageBox.Show("请输入部门名称！");
                    return;
                }
                if (flag == 0)
                {
                    if (client.InsertRoleInfo(rolename, remark, username))
                    {
                        MessageBox.Show("添加成功！");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                }
                else
                {
                    if (client.UpdateRoleInfo(roleid, rolename, remark, username))
                    {
                        MessageBox.Show("修改成功！");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
               
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
