using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfService.DAL;

namespace WcfService.Services
{
    public partial interface IService
    {
        [OperationContract]
        bool AdddAutoSendEmailQueue(Queues queue, List<Recipients> recipients, List<Attachs> attachs);
    }
}
