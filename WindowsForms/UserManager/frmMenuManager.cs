using DevExpress.XtraTreeList.Nodes;
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
    public partial class frmMenuManager : Form
    {
        public frmMenuManager()
        {
            InitializeComponent();
        }
        MenuManagerInterfaceClient client = new MenuManagerInterfaceClient();
        public List<MenuInfo> lstChecked = new List<MenuInfo>();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMenuInfo(txtmenuname.Text.Trim());
        }

        private void LoadMenuInfo(string menuname)
        {
            DataTable dt = client.GetAllMenuInfoByName(menuname);
            this.gdcInfo.DataSource = dt;
            gdcInfo.KeyFieldName = "menuid";
            gdcInfo.ParentFieldName = "parentid";
            gdcInfo.Columns[0].Caption = "菜单";
            gdcInfo.Columns[1].Caption = "路径";
            gdcInfo.Columns[2].Caption = "父窗体";
            gdcInfo.Columns[3].Caption = "创建人";
            gdcInfo.Columns[4].Caption = "创建时间";
            gdcInfo.Columns[5].Caption = "更新人";
            gdcInfo.Columns[6].Caption = "更新时间";
            gdcInfo.OptionsView.ShowCheckBoxes = true;
            ExpandTree();
        }

        private void ExpandTree()
        {
            foreach(TreeListNode nodes in gdcInfo.Nodes)
            {
                nodes.ExpandAll();
            }
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

        private void GetCheckedID(TreeListNode parentNode)
        {
            if (parentNode.Nodes.Count == 0)
            {
                return;//递归终止
            }
            foreach (TreeListNode node in parentNode.Nodes)
            {
                if (node.CheckState == CheckState.Checked)
                {
                    DataRowView drv = gdcInfo.GetDataRecordByNode(node) as DataRowView;
                    MenuInfo menuInfo = new MenuInfo();
                    if (drv != null)
                    {
                        menuInfo.menuid = Convert.ToInt32(drv["menuid"]);
                        menuInfo.menuname = drv["menuname"].ToString();
                        menuInfo.parentid = Convert.ToInt32(drv["parentid"]);
                        menuInfo.sort = Convert.ToInt32(drv["sort"]);
                        menuInfo.path = drv["path"].ToString();
                        lstChecked.Add(menuInfo);
                    }

                }
                GetCheckedID(node);
            }
        }

        private void btnUpdateMenu_Click(object sender, EventArgs e)
        {
            if (gdcInfo.Nodes.Count > 0)
            {
                foreach (TreeListNode root in gdcInfo.Nodes)
                {
                    GetCheckedID(root);
                }
            }
            if (lstChecked.Count() <= 0)
            {
                MessageBox.Show("请选择要选择的行！");
                return;
            }
            else if(lstChecked.Count() >1)
            {
                MessageBox.Show("每次只能更新一个菜单！");
                return;
            }
            frmAddMenu frm = new frmAddMenu();
            frm.username = this.Tag.ToString().Split(',')[0];
            frm.menuid = Convert.ToInt32(lstChecked[0].menuid);
            frm.menuname = lstChecked[0].menuname;
            frm.parentid= lstChecked[0].parentid;
            frm.sort = lstChecked[0].sort.ToString();
            frm.path = lstChecked[0].path;
            frm.flag = 1;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadMenuInfo(string.Empty);
            }
        }
    }
    public class MenuInfo
    {

        public int menuid { get; set; }
        public string menuname { get; set; }
        public string path { get; set; }
        public int parentid { get; set; }
        public int sort { get; set; }

    }
}
