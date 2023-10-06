using Autofac;
using System.Reflection;

namespace Jazani.Infraestructura.Cores.Contexts
{
    public class InfraestructuraAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
