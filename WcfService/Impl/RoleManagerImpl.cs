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
