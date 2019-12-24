using ClientProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService.Services;

namespace WindowsForms.Util
{
    public class BaseCommon
    {
        public IService GetWcfService()
        {
            return ServiceProxyFactory.Create<IService>("ServiceImpl");
        }

    }
}
