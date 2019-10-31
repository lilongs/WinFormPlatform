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
using WindowsForms.UserManager;

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
        public Dictionary<int, Dictionary<string, MenuInfo>> Menus = new Dictionary<int, Dictionary<string, MenuInfo>>();//组名，菜单名，窗体路径信息和菜单图片路径
        public Dictionary<int, string> Groups = new Dictionary<int, string>();//组名


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
                //frmMain main = new frmMain();
                frmMidTabMain main = new frmMidTabMain();
                this.Invoke(new MethodInvoker(delegate ()
                {
                    main.Menus = Menus;
                    main.Groups = Groups;
                    main.userMenu = dtUserMenu;
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

           InitMenuGroups();
        }
        private void InitMenuGroups()
        {
            //加载固定的系统操作菜单            
            Dictionary<string, MenuInfo> temp = new Dictionary<string, MenuInfo>();

            Groups.Add(-1, "系统设置");
            MenuInfo menuInfo;
            temp.Add("修改密码", menuInfo = new MenuInfo("", "office2013/history/undo_32x32.png"));
            temp.Add("切换用户", menuInfo = new MenuInfo("", "office2013/scheduling/recurrence_32x32.png"));
            temp.Add("退出系统", menuInfo = new MenuInfo("", "office2013/reports/none_32x32.png"));
            Menus.Add(-1, temp);
            //装载组别信息
            foreach (DataRow dr in dtAllGroup.Rows)
            {
                int parentid = String.IsNullOrEmpty(dr["parentid"].ToString()) ? 0 : Convert.ToInt32(dr["parentid"]);
                int GroupId = String.IsNullOrEmpty(dr["menuid"].ToString()) ? 0 : Convert.ToInt32(dr["menuid"]);
                string MenuName = dr["menuname"].ToString();
                if (parentid == 0)
                {
                    if (!Groups.ContainsKey(GroupId))
                    {
                        Groups.Add(GroupId, MenuName);
                    }
                }
            }
            //装载子级菜单
            foreach (DataRow dr in dtUserMenu.Rows)
            {
                Dictionary<string, MenuInfo> menuItem = new Dictionary<string, MenuInfo>();
                MenuInfo menuInfos;
                int parentid = String.IsNullOrEmpty(dr["parentid"].ToString()) ? 0 : Convert.ToInt32(dr["parentid"]);
                int GroupId = String.IsNullOrEmpty(dr["menuid"].ToString()) ? 0 : Convert.ToInt32(dr["menuid"]);
                string MenuName = dr["menuname"].ToString();
                string path = dr["path"].ToString();
                string image_path = dr["image_path"].ToString();

                if (parentid != 0)
                {
                    if (!Menus.ContainsKey(parentid))
                    {
                        menuItem.Add(MenuName, menuInfos = new MenuInfo(path, image_path));
                        Menus.Add(parentid, menuItem);
                    }
                    else
                    {
                        menuItem = Menus[parentid];
                        if (!menuItem.ContainsKey(MenuName))
                        {
                            menuItem.Add(MenuName, menuInfos = new MenuInfo(path, image_path));
                        }
                    }
                }
            }
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
