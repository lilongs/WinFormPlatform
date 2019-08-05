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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“WinformDataInterface”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 WinformDataInterface.svc 或 WinformDataInterface.svc.cs，然后开始调试。
    public class PermissionInterface : IPermissionInterface
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
            return sysUser.login(username,password);
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
            return sysUser.UpdatePassword(username,password);
        }

        public bool UpdateUser(string username, string realname, string telephone, int deptno, List<int> roleid, string updateby)
        {
            return sysUser.updateUser(username, realname, telephone, deptno, roleid, updateby);
        }
    }
}
