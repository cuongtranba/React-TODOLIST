using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extras.Quartz;
using LiteDB;
using Quartz;
using SchedulerTask.Jobs;

namespace SchedulerTask
{
    public class IOCConfig
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            RegisterJob(builder);
            RegisterModule(builder);
            RegisteLiteDb(builder);
            var container = builder.Build();
            return container;
        }

        private static void RegisteLiteDb(ContainerBuilder builder)
        {
            var dbpath = $"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\..\\LiteDb\\TodoDb.db";
            var haveFile = File.Exists(dbpath);
            if (haveFile)
            {
                var dblite = new LiteDatabase(dbpath);
                builder.Register(c => dblite).AsSelf();
            }
        }

        private static void RegisterModule(ContainerBuilder builder)
        {
            var assemblies = Assembly.LoadFile($"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\..\\ServiceImplementations\\bin\\debug\\ServiceImplementations.dll");
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }

        private static void RegisterJob(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();
            // 1) Register IScheduler
            builder.RegisterModule(new QuartzAutofacFactoryModule());
            // 2) Register jobs
            builder.RegisterModule(new QuartzAutofacJobsModule(dataAccess));
            // 3) register IQuartzScheduler
            builder.RegisterAssemblyTypes(dataAccess).Where(c => c.Name.EndsWith("Job")).As<IQuartzJob>();
            // 4) register run job
            builder.Register(c => new JobExecuted(c.Resolve<IEnumerable<IQuartzJob>>(), c.Resolve<IScheduler>())).SingleInstance();
        }
    }
}