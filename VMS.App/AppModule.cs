using Autofac;
using VMS.Infrastructure.Model;

namespace VMS.App
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ManufactureModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<MaintenanceModel>().AsSelf().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
