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
        DataTable GetAllDeptInfo(string deptname);

        [OperationContract]
        bool InsertDeptInfo(string deptname, string remark, string createby);

        [OperationContract]
        bool UpdateDeptInfo(int deptno, string deptname, string remark, string updateby);
    }
}
