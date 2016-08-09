using System;
using System.Linq;
using System.Reflection;
using System.Web.Configuration;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;

namespace React_TODOLIST
{
    public static class IOCConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            RegisterMVC(builder);
            RegisterModule(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterModule(ContainerBuilder builder)
        {
            var assemblies = Assembly.LoadFile($"{AppDomain.CurrentDomain.BaseDirectory}..\\AutofacModule\\bin\\debug\\AutofacModule.dll");
            var modules = assemblies.GetTypes()
                          .Where(p => typeof(IModule).IsAssignableFrom(p)
                                      && !p.IsAbstract)
                          .Select(p => (IModule)Activator.CreateInstance(p));

            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }
        }
        private static void RegisterMVC(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
        }
    }
}