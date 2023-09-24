using Microsoft.EntityFrameworkCore;
using VMS.Persistence.Repository.IRepository;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;

namespace VMS.Persistence.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DbContext context)
            : base(context) { }

        public void Add(Maintenance maintain)
        {
            throw new NotImplementedException();
        }

        public long? LastObjectId()
        {
            var data = _Entities.AsQueryable();
           
            try
            {
               

               
                    long? result = data.AsNoTracking().LastOrDefault().Id;
                return result;
            }
            catch
            {
                return 0;

            }
            
        }
    }
}
