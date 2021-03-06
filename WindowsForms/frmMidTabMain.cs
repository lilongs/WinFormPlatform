﻿using WindowsForms.Util;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using WindowsForms.UserManager;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars.Ribbon;
using WcfService.Services;
using System.Diagnostics;

namespace WindowsForms
{
    public partial class frmMidTabMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        BaseCommon bc = new BaseCommon();
        public DataTable allGroup = new DataTable();
        public DataTable userMenu = new DataTable();//用户菜单信息

        public Dictionary<int, string> Groups = new Dictionary<int, string>();//菜单组别信息
        public Dictionary<int, Dictionary<string, MenuInfo>> Menus = new Dictionary<int, Dictionary<string, MenuInfo>>();//组名，菜单名，窗体路径信息和菜单图片路径

        public string ip = string.Empty;
        public string computername = string.Empty;

        public frmMidTabMain()
        {
            InitializeComponent();
        }
        
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
            barStaticItem1.Caption = userMenu.Rows[0]["username"].ToString();
            barStaticItem2.Caption = String.Join(",",arr);
        }

        private void InitMenu()
        {
            foreach(var item in Menus)
            {
                RibbonPage ribbonPage = new RibbonPage();
                ribbonPage.Name = Groups[item.Key];
                ribbonPage.Text = Groups[item.Key];
                ribbonControl1.Pages.Add(ribbonPage);

                RibbonPageGroup ribbonPageGroup = new RibbonPageGroup();
                ribbonPageGroup.Text = Groups[item.Key];
                ribbonPage.Groups.Add(ribbonPageGroup);

                foreach (var menu in item.Value)
                {
                    BarButtonItem menuItem = new BarButtonItem();
                    menuItem.Name = menu.Key;
                    menuItem.Caption = menu.Key;
                    menuItem.Tag = menu.Value.path;
                    if(!String.IsNullOrEmpty(menu.Value.image_path))
                    {
                        menuItem.LargeGlyph = DevExpress.Images.ImageResourceCache.Default.GetImage(menu.Value.image_path);
                        menuItem.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage(menu.Value.image_path.Replace("32", "16"));
                    }
                    ribbonPageGroup.ItemLinks.Add(menuItem);
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
                            Application.Exit();
                            StartProcess(Application.StartupPath+ "\\WindowsForms.exe", "");
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

        public bool StartProcess(string runFilePath, params string[] args)
        {
            try
            {
                string s = "";
                foreach (string arg in args)
                {
                    s = s + arg + " ";
                }
                s = s.Trim();
                Process process = new Process();//创建进程对象    
                ProcessStartInfo startInfo = new ProcessStartInfo(runFilePath, s); // 括号里是(程序名,参数)
                process.StartInfo = startInfo;
                process.Start();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void InsertOperateLog(string formname)
        {
            IService client = bc.GetWcfService();
            client.Operatelog(userMenu.Rows[0]["username"].ToString(), ip, computername, formname);
        }

        private void Add_TabPage(Form form, string title,string tag)
        {
            if (ShowOpendPage(title))
            {
                return;
            }
            form.Text = title;
            form.Tag = tag;
            form.MdiParent = this;
            form.Show();
            xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[form];
        }

        private bool ShowOpendPage(string frmName)
        {
            foreach(DevExpress.XtraTabbedMdi.XtraMdiTabPage page in xtraTabbedMdiManager1.Pages)
            {
                if (page.Text.Trim()== frmName)
                {
                    xtraTabbedMdiManager1.SelectedPage = page;
                    return true;
                }
            }
            return false;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
