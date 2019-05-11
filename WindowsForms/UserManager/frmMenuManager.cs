using Common.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.UserManager
{
    public partial class frmMenuManager : Form
    {
        public frmMenuManager()
        {
            InitializeComponent();
        }
        MenuInfo menuInfo = new MenuInfo();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMenuInfo(txtmenuname.Text.Trim());
        }

        private void LoadMenuInfo(string menuname)
        {
            DataTable dt = menuInfo.getAllMenuInfo(menuname);
            this.gdcInfo.DataSource = dt;
        }

        private void frmMenuManager_Load(object sender, EventArgs e)
        {
            LoadMenuInfo(string.Empty);
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            frmAddMenu frm = new frmAddMenu();
            frm.username = this.Tag.ToString().Split(',')[0];
            frm.flag = 0;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadMenuInfo(string.Empty);
            }
        }

        private void btnUpdateMenu_Click(object sender, EventArgs e)
        {
            if (gdvInfo.GetSelectedRows().Count() <= 0)
            {
                MessageBox.Show("请选择要选择的行！");
                return;
            }
            frmAddMenu frm = new frmAddMenu();
            frm.username = this.Tag.ToString().Split(',')[0];
            frm.menuid = Convert.ToInt32(gdvInfo.GetFocusedRowCellValue("menuid"));
            frm.menuname = gdvInfo.GetFocusedRowCellValue("menuname").ToString();
            frm.parentid=Convert.ToInt32(gdvInfo.GetFocusedRowCellValue("parentid"));
            frm.sort = gdvInfo.GetFocusedRowCellValue("sort").ToString();
            frm.path = gdvInfo.GetFocusedRowCellValue("path").ToString();
            frm.flag = 1;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadMenuInfo(string.Empty);
            }
        }
    }
}
