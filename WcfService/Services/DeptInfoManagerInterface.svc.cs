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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DeptInfoManagerInterface”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DeptInfoManagerInterface.svc 或 DeptInfoManagerInterface.svc.cs，然后开始调试。
    public class DeptInfoManagerInterface : IDeptInfoManagerInterface
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
