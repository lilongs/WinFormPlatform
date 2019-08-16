using WindowsForms.Util;
using DevExpress.XtraBars;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.UserManager;
using WindowsForms.ServiceReference1;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars.Docking;
using WindowsForms.Properties;

namespace WindowsForms
{
   

    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        PermissionInterfaceClient client = new PermissionInterfaceClient();
        public DataTable allGroup = new DataTable();
        public DataTable userMenu = new DataTable();//用户菜单信息

        public Dictionary<int, string> Groups = new Dictionary<int, string>();//菜单组别信息
        public Dictionary<int, Dictionary<string, MenuInfo>> Menus = new Dictionary<int, Dictionary<string, MenuInfo>>();//组名，菜单名，窗体路径信息和菜单图片路径

        public string ip = string.Empty;
        public string computername = string.Empty;

        
        private void frmMain_Load(object sender, EventArgs e)
        {
            InitSystem();
        }

        private void InitSystem()
        {
            getClientInfo();
            SetUserInfo();
            InitMenu();
        }

        private void getClientInfo()
        {
            string HostName = Dns.GetHostName();
            IPAddress[] iPAddresses = Dns.GetHostAddresses(HostName);
            ip = iPAddresses.First(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
            computername = Environment.MachineName;
        }

        private void SetUserInfo()
        {
            DataView dv = new DataView(userMenu);
            DataTable dt = new DataTable();
            dt = dv.ToTable(true, "rolename");
            string[] arr = dt.AsEnumerable().Select(d => d.Field<string>("rolename")).ToArray();
            barStaticItem2.Caption = userMenu.Rows[0]["username"].ToString();
            barStaticItem4.Caption = String.Join(",",arr);
        }

        private void InitMenu()
        {
            foreach(var item in Menus)
            {
                BarSubItem GroupItem = new BarSubItem();
                GroupItem.Name = Groups[item.Key];
                GroupItem.Caption = Groups[item.Key];
                bar1.AddItem(GroupItem);

                NavBarGroup navBarGroup = new NavBarGroup();
                navBarGroup.Name = Groups[item.Key];
                navBarGroup.Caption = Groups[item.Key];
                this.navBarControl1.Groups.Add(navBarGroup);
                foreach (var menu in item.Value)
                { 
                    BarButtonItem menuItem = new BarButtonItem();
                    menuItem.Name = menu.Key;
                    menuItem.Caption = menu.Key;
                    menuItem.Tag = menu.Value.path;
                    menuItem.ImageOptions.Image = (Image)Resources.ResourceManager.GetObject(menu.Value.image_path);
                    GroupItem.AddItem(menuItem);
                    menuItem.ItemClick += MenuItem_ItemClick;

                    NavBarItem navBarItem = new NavBarItem();
                    navBarItem.Name = menu.Key;
                    navBarItem.Caption = menu.Key;
                    navBarItem.Tag = menu.Value.path;
                    navBarItem.SmallImage=(Image)Resources.ResourceManager.GetObject(menu.Value.image_path);
                    navBarGroup.ItemLinks.Add(navBarItem);
                    navBarItem.LinkClicked += BarItem_ItemClick;
                }                
            }
        }
        
        private void BarItem_ItemClick(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                string path = e.Link.Item.Tag.ToString();
                string formname = e.Link.Item.Caption.ToString();

                Thread thread1 = new Thread(new ThreadStart(
                            delegate
                            {
                                InsertOperateLog(formname);
                            }
                            ));
                thread1.IsBackground = true;
                thread1.Start();

                Form form = null;
                if (!String.IsNullOrEmpty(formname))
                {
                    switch (formname)
                    {
                        case "修改密码":
                            form = new frmChangePassword();
                            break;
                        case "切换用户":
                            frmLogin frm = new frmLogin();
                            this.Hide();
                            frm.Show();
                            return;
                        case "退出系统":
                            Application.Exit();
                            return;
                        default:
                            form = ReflectionHelper.CreateInstance<Form>(path, "WindowsForms");
                            break;
                    }
                    Add_TabPage(form, e.Link.Item.Caption.ToString(), userMenu.Rows[0]["username"].ToString() + "," + userMenu.Rows[0]["rolename"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string path = e.Item.Tag.ToString();
                string formname = e.Item.Caption.ToString();

                Thread thread1 = new Thread(new ThreadStart(
                            delegate 
                            {
                                InsertOperateLog(formname);
                            }
                            ));
                thread1.IsBackground = true;
                thread1.Start();

                Form form = null;
                if (!String.IsNullOrEmpty(formname))
                {
                    switch(formname)
                    {
                        case "修改密码":
                            form = new frmChangePassword();
                            break;
                        case "切换用户":
                            frmLogin frm = new frmLogin();
                            this.Hide();
                            frm.Show();
                            return;
                        case "退出系统":
                            Application.Exit();
                            return;
                        default:
                            form=ReflectionHelper.CreateInstance<Form>(path, "WindowsForms");
                            break;
                    }
                    Add_TabPage(form, e.Item.Caption.ToString(), userMenu.Rows[0]["username"].ToString() + "," + userMenu.Rows[0]["rolename"].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertOperateLog(string formname)
        {
            client.Operatelog(userMenu.Rows[0]["username"].ToString(), ip, computername, formname);
        }

        private void Add_TabPage(Form form, String title,string tag)
        {
            bool found = false;
            XtraTabPage selectedPage = null;
            foreach (XtraTabPage page in tabControl1.TabPages)
            {
                if (page.Tag != null && page.Text == title)
                {
                    found = true;
                    selectedPage = page;
                    break;
                }
            }
            if (!found)
            {
                selectedPage = new XtraTabPage();
                selectedPage.Text = title;
                selectedPage.Tag = form;
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Tag = tag;
                form.Show();
                selectedPage.Controls.Clear();
                selectedPage.Controls.Add(form);

                if (!form.IsDisposed)
                {
                    tabControl1.SelectedTabPage = selectedPage;
                    tabControl1.TabPages.Add(selectedPage);  
                }
            }
            else
            {
                if (selectedPage.Tag != null && selectedPage.Tag != form)
                {
                    form.TopLevel = false;
                    form.Dock = DockStyle.Fill;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Show();
                    selectedPage.Controls.Clear();
                    selectedPage.Controls.Add(form);
                }
            }
            selectedPage.BringToFront();
            tabControl1.SelectedTabPage = selectedPage;
        }

        private void tabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTabPage.Text!="首页")
            tabControl1.TabPages.Remove(this.tabControl1.SelectedTabPage);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定退出系统？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            NavBarControl navBar = sender as NavBarControl;
            navBar.OptionsNavPane.NavPaneState = NavPaneState.Collapsed;
        }
    }
}
