using Autofac;
using System.Reflection;

namespace Application.Dependency
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ApplicationModule).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
        }
    }
}
