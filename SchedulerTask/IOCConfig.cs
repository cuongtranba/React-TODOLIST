using System.Reflection;
using Autofac;
using Autofac.Extras.Quartz;
using SchedulerTask.Jobs;

namespace SchedulerTask
{
    public class IOCConfig
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            //RegisterModule(builder);
            RegisterJob(builder);
            var container = builder.Build();
            return container;
        }

        private static void RegisterJob(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();
            // 1) Register IScheduler
            builder.RegisterModule(new QuartzAutofacFactoryModule());
            // 2) Register jobs
            builder.RegisterModule(new QuartzAutofacJobsModule(dataAccess));
            // 3) register IQuartzScheduler
            builder.RegisterAssemblyTypes(dataAccess).Where(c => c.Name.EndsWith("Job")).As<IQuartzScheduler>();
        }
    }
}