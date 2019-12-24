using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProxy
{
    public static class ServiceProxyFactory
    {
        public static T Create<T>(string endPointName)
        {
            if (String.IsNullOrEmpty(endPointName))
            {
                throw new ArgumentNullException("endPointName");
            }
            return (T)(new ServiceRealProxy<T>(endPointName).GetTransparentProxy());
        }
    }
}
