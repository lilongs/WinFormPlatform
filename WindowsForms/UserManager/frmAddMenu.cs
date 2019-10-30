using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
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
        public string image_path = string.Empty;
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
                string image_path = popupGalleryEdit1.Text;
                if (flag == 0)
                {
                    if (client.InsertMenuInfo(menuname, path, parentid, sort, username, image_path))
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
                    if (client.UpdateMenuInfo(menuid, menuname, path, parentid, sort, username, image_path))
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

        private void InitPopupGalleryEdit()
        {
            try
            {
                PopupGalleryEditGallery inplaceGallery = new PopupGalleryEditGallery() { ImageSize = new System.Drawing.Size(32, 32) };
                GalleryItemGroup group = new GalleryItemGroup() { Caption = "32*32菜单图标" };
                group.CaptionControl = popupGalleryEdit1;

                using (System.Resources.ResourceReader reader = GetResourceReader(DevExpress.Utils.DxImageAssemblyUtil.ImageAssembly))
                {
                    System.Collections.IDictionaryEnumerator dict = reader.GetEnumerator();
                    while (dict.MoveNext())
                    {
                        string key = (string)dict.Key as string;
                        if (!DevExpress.Utils.DxImageAssemblyUtil.ImageProvider.IsBrowsable(key)) continue;
                        if (IsImageBasedResource(key) && key.Contains("16x16") == false)
                        {
                            Image image = GetImageFromStream((System.IO.Stream)dict.Value);
                            GalleryItem GItem = new GalleryItem(image, key, key);
                            GItem.Value = key;
                            group.Items.Add(GItem);
                        }
                    }
                }
                inplaceGallery.Groups.Add(group);
                popupGalleryEdit1.Properties.Gallery.Assign(inplaceGallery);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static bool IsImageBasedResource(string key)
        {
            return key.EndsWith(".png",StringComparison.Ordinal);
        }

        private static System.Resources.ResourceReader GetResourceReader(System.Reflection.Assembly assembly)
        {
            var resources = assembly.GetManifestResourceNames();
            var imageResources = Array.FindAll(resources, x => x.EndsWith(".resources"));
            if (imageResources.Length != 1)
            {
                throw new Exception("读取异常");
            }
            return new System.Resources.ResourceReader(assembly.GetManifestResourceStream(imageResources[0]));
        }

        private static Image GetImageFromStream(System.IO.Stream stream)
        {
            Image res = null;
            try
            {
                res = Image.FromStream(stream);
            }
            catch
            {
                res = null;
            }
            return res;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddMenu_Load(object sender, EventArgs e)
        {
            try
            {
                InitPopupGalleryEdit();
                LoadGroupInfo();
                if (flag == 1)
                {
                    txtmenuname.Text = menuname;
                    txtpath.Text = path;
                    popupGalleryEdit1.Text = image_path;
                    txtsort.Text = sort;
                    comboxparentno.SelectedValue = parentid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadGroupInfo()
        {
            DataTable dt = new DataTable();
            dt = client.GetAllGroupInfo();
            DataRow dr = dt.NewRow();
            dr["menuid"] = 0;
            dr["menuname"] = "根节点";
            dt.Rows.Add(dr);
            DataView dv = new DataView(dt);
            dv.Sort = "menuid asc";
            dt = dv.ToTable();

            comboxparentno.DataSource = dt;
            comboxparentno.DisplayMember = "menuname";
            comboxparentno.ValueMember = "menuid";
        }
    }
}
