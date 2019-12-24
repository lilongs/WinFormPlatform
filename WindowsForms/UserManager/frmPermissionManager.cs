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
using WcfService.Services;
using WindowsForms.Util;

namespace WindowsForms.UserManager
{
    public partial class frmPermissionManager : Form
    {
        public frmPermissionManager()
        {
            InitializeComponent();
        }
        BaseCommon bc = new BaseCommon();
        private List<int> lstCheckedID = new List<int>();//选择局ID集合

        private void frmPermissionManager_Load(object sender, EventArgs e)
        {
            LoadRoleInfo();
            LoadMenuInfo();
        }

        private void LoadRoleInfo()
        {
            IService client = bc.GetWcfService();
            DataTable dt = client.GetAllRoleInfo(string.Empty);
            listBoxControl1.DataSource = dt;
            listBoxControl1.DisplayMember = "rolename";
            listBoxControl1.ValueMember = "roleid";
        }

        private void LoadMenuInfo()
        {
            IService client = bc.GetWcfService();
            DataTable dt = client.GetAllMenuInfo();
            this.treeList1.DataSource = dt;
            treeList1.KeyFieldName = "menuid";
            treeList1.ParentFieldName = "parentid";
            treeList1.Columns[0].Caption = "菜单";
            treeList1.OptionsView.ShowCheckBoxes = true;
            ExpandTree();
        }

        private void ExpandTree()
        {
            foreach (TreeListNode nodes in treeList1.Nodes)
            {
                nodes.ExpandAll();
            }
        }

        private void listBoxControl1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadMenuInfo();
                int roleid = Convert.ToInt32(this.listBoxControl1.SelectedValue);
                role_menus(roleid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void role_menus(int roleid)
        {
            IService client = bc.GetWcfService();
            DataTable dtRoleMenu = client.GetRoleMenu(roleid);
            Dictionary<int, string> DicRoleMenu = new Dictionary<int, string>();
            //将角色权限装在到DicRoleMenu中
            foreach (DataRow dr in dtRoleMenu.Rows)
            {
                if (!DicRoleMenu.ContainsKey(Convert.ToInt32(dr["menuid"])))
                {
                    DicRoleMenu.Add(Convert.ToInt32(dr["menuid"]), dr["menuname"].ToString());
                }
            }
            //将权限装载到treeList1中
            if (treeList1.Nodes.Count > 0)
            {
                foreach (TreeListNode root in treeList1.Nodes)
                {
                    foreach (TreeListNode node in root.Nodes)
                    {
                        DataRowView dr = treeList1.GetDataRecordByNode(node) as DataRowView;
                        if (DicRoleMenu.ContainsKey(Convert.ToInt32(dr["menuid"])))
                        {
                            node.CheckState = CheckState.Checked;

                        }
                        SetCheckedParentNodes(node, node.CheckState);
                    }
                }
            }


        }

        //勾选/取消父节点，全选/全部取消子节点
        private void SetCheckedChildNodes(TreeListNode Parentnode, CheckState check)
        {
            for (int i = 0; i < Parentnode.Nodes.Count; i++)
            {
                Parentnode.Nodes[i].CheckState = check;
                SetCheckedChildNodes(Parentnode.Nodes[i], check);
            }
        }


        // 某父节点的子节点全部选择时,该父节点选择   某父节点的子节点未全部选择时,该父节点不选择
        private void SetCheckedParentNodes(TreeListNode Childnode, CheckState check)
        {
            if (Childnode.ParentNode != null)
            {

                CheckState parentCheckState = Childnode.ParentNode.CheckState;
                CheckState nodeCheckState;
                for (int i = 0; i < Childnode.ParentNode.Nodes.Count; i++)
                {
                    nodeCheckState = (CheckState)Childnode.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(nodeCheckState))//只要任意一个与其选中状态不一样即父节点状态不全选
                    {
                        parentCheckState = CheckState.Unchecked;
                        break;
                    }
                    parentCheckState = check;//否则（该节点的兄弟节点选中状态都相同），则父节点选中状态为该节点的选中状态
                }

                Childnode.ParentNode.CheckState = parentCheckState;
                SetCheckedParentNodes(Childnode.ParentNode, check);//遍历上级节点
            }
        }

        private void treeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        // 获取选择状态的数据主键ID集合
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
                    DataRowView drv = treeList1.GetDataRecordByNode(node) as DataRowView;
                    if (drv != null)
                    {
                        int ID = Convert.ToInt32(drv["menuid"]);
                        lstCheckedID.Add(ID);
                    }

                }
                GetCheckedID(node);
            }
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            try
            {
                int roleid = Convert.ToInt32(this.listBoxControl1.SelectedValue);
                this.lstCheckedID.Clear();
                if (treeList1.Nodes.Count > 0)
                {
                    foreach (TreeListNode root in treeList1.Nodes)
                    {
                        GetCheckedID(root);
                    }
                }
                IService client = bc.GetWcfService();
                MessageBox.Show(client.UpdateRoleMenu(roleid, lstCheckedID) > 0 ? "更新成功" : "更新失败");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}