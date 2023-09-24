using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;

namespace VMS.Domain.Database
{
    public class VMSDbContext : DbContext, IVMSDbContext
    {
        public string _connectionString;
        public string _migrationString;

        public VMSDbContext(string connectionString, string migrationString)
        {
            _connectionString = connectionString;
            _migrationString = migrationString;
        }

        //public VMSDbContext(DbContextOptions<VMSDbContext> options,MigrationsAssembly migrationsAssembly)
        //    : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    _connectionString,
                    (c) => c.MigrationsAssembly(_migrationString)
                );
            }
            base.OnConfiguring(optionsBuilder);
        }

        DbSet<Manufacture> Manufacture { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }
        DbSet<VehicleType> vehicleType { get; set; }
        DbSet<ManufactureType> ManufactureType { get; set; }
        DbSet<ModelType> ModelType { get; set; }
        DbSet<TransportAgency> TransportAgency { get; set; }
        DbSet<Maintenance> Maintenances { get; set; }
        DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        DbSet<TripExpenses> TripExpenses { get; set; }
        DbSet<TollDetails> TollDetails { get; set; }
        DbSet<Merchant> Merchant { get; set; }
        DbSet<MaintenanceParts> MaintenanceParts { get; set; }
        DbSet<Driver> Driver { get; set; }
        DbSet<Trip> Trip { get; set; }
        DbSet<RoadExpense> RoadExpenses { get; set; }
        DbSet<Requisition> Requisitions { get; set; }
        DbSet<Fuel> Fuels { get; set; }
    }
}
