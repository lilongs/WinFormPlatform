using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientProxy
{
    internal static class ChannelFactoryCreator
    {
        private static Hashtable channelFactories = new Hashtable();

        public static ChannelFactory<T> Create<T>(string endPointName)
        {
            if (String.IsNullOrEmpty(endPointName))
            {
                throw new ArgumentNullException("endPointName");
            }

            ChannelFactory<T> channelFactory = null;
            if (channelFactories.ContainsKey(endPointName))
            {
                channelFactory = channelFactories[endPointName] as ChannelFactory<T>;
            }
            if (channelFactory == null)
            {
                channelFactory = new ChannelFactory<T>(endPointName);
                lock (channelFactories.SyncRoot)
                {
                    channelFactories[endPointName] = channelFactory;
                }
            }
            return channelFactory;
        }
    }
}
