using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.Services
{
    public partial interface IService
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
