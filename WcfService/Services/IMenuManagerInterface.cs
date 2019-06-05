using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMenuManagerInterface”。
    [ServiceContract]
    public interface IMenuManagerInterface
    {
        [OperationContract]
        DataTable GetAllMenuInfo();

        [OperationContract(Name = "GetAllMenuInfoByName")]
        DataTable GetAllMenuInfo(string menuname);

        [OperationContract]
        DataTable GetAllGroupInfo();

        [OperationContract]
        bool InsertMenuInfo(string menuname, string path, int parentid, int sort, string createby);

        [OperationContract]
        bool UpdateMenuInfo(int menuid, string menuname, string path, int parentid, int sort, string updateby);
    }
}
