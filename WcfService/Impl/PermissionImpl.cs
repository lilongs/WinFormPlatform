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
        SysUser sysUser = new SysUser();
        public bool CheckUsername(string username)
        {
            return sysUser.checkUsername(username);
        }

        public DataTable GetUserInfo(string username)
        {
            return sysUser.getUserInfo(username);
        }

        public DataTable GetUserMenuInfo(string username)
        {
            return sysUser.getUserMenuInfo(username);
        }

        public bool Login(string username, string password)
        {
            return sysUser.login(username, password);
        }

        public void Operatelog(string username, string ip, string computername, string formname)
        {
            sysUser.operatelog(username, ip, computername, formname);
        }

        public bool Register(string username, string password, string realname, string telephone, int deptno, List<int> roleid, string createby)
        {
            return sysUser.register(username, password, realname, telephone, deptno, roleid, createby);
        }

        public bool StopUser(List<string> listusername)
        {
            return sysUser.StopUser(listusername);
        }

        public bool UpdatePassword(string username, string password)
        {
            return sysUser.UpdatePassword(username, password);
        }

        public bool UpdateUser(string username, string realname, string telephone, int deptno, List<int> roleid, string updateby)
        {
            return sysUser.updateUser(username, realname, telephone, deptno, roleid, updateby);
        }
    }
}
