using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;

namespace VMS.Persistence.Repository.IRepository
{
    public interface IMaintenanceRepository : IRepository<Maintenance> 
    {
        long LastId();


    }
}
