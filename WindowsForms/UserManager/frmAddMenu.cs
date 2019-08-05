using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.ServiceReference3;

namespace WindowsForms.UserManager
{
    public partial class frmAddMenu : Form
    {
        public frmAddMenu()
        {
            InitializeComponent();
        }
        MenuManagerInterfaceClient client = new MenuManagerInterfaceClient();
        public string username = string.Empty;
        public int menuid = -1;
        public string menuname = string.Empty;
        public string path = string.Empty;
        public string sort;
        public int parentid = -1;
        public int flag = 0;

        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                #region 校验录入
                if (String.IsNullOrEmpty(txtmenuname.Text.Trim()))
                {
                    MessageBox.Show("请输入菜单名称！");
                    return;
                }
                if (String.IsNullOrEmpty(txtmenuname.Text.Trim()))
                {
                    MessageBox.Show("请输入窗体路径！");
                    return;
                }
                if (String.IsNullOrEmpty(txtmenuname.Text.Trim()))
                {
                    MessageBox.Show("请选择根菜单！");
                    return;
                }
                #endregion
                string menuname = txtmenuname.Text.Trim();
                string path = txtpath.Text.Trim();
                int parentid = String.IsNullOrEmpty(comboxparentno.Text.ToString()) ? 0 : Convert.ToInt32(comboxparentno.SelectedValue);//不填写默认是根节点
                int sort = String.IsNullOrEmpty(txtsort.Text.Trim()) ? 0 : Convert.ToInt32(txtsort.Text.Trim());
                if (flag == 0)
                {
                    if (client.InsertMenuInfo(menuname, path, parentid, sort, username))
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
                    if (client.UpdateMenuInfo(menuid, menuname, path, parentid, sort, username))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddMenu_Load(object sender, EventArgs e)
        {
            LoadGroupInfo();
            if (flag == 1)
            {
                txtmenuname.Text = menuname;
                txtpath.Text = path;
                txtsort.Text = sort;
                comboxparentno.SelectedValue = parentid;
            }
        }

        private void LoadGroupInfo()
        {
            DataTable dt = new DataTable();
            dt= client.GetAllGroupInfo();
            DataRow dr = dt.NewRow();
            dr["menuid"] = 0;
            dr["menuname"] = "根节点";
            dt.Rows.Add(dr);
            DataView dv = new DataView(dt);
            dv.Sort="menuid asc";
            dt = dv.ToTable();

            comboxparentno.DataSource = dt;
            comboxparentno.DisplayMember = "menuname";
            comboxparentno.ValueMember = "menuid";
        }
    }
}
