using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;

namespace SchedulerTask
{
    public class IOCConfig
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            RegisterModule(builder);
            var container = builder.Build();
            return container;
        }

        private static void RegisterModule(ContainerBuilder builder)
        {
            try
            {
                var assemblies = Assembly.LoadFile($"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\..\\AutofacModule\\bin\\debug\\AutofacModule.dll");
                var modules = assemblies.GetTypes()
                              .Where(p => typeof(IModule).IsAssignableFrom(p)
                                          && !p.IsAbstract)
                              .Select(p => (IModule)Activator.CreateInstance(p));

                foreach (var module in modules)
                {
                    builder.RegisterModule(module);
                }

            }
            catch (Exception ex)
            {
                if (ex is ReflectionTypeLoadException)
                {
                    var typeLoadException = ex as ReflectionTypeLoadException;
                    var loaderExceptions = typeLoadException.LoaderExceptions;
                }
            }
          
        }
    }
}