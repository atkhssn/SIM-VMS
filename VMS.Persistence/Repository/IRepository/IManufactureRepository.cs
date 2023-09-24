using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;

namespace VMS.Persistence.Repository.IRepository
{
    public interface IManufactureRepository : IRepository<Manufacture>
    {
        List<Manufacture> GetActiveManufacture();
        List<object> GetModel(long id);
        long IsManufactureDuplicate(long manufactureType, long modelType);
    }
}
