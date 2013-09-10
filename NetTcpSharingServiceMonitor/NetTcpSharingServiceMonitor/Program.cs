using System;

using Common;
using Core;

using Microsoft.Practices.Unity;

namespace NetTcpSharingServiceMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrapper.GetContainer();
            var monitor = container.Resolve<IHealthMonitor>();
            monitor.Run();
            Console.Read();
        }
    }
}
