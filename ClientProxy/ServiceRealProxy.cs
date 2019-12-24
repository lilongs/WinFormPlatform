using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientProxy
{
    public class ServiceRealProxy<T> : RealProxy
    {
        private string _endPointName;

        public ServiceRealProxy(string endPointName) : base(typeof(T))
        {
            if (String.IsNullOrEmpty(endPointName))
            {
                throw new ArgumentNullException("endPointName");
            }
            this._endPointName = endPointName;
        }

        public override IMessage Invoke(IMessage msg)
        {
            T channel = ChannelFactoryCreator.Create<T>(this._endPointName).CreateChannel();
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;
            IMethodReturnMessage methodReturn = null;

            object[] args = Array.CreateInstance(typeof(object),methodCall.Args.Length)as object[];
            methodCall.Args.CopyTo(args, 0);

            try
            {
                object returnValue = methodCall.MethodBase.Invoke(channel, args);
                methodReturn = new ReturnMessage(returnValue, args, args.Length, methodCall.LogicalCallContext, methodCall);
                (channel as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                if (ex.InnerException is CommunicationException || ex.InnerException is TimeoutException)
                {
                    (channel as ICommunicationObject).Abort();
                }
                if(ex.InnerException != null)
                {
                    methodReturn = new ReturnMessage(ex.InnerException, methodCall);
                }
                else
                {
                    methodReturn = new ReturnMessage(ex,methodCall);
                }
            }
            return methodReturn;
        }
    }
}
