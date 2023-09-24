using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class ModelTypeRepository : Repository<ModelType>, IModelTypeRepository
    {
        public ModelTypeRepository(DbContext context)
            : base(context) { }

        //<ModelType Create>
        // Create Model From ManufactureService
        // by ManufactureModel and View

        // </ModelType Create>

        public async Task<long> ModelTypeIdAsync(string TypeName)
        {
            try
            {
                var data = await _Entities
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => (c.Name).Equals(TypeName));
                while (data is not null)
                    return data.Id;
            }
            catch { }

            return 0;
        }

        public async Task<bool> CreateAsync(string modelName, long ManufcatureTypeId)
        {
            try
            {
                var model = new ModelType()
                {
                    Name = modelName,
                    ManufactureType = ManufcatureTypeId,
                };

                await _Entities.AddAsync(model);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
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

        //public async Task< string> GetModelName(int id)
        //{

        //    var modelName=_Entities.AsNoTracking().Where(c=>c.Id==id).Select(c => c.Name)
        //           .FirstOrDefaultAsync().ToString();
        //    _Context.Set<manu>
        //    return modelName;

        //}
    }
}
