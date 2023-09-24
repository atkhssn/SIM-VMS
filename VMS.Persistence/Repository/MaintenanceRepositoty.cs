using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class MaintenanceRepositoty : Repository<Maintenance>, IMaintenanceRepository
    {
        public MaintenanceRepositoty(DbContext context)
            : base(context) { }


        public long LastId()
        {
            var entity = _Entities.AsQueryable();

            var LastId = entity.AsNoTracking().ToList().LastOrDefault();

            return LastId.MaintenanceId;
        }

    }
}
