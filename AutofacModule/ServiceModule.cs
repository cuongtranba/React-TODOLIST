using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace AutofacModule
{
    public class ServiceModule:Module
    {
        private readonly string _serviceImplementationsAssemblyName = "ServiceImplementations";
        private readonly string _suffixesInterface = "Service";
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.Load(_serviceImplementationsAssemblyName);
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith(_suffixesInterface))
                .AsImplementedInterfaces();
        }
    }
}
