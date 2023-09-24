using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;

namespace VMS.Persistence.Repository.IRepository
{
    public interface IVehicleTypeRepository : IRepository<VehicleType>
    {
        Task<long> GetIdAsync(string VehicleName);
        Task<bool> CreateAsync(string vehicleName);
        long IsVehicleDuplicate(string VehicleName);
    }
}
