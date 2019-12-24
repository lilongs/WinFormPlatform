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
        DeptInfo deptInfo = new DeptInfo();
        public DataTable GetAllDeptInfo(string deptname)
        {
            return deptInfo.GetAllDeptInfo(deptname);
        }

        public bool InsertDeptInfo(string deptname, string remark, string createby)
        {
            return deptInfo.InsertDeptInfo(deptname, remark, createby);
        }

        public bool UpdateDeptInfo(int deptno, string deptname, string remark, string updateby)
        {
            return deptInfo.UpdateDeptInfo(deptno, deptname, remark, updateby);
        }
    }
}
