using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace React_TODOLIST
{
    public static class IOCConfig
    {
        public class IocConfig
        {
            public static void Register()
            {
                var builder = new ContainerBuilder();

                RegisterMVC(builder);
                RegisterServices(builder);
                RegisterModule(builder);
                var container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }

            private static void RegisterModule(ContainerBuilder builder)
            {
                throw new System.NotImplementedException();
            }

            private static void RegisterServices(ContainerBuilder builder)
            {
                var dataAccess = Assembly.GetExecutingAssembly();
                builder.RegisterAssemblyTypes(dataAccess)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces();
            }



            //private static void RegisterDbFactory(ContainerBuilder builder)
            //{
            //    builder.RegisterAssemblyTypes(typeof(IDbFactory<>).Assembly).AsClosedTypesOf(typeof(IDbFactory<>)).InstancePerRequest();
            //}

            private static void RegisterMVC(ContainerBuilder builder)
            {
                builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            }
        }
    }
}