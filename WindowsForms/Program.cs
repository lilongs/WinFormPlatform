using Common.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CheckVersion();
            //Application.Run(new frmLogin());
        }

        //版本更新
        static void CheckVersion()
        {
            string Localversion = Application.ProductVersion.ToString();
            string ServerVersion = ClientVersion.ServerVersion();
            if (Localversion != ServerVersion)
            {
                DialogResult dr = MessageBox.Show("当前程序有最新版可更新，是否立即更新？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    Process pr = new Process();
                    pr.StartInfo.FileName = "Update.exe";
                    pr.Start();
                    Application.Exit();
                }
                else
                {
                    Application.Run(new frmLogin());
                }
            }
            else
            {
                Application.Run(new frmLogin());
            }
        }
    }
}
