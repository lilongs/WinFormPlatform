using Common.Util;
using DevExpress.XtraBars;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.UserManager;

namespace WindowsForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public DataTable allGroup = new DataTable();
        public DataTable userMenu = new DataTable();//用户菜单信息
        Dictionary<int, string> Groups = new Dictionary<int, string>();//菜单组别信息
        Dictionary<int, Dictionary<string, string>> Menus = new Dictionary<int, Dictionary<string, string>>();//组别，菜单名，窗体路径信息


        private void frmMain_Load(object sender, EventArgs e)
        {
            InitSystem();
        }

        private void InitSystem()
        {
            SetUserInfo();
            getMenuGroups();
            InitMenu();
        }

        private void SetUserInfo()
        {
            barStaticItem2.Caption = userMenu.Rows[0]["username"].ToString();
            barStaticItem4.Caption = userMenu.Rows[0]["rolename"].ToString();
        }

        private void getMenuGroups()
        {
            //加载固定的系统操作菜单
            Dictionary<string, string> temp = new Dictionary<string, string>();
            Groups.Add(-1, "系统设置");
            temp.Add("修改密码", "");
            temp.Add("切换用户", "");
            temp.Add("退出系统", "");
            Menus.Add(-1, temp);
            //装载组别信息
            foreach (DataRow dr in allGroup.Rows)
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
            foreach (DataRow dr in userMenu.Rows)
            {
                Dictionary<string, string> menuItem = new Dictionary<string, string>();
                int parentid = String.IsNullOrEmpty(dr["parentid"].ToString()) ? 0 : Convert.ToInt32(dr["parentid"]);
                int GroupId = String.IsNullOrEmpty(dr["menuid"].ToString()) ? 0 : Convert.ToInt32(dr["menuid"]);
                string MenuName = dr["menuname"].ToString();
                string path = dr["path"].ToString();
                
                if(parentid!=0)
                {
                    if (!Menus.ContainsKey(parentid))
                    {
                        menuItem.Add(MenuName, path);
                        Menus.Add(parentid, menuItem);
                    }
                    else
                    {
                        menuItem = Menus[parentid];
                        if (!menuItem.ContainsKey(MenuName))
                        {
                            menuItem.Add(MenuName, path);
                        }
                    }
                }
            }
        }

        private void InitMenu()
        {
            foreach(var item in Menus)
            {
                BarSubItem GroupItem = new BarSubItem();
                GroupItem.Name = Groups[item.Key];
                GroupItem.Caption = Groups[item.Key];
                bar1.AddItem(GroupItem);
                foreach (var menu in item.Value)
                { 
                    BarButtonItem menuItem = new BarButtonItem();
                    menuItem.Name = menu.Key;
                    menuItem.Caption = menu.Key;
                    menuItem.Tag = menu.Value;
                    GroupItem.AddItem(menuItem);
                    menuItem.ItemClick += MenuItem_ItemClick;
                }
            }
        }

        private void MenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string path = e.Item.Tag.ToString();
                string formname = e.Item.Caption.ToString();
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
                            break;
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

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTabPage.Text!="首页")
            tabControl1.TabPages.Remove(this.tabControl1.SelectedTabPage);
        }
    }
}
