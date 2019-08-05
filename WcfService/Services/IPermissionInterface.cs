using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IWinformDataInterface”。
    [ServiceContract]
    public interface IPermissionInterface
    {
        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        bool UpdatePassword(string username, string password);

        [OperationContract]
        void Operatelog(string username, string ip, string computername, string formname);

        [OperationContract]
        bool CheckUsername(string username);

        [OperationContract]
        bool Register(string username, string password, string realname, string telephone, int deptno, List<int> roleid, string createby);

        [OperationContract]
        bool UpdateUser(string username, string realname, string telephone, int deptno, List<int> roleid, string updateby);

        [OperationContract]
        DataTable GetUserMenuInfo(string username);

        [OperationContract]
        DataTable GetUserInfo(string username);

        [OperationContract]
        bool StopUser(List<string> listusername);
    }
}
