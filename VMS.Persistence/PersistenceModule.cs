using Autofac;
using VMS.Domain.Database;
using VMS.Persistence.Repository;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence
{
    public class PersistenceModule : Module
    {
        public string _connectionString;
        public string _migrationString;

        public PersistenceModule(string connectionString, string migrationString)
        {
            _connectionString = connectionString;
            _migrationString = migrationString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<VMSDbContext>()
                .AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationString", _migrationString)
                .InstancePerLifetimeScope();

            builder
                .RegisterType<VMSDbContext>()
                .As<IVMSDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationString", _migrationString)
                .InstancePerLifetimeScope();



            builder.RegisterType<DriverRepository>().As<IDriverRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<MaintenancePartsRepository>().As<IMaintenancePartsRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<MaintenanceRepositoty>().As<IMaintenanceRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<MaintenanceTypeRepository>().As<IMaintenanceTypeRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<MerchantRepository>().As<IMerchantRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ManufactureRepository>().As<IManufactureRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ManufactureTypeRepository>().As<IManufactureTypeRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ModelTypeRepository>().As<IModelTypeRepository>()
                .InstancePerLifetimeScope();      
            builder.RegisterType<TransportAgencyRepository>().As<ITransportAgencyRepository>()
                .InstancePerLifetimeScope();       
            builder.RegisterType<TripExpensesRepository>().As<ITripExpensesRepository>()
                .InstancePerLifetimeScope();   
            builder.RegisterType<TripRepository>().As<ITripRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<VehicleRepository>().As<IVehicleRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<VehicleTypeRepository>().As<IVehicleTypeRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<RoadExpenseRepository>().As<IRoadExpenseRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<RequisitionRepository>().As<IRequisitionRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<FuelRepository>().As<IFuelRepository>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
