using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Domain.Database;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class ManufactureRepository : Repository<Manufacture>, IManufactureRepository
    {
        public ManufactureRepository(VMSDbContext context)
            : base(context) { }

        public List<Manufacture> GetActiveManufacture()
        {
            var manufactureList = _Entities.Where(c => c.IsActive == true).ToList();

            return manufactureList;
        }

        public long IsManufactureDuplicate(long manufactureType, long modelType)
        {
            try
            {
                var data = _Entities
                    .Where(
                        (c => (c.ManufactureTypeId.Equals(manufactureType)) &&(c.ModelTypeId.Equals(modelType)))
                    )
                    .FirstOrDefault();


                if (data is null)
                {
                    return 0;

                }
                else if (data.IsActive) 
                {

                    return data.Id;
                  
                    
                }
                   
            }
            catch { }

            return 0;
        }

        public List<object> GetModel(long id)
        {
            var ModelObject = new List<object>();
            var manufacture = _Entities.Find(id);
            var ModelId = _Entities.Where(x => x.ManufactureTypeId == manufacture.ManufactureTypeId)
                                    .Distinct()
                                    .ToList();
            foreach (var model in ModelId)
            {
                
                if(model.ModelTypeId is 0)
                {
                    continue;
                }
                var result = _Context
                    .Set<ModelType>()
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == model.ModelTypeId);
                var Model = new { 
                    ModelName = result.Name,
                    Modelid = result.Id 
                };
                ModelObject.Add(Model);
            }
            return ModelObject;
        }
        //public async Task< List<object>> ModelName_Year(long id)
        //{

        //    var manufacture= _Entities.AsNoTracking().Where(c => c.Id == id).Select(c=>new { c.ModelYear, c.ModelId })
        //        .FirstOrDefaultAsync( );
        //    var ModelName = _Context.Set<ModelType>().AsNoTracking().Where(c => c.Id == id).Select(c => c.Name)
        //        .FirstOrDefaultAsync();
        //}
    }
}
