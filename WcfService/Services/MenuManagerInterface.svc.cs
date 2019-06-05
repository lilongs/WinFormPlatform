using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DAL;

namespace WcfService.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MenuManagerInterface”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MenuManagerInterface.svc 或 MenuManagerInterface.svc.cs，然后开始调试。
    public class MenuManagerInterface : IMenuManagerInterface
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

        public DataTable GetAllMenuInfo(string menuname)
        {
            return menuInfo.GetAllMenuInfo(menuname);
        }

        public bool InsertMenuInfo(string menuname, string path, int parentid, int sort, string createby)
        {
            return menuInfo.InsertMenuInfo(menuname, path, parentid, sort, createby);
        }

        public bool UpdateMenuInfo(int menuid, string menuname, string path, int parentid, int sort, string updateby)
        {
            return menuInfo.UpdateMenuInfo(menuid, menuname, path, parentid, sort, updateby);
        }
    }
}
