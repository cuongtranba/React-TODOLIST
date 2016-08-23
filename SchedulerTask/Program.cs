using System;
using Autofac;
using Quartz;

namespace SchedulerTask
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            try
            {
                Container = IOCConfig.Register();
                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };
                var scheduler = Container.Resolve<IScheduler>();
                var jobs = Container.Resolve<IJob>();
                

            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
    }
}
