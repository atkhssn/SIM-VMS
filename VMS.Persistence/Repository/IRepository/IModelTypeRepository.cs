using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;

namespace VMS.Persistence.Repository.IRepository
{
    public interface IModelTypeRepository : IRepository<ModelType>
    {
        Task<long> ModelTypeIdAsync(string TypeName);
        Task<bool> CreateAsync(string modelName, long ManufactureTypeId);
        Task<long> GetIdAsync(string modelName);
    }
}
