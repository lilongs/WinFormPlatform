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
    public partial class frmAddDept : Form
    {
        public frmAddDept()
        {
            InitializeComponent();
        }
        BaseCommon bc = new BaseCommon();
        public string username = string.Empty;
        public int deptno = -1;
        public string deptname = string.Empty;
        public string remark = string.Empty;
        public int flag = 0;

        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                IService client = bc.GetWcfService();
                string deptname = this.txtdeptname.Text.Trim();
                string remark = this.txtremark.Text.Trim();
                if (String.IsNullOrEmpty(deptname))
                {
                    MessageBox.Show("请输入部门名称！");
                    return;
                }
                if (flag == 0)
                {
                    if(client.InsertDeptInfo(deptname,remark,username))
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
                    if (client.UpdateDeptInfo(deptno,deptname, remark, username))
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddDept_Load(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                txtdeptname.Text = deptname;
                txtremark.Text = remark;
            }
        }
    }
}
