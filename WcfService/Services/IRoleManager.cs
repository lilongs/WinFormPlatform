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
        DataTable GetAllRoleInfo(string rolename);

        [OperationContract]
        DataTable GetRoleMenu(int roleid);

        [OperationContract]
        int UpdateRoleMenu(int roleid, List<int> listMenuid);

        [OperationContract]
        bool InsertRoleInfo(string rolename, string remark, string createby);

        [OperationContract]
        bool UpdateRoleInfo(int roleid, string rolename, string remark, string updateby);
    }
}
