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
using WcfService.Services;

namespace WindowsForms.UserManager
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        BaseCommon bc = new BaseCommon();
        string username = string.Empty;

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            username = this.Tag.ToString().Split(',')[0];
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if(!CheckOldPassword())
            {
                this.labelControl5.Visible = true;
                return;
            }
            if(String.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                this.labelControl6.Visible = true;
                return;
            }
            if((txtNewPassword.Text.Trim()!= txtNewPassword2.Text.Trim()))
            {
                this.labelControl3.Visible = true;
                return;
            }
            MessageBox.Show(UpdatePassword() ? "修改成功" : "修改失败");
        }

        private bool CheckOldPassword()
        {
            string password = MD5.MD5Encrypt(this.txtOldPassword.Text.Trim());
            IService client = bc.GetWcfService();
            return client.Login(username,password);
        }

        private bool UpdatePassword()
        {
            string password = MD5.MD5Encrypt(this.txtNewPassword2.Text.Trim());
            IService client = bc.GetWcfService();
            return client.UpdatePassword(username, password);
        }
    }
}
