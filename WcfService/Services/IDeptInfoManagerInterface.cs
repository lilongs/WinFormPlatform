using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDeptInfoManagerInterface”。
    [ServiceContract]
    public interface IDeptInfoManagerInterface
    {
        [OperationContract]
        DataTable GetAllDeptInfo(string deptname);

        [OperationContract]
        bool InsertDeptInfo(string deptname, string remark, string createby);

        [OperationContract]
        bool UpdateDeptInfo(int deptno, string deptname, string remark, string updateby);
    }
}
