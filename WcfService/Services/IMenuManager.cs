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
        DataTable GetAllMenuInfo();

        [OperationContract]
        DataTable GetAllMenuInfoByName(string menuname);

        [OperationContract]
        DataTable GetAllGroupInfo();

        [OperationContract]
        bool InsertMenuInfo(string menuname, string path, int parentid, int sort, string createby,string ImagePath);

        [OperationContract]
        bool UpdateMenuInfo(int menuid, string menuname, string path, int parentid, int sort, string updateby, string ImagePath);
    }
}
