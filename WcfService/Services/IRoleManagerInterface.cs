using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IRoleManagerInterface”。
    [ServiceContract]
    public interface IRoleManagerInterface
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
