using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DAL;
using WcfService.Services;

namespace WcfService.Impl
{
    public partial class ServiceImpl : IService
    {
        MenuInfo menuInfo = new MenuInfo();
        public DataTable GetAllGroupInfo()
        {
            return menuInfo.GetAllGroupInfo();
        }

        public DataTable GetAllMenuInfo()
        {
            return menuInfo.GetAllMenuInfo();
        }

        public DataTable GetAllMenuInfoByName(string menuname)
        {
            return menuInfo.GetAllMenuInfo(menuname);
        }

        public bool InsertMenuInfo(string menuname, string path, int parentid, int sort, string createby, string ImagePath)
        {
            return menuInfo.InsertMenuInfo(menuname, path, parentid, sort, createby, ImagePath);
        }

        public bool UpdateMenuInfo(int menuid, string menuname, string path, int parentid, int sort, string updateby, string ImagePath)
        {
            return menuInfo.UpdateMenuInfo(menuid, menuname, path, parentid, sort, updateby, ImagePath);
        }
    }
}
