using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Update
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }
        public FileInfo[] fileInfos;
        int count = 0;
        int dealCount = 0;

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            GetReadyUpdateList();
        }

        private void GetReadyUpdateList()
        {
            //文件更新服务器地址
            //string UpdateServer = "E:\\Update";
            DirectoryInfo UpdateServer = new DirectoryInfo("E:\\Update");
            if (!UpdateServer.Exists)
            {
                return;
            }
            else
            {
                fileInfos = UpdateServer.GetFiles();
                count = fileInfos.Count();
                this.labelControl3.Text = dealCount.ToString();
                this.labelControl5.Text = count.ToString();
                this.progressBarControl1.Properties.Maximum = count;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DealWithUpdateList();
        }

        private void DealWithUpdateList()
        {
            try
            {
                string path = Application.StartupPath;
                foreach (FileInfo file in fileInfos)
                {
                    if (File.Exists(path + "\\" + file.Name))
                    {
                        File.Delete(path + "\\" + file.Name);
                    }
                    file.CopyTo(path + "\\" + file.Name);
                    dealCount++;
                    this.labelControl3.Text = dealCount.ToString();
                    Application.DoEvents();
                    progressBarControl1.Position += 1;
                }

                if (dealCount == count)
                {
                    DialogResult dr = MessageBox.Show("更新成功，是否启动主程序！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        Process pr = new Process();
                        pr.StartInfo.FileName = "WindowsForms.exe";
                        pr.Start();
                        Application.Exit();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
