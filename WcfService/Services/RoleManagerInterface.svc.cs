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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“RoleManagerInterface”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 RoleManagerInterface.svc 或 RoleManagerInterface.svc.cs，然后开始调试。
    public class RoleManagerInterface : IRoleManagerInterface
    {
        RoleInfo roleInfo = new RoleInfo();
        public DataTable GetAllRoleInfo(string rolename)
        {
            return roleInfo.GetAllRoleInfo(rolename);
        }

        public DataTable GetRoleMenu(int roleid)
        {
            return roleInfo.GetRoleMenu(roleid);
        }

        public bool InsertRoleInfo(string rolename, string remark, string createby)
        {
            return roleInfo.InsertRoleInfo(rolename, remark, createby);
        }

        public bool UpdateRoleInfo(int roleid, string rolename, string remark, string updateby)
        {
            return roleInfo.UpdateRoleInfo(roleid, rolename, remark, updateby);
        }

        public int UpdateRoleMenu(int roleid, List<int> listMenuid)
        {
            return roleInfo.UpdateRoleMenu(roleid, listMenuid);
        }
    }
}
