using Microsoft.EntityFrameworkCore;

using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class ManufactureTypeRepository : Repository<ManufactureType>, IManufactureTypeRepository
    {
        public ManufactureTypeRepository(DbContext context)
            : base((DbContext)context) { }

        public async Task<long> ManufactureTypeIdAsync(string ManufactureName)
        {
            var result = await _Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name.Equals(ManufactureName));
            if (result != null)
            {
                return result.Id;
            }
            return 0;
        }

        public async Task<long> GetIdAsync(string modelName)
        {
            try
            {
                long Id = await _Entities
                    .AsNoTracking()
                    .Where(c => (c.Name).Equals(modelName))
                    .Select(c => c.Id)
                    .FirstOrDefaultAsync();
                return Id;
            }
            catch
            {
                return 0;
            }
        }
    }
}
