using Microsoft.EntityFrameworkCore;
using VMS.Domain.Database;
using VMS.Persistence.Repository;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly IVMSDbContext _dbContext;

        public UnitOfWork(IVMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IVehicleRepository VehicleRepository
        {
            get { return new VehicleRepository((DbContext)_dbContext); }
        }
        public IVehicleTypeRepository vehicleTypeRepository
        {
            get { return new VehicleTypeRepository((DbContext)_dbContext); }
        }
        public IManufactureTypeRepository ManufactureTypeRepository
        {
            get { return new ManufactureTypeRepository((DbContext)_dbContext); }
        }

        public IManufactureRepository ManufactureRepository
        {
            get { return new ManufactureRepository((VMSDbContext)_dbContext); }
        }
        public IModelTypeRepository ModelTypeRepository
        {
            get { return new ModelTypeRepository((VMSDbContext)_dbContext); }
        }
        public IMaintenanceRepository MaintenanceRepository
        {
            get { return new MaintenanceRepositoty((VMSDbContext)_dbContext); }
        }

        public IMaintenanceTypeRepository MaintenanceTypeRepository
        {
            get { return new MaintenanceTypeRepository((VMSDbContext)_dbContext); }
        }

        public ITransportAgencyRepository TransportAgencyRepository
        {
            get { return new TransportAgencyRepository((VMSDbContext)_dbContext); }
        }

        public ITripExpensesRepository TripExpensesRepository
        {
            get { return new TripExpensesRepository((VMSDbContext)_dbContext); }
        }

		public IMerchantRepository MerchantRepository
		{
			get { return new MerchantRepository((VMSDbContext)_dbContext); }
		}

        public IDriverRepository DriverRepository
        {
            get { return new DriverRepository((VMSDbContext)_dbContext); }
        }

        public IMaintenancePartsRepository MaintenancePartsRepository
        {
            get { return new MaintenancePartsRepository((VMSDbContext)_dbContext); }
        }

        public ITripRepository TripRepository
        {
            get { return new TripRepository((VMSDbContext)_dbContext); }
        }

        public IRoadExpenseRepository RoadExpenseRepository
        {
            get { return new RoadExpenseRepository((VMSDbContext)_dbContext); }
        }

        public IRequisitionRepository RequisitionRepository
        {
            get { return new RequisitionRepository((VMSDbContext)_dbContext); }
        }

        public IFuelRepository FuelRepository
        {
            get { return new FuelRepository((VMSDbContext)_dbContext); }
        }

        public void Dispose()
        {
            DbContext context = (DbContext)_dbContext;
            context.Dispose();
        }

        public bool SaveChanges()
        {
            DbContext context = (DbContext)_dbContext;
            int isSave = context.SaveChanges();
            if (isSave > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
