using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class MaintenanceTypeRepository : Repository<MaintenanceType>, IMaintenanceTypeRepository
    {
        public MaintenanceTypeRepository(DbContext context)
            : base(context) { }
    }
}
