using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.Services
{
    public partial interface IService
    {
        [OperationContract]
        string ServerVersion();
    }
}
