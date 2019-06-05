using WindowsForms.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.ServiceReference1;
using WindowsForms.ServiceReference3;

namespace WindowsForms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        PermissionInterfaceClient client = new PermissionInterfaceClient();
        MenuManagerInterfaceClient client2 = new MenuManagerInterfaceClient();
        DataTable dtUserMenu = new DataTable();
        DataTable dtAllGroup = new DataTable();
        
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = MD5.MD5Encrypt(txtPassword.Text.Trim());
            if (!CheckInput())
                return;
            //开启一个进程用于获取用于权限菜单信息和新增登陆记录
            Thread thread1 = new Thread(new ThreadStart(LoadMenuInfo));
            thread1.IsBackground = true;
           
            bool result = client.Login(username, password);

            if (result)
            {
                thread1.Start();
                MessageBox.Show("登陆成功!");
                frmMain main = new frmMain();
                this.Invoke(new MethodInvoker(delegate ()
                {
                    main.userMenu = dtUserMenu;
                    main.allGroup = dtAllGroup;
                }));
                main.Show();
                this.Hide();
                
            }
            else
                MessageBox.Show("登陆失败!");
        }

        private void LoadMenuInfo()
        {
            dtUserMenu = client.GetUserMenuInfo(txtUsername.Text.Trim());
            dtAllGroup = client2.GetAllGroupInfo();

            
        }

        private bool CheckInput()
        {
            if (String.IsNullOrEmpty(txtUsername.Text.Trim()) || String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("用户名和密码不能为空");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            this.BtnLogin_Click(sender,e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
