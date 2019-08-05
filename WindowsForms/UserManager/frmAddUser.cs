using WindowsForms.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.ServiceReference1;
using WindowsForms.ServiceReference2;
using WindowsForms.ServiceReference5;

namespace WindowsForms.UserManager
{
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }
        PermissionInterfaceClient client = new PermissionInterfaceClient();
        RoleManagerInterfaceClient client2 = new RoleManagerInterfaceClient();
        DeptInfoManagerInterfaceClient client3 = new DeptInfoManagerInterfaceClient();
        public string username = string.Empty;//创建人
        public string username2 = string.Empty;//用户名
        public string realname = string.Empty;
        public string telephone = string.Empty;
        public string rolename = string.Empty;
        public string deptname = string.Empty;
        public int flag = 0;

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            try
            {
                SetDeptInfo();
                SetRoleInfo();
                if (flag == 1)
                {
                    this.txtusername.Text = username2;
                    this.txtrealname.Text = realname;
                    this.txttelephone.Text = telephone;
                    comboxdept.Text = deptname;
                    checkedComboBoxEdit1.EditValue = rolename;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("数据加载失败:" + ex.Message);
            }
        }

        private void SetDeptInfo()
        {
            DataTable dt = client3.GetAllDeptInfo(string.Empty);
            comboxdept.DataSource = dt;
            comboxdept.DisplayMember = "deptname";
            comboxdept.ValueMember = "deptno";
        }

        private void SetRoleInfo()
        {
            DataTable dt = client2.GetAllRoleInfo(string.Empty);
            checkedComboBoxEdit1.Properties.DataSource = dt;
            checkedComboBoxEdit1.Properties.DisplayMember = "rolename";
            checkedComboBoxEdit1.Properties.ValueMember = "roleid";
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInput())
                    return;
                List<int> roleid_list = new List<int>();
                for (int i = 0; i < checkedComboBoxEdit1.Properties.Items.Count; i++)
                {
                    if (checkedComboBoxEdit1.Properties.Items[i].CheckState == CheckState.Checked)
                    {
                        roleid_list.Add(Convert.ToInt32(checkedComboBoxEdit1.Properties.Items[i].Value));
                    }
                }
                if (flag == 0)
                {
                    if (client.CheckUsername(txtusername.Text.Trim()))
                    {
                        MessageBox.Show("用户名重复");
                        return;
                    }
                    if (client.Register(txtusername.Text.Trim(), MD5.MD5Encrypt("666666"), txtrealname.Text.Trim(), txttelephone.Text.Trim(), Convert.ToInt32(String.IsNullOrEmpty(comboxdept.SelectedValue.ToString()) ? -1 : comboxdept.SelectedValue), roleid_list, username))
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
                    if (client.UpdateUser(txtusername.Text.Trim(), txtrealname.Text.Trim(), txttelephone.Text.Trim(), Convert.ToInt32(comboxdept.SelectedValue), roleid_list, username))
                    {
                        MessageBox.Show("修改成功！");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("操作失败:"+ex.Message);
            }
        }

        private bool CheckInput()
        {
            if (String.IsNullOrEmpty(txtusername.Text.Trim()) || String.IsNullOrEmpty(txtrealname.Text.Trim()) || String.IsNullOrEmpty(txttelephone.Text.Trim()) || String.IsNullOrEmpty(checkedComboBoxEdit1.Text.Trim()) || String.IsNullOrEmpty(comboxdept.Text.Trim()))
            {
                MessageBox.Show("请填写带*的必填项！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
