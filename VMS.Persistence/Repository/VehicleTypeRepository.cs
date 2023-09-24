using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class VehicleTypeRepository : Repository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(DbContext context)
            : base(context) { }

        public async Task<bool> CreateAsync(string vehicleName)
        {
            VehicleType vehicleType = new VehicleType() { VehicleTypeName = vehicleName };
            try
            {
                await _Entities.AddAsync(vehicleType);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public long IsVehicleDuplicate(string VehicleName)
        {
            var result = _Entities
                .AsNoTracking()
                .FirstOrDefault(c => (c.VehicleTypeName).Equals(VehicleName));
            if (result != null)
            {
                return result.Id;
            }
            return 0;
        }

        public async Task<long> GetIdAsync(string VehicleName)
        {
            try
            {
                var data = await _Entities
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => (c.VehicleTypeName).Equals(VehicleName));

                return data.Id;
            }
            catch
            {
                return 0;
            }
        }
    }
}
