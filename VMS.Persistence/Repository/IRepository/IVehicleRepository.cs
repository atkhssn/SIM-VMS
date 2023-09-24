using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;

namespace VMS.Persistence.Repository.IRepository
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        void Add(Maintenance maintain);
        long? LastObjectId();

    }
}
