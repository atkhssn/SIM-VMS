using Autofac;
using VMS.Infrastructure.Service;
using VMS.Persistence.UnitOfWork;

namespace VMS.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Service Scope
            builder.RegisterType<ManufactureService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<VehicleService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ModelTypeService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<MaintenanceService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<TransportAgencyService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<MerchantService>().AsSelf().InstancePerLifetimeScope();      
            builder.RegisterType<DriverService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<RoadExpenseService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<RequsitionService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<FuelService>().AsSelf().InstancePerLifetimeScope();
            #endregion

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
