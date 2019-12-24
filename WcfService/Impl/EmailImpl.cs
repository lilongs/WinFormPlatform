using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService.DAL;
using WcfService.Services;

namespace WcfService.Impl
{
    public partial class ServiceImpl : IService
    {
        Email email = new Email();

        public bool AdddAutoSendEmailQueue(Queues queue, List<Recipients> recipients, List<Attachs> attachs)
        {
            return email.AdddEmailQueue(queue, recipients, attachs);
        }
    }
}