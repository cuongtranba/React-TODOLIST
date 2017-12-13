using System;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace AutofacModule
{
    public class ServiceModule : Module
    {
        private readonly string _serviceImplementationsAssemblyName = $"{AppDomain.CurrentDomain.BaseDirectory}..\\ServiceImplementations\\bin\\debug\\ServiceImplementations.dll";
        private readonly string _suffixesInterface = "Service";
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.LoadFile(_serviceImplementationsAssemblyName);
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith(_suffixesInterface))
                .AsImplementedInterfaces();
        }
    }
}
