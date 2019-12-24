using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfService.Impl;

namespace Host
{
    class StartServer
    {
        static void Main(string[] args)
        {
            using(ServiceHost serviceHost=new ServiceHost(typeof(ServiceImpl)))
            {
                serviceHost.Opened += delegate
                {
                    Console.WriteLine("Service服务已启动");
                    Console.WriteLine("按Enter键停止服务");
                };
                serviceHost.Opening += delegate
                 {
                     Console.WriteLine("Service服务启动中...\n\n");
                 };
                serviceHost.Closing += delegate
                {
                    Console.WriteLine("Service服务终止中，稍后本窗口关闭...\n\n");
                };
                serviceHost.Open();

                Console.ReadLine();
            }
        }
    }
}
