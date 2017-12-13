using System;
using Autofac;
using Quartz;
using SchedulerTask.Jobs;

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
                var runjob = Container.Resolve<JobExecuted>();
                runjob.RunJobs();
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
