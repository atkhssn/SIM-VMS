using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;

namespace VMS.Persistence.Repository.IRepository
{
    public interface IManufactureTypeRepository : IRepository<ManufactureType>
    {
        Task<long> ManufactureTypeIdAsync(string ManufactureName);
        Task<long> GetIdAsync(string modelName);
    }
}
