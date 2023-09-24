using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class MaintenancePartsRepository : Repository<MaintenanceParts>, IMaintenancePartsRepository
    {
        public MaintenancePartsRepository(DbContext context) : base(context)
        {
        }
    }
}
