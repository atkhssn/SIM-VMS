using VMS.Domain.Entity;
using VMS.Infrastructure.Model;
using VMS.Persistence;
using VMS.Persistence.UnitOfWork;

namespace VMS.Infrastructure.Service
{
    public class ManufactureService
    {
        public readonly IUnitOfWork _unitOfWork;

        public ManufactureService() { }

        public ManufactureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Manufacture GetById(long id)
        {
            var data = _unitOfWork.ManufactureRepository.GetByid(id);
            return data;
        }

        public async Task<bool> CreateAsync(ManufactureModel model)
        {
            var ManufactureTypeId =
                await _unitOfWork.ManufactureTypeRepository.ManufactureTypeIdAsync(
                    model.ManufactureName
                );
            var ModelTypeId = await _unitOfWork.ModelTypeRepository.ModelTypeIdAsync(
                model.ModelName
            );


            try
            {
                if (ManufactureTypeId == 0)
                {
                    var manufactureType = new ManufactureType() { Name = model.ManufactureName };
                    _unitOfWork.ManufactureTypeRepository.Add(manufactureType);
                    _unitOfWork.SaveChanges();
                }
                ManufactureTypeId =
                await _unitOfWork.ManufactureTypeRepository.ManufactureTypeIdAsync(
                    model.ManufactureName
                );
            }
            catch
            {
                return false;

            }
            try
            {
                if (ModelTypeId == 0)
                {
                    await _unitOfWork.ModelTypeRepository.CreateAsync(
                        model.ModelName,
                        ManufactureTypeId
                    );
                }
                ModelTypeId = await _unitOfWork.ModelTypeRepository.ModelTypeIdAsync(
                model.ModelName);
            }
            catch
            {
                return false;
            }

            var IsManufactureDuplicate = _unitOfWork.ManufactureRepository.IsManufactureDuplicate(
                ManufactureTypeId,
                ModelTypeId
            );
                if (IsManufactureDuplicate > 0)
                {

                    var manufactureObject = _unitOfWork.ManufactureRepository.GetByid(IsManufactureDuplicate);
                    if (manufactureObject.IsActive)
                    {
                        return true;
                    }
                    try
                    {
                        manufactureObject.IsActive = true;
                        manufactureObject.UpdatedOn = DateTime.Now;
                        _unitOfWork.ManufactureRepository.Update(manufactureObject);
                        _unitOfWork.SaveChanges();
                        return true;
                    }
                    catch
                    {
                    }

                }
            try
            {
                Manufacture manufacture = new Manufacture()
                {
                    ManufactureTypeId = ManufactureTypeId,
                    ModelTypeId = ModelTypeId,
                    IsActive = true,
                    CreatedOn = DateTime.Now
                };

                _unitOfWork.ManufactureRepository.Add(manufacture);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
            

            public ManufactureType GetAllManufactureTypes(int id)
        {
            var data = _unitOfWork.ManufactureTypeRepository.GetByid(id);

            return data;
        }

        public List<object> GetManufactureData()
        {
            var ManufactureList = _unitOfWork.ManufactureRepository.GetActiveManufacture();
            var data = new List<object>();
            int z = 1;
            foreach (var manufacture in ManufactureList)
            {
                if(manufacture.ManufactureTypeId is 0| manufacture.ModelTypeId is 0)
                {
                    continue;
                }

                var manufactureObject = new
                {
                    sl = z,
                    manufactureId = manufacture.Id,
                    manufactureType = _unitOfWork.ManufactureTypeRepository
                        .GetByid(manufacture.ManufactureTypeId)
                        .Name,
                    ModelType = _unitOfWork.ModelTypeRepository
                        .GetByid(manufacture.ModelTypeId)
                        .Name,
                    ModelTypeId = manufacture.ModelTypeId
                };
                data.Add(manufactureObject);
                z++;
            }
            return data;
        }

        public object GetByManufacture(long id)
        {
            var Manufacture = _unitOfWork.ManufactureRepository.GetByid(id);
            var ManufactureType = _unitOfWork.ManufactureTypeRepository
                .GetByid(Manufacture.ManufactureTypeId)
                .Name;
            var modelObject = new
            {
                modelTypeName = _unitOfWork.ModelTypeRepository
                    .GetByid(Manufacture.ModelTypeId)
                    .Name,
                manufactureType = ManufactureType,
                manufactureId = Manufacture.Id
            };
            return modelObject;
        }

        public bool EditManufacture(ManufactureModel manufacture)
        {
            try
            {
                var Manufacture = _unitOfWork.ManufactureRepository.GetByid(
                    manufacture.ManufactureId
                );

                var ManufactureType = _unitOfWork.ManufactureTypeRepository.GetByid(
                    Manufacture.ManufactureTypeId
                );
                var ModelType = _unitOfWork.ModelTypeRepository.GetByid(Manufacture.ModelTypeId);
                ModelType.Name = manufacture.ModelName;
                _unitOfWork.ModelTypeRepository.Update(ModelType);
                ManufactureType.Name = manufacture.ManufactureName;

                _unitOfWork.ManufactureTypeRepository.Update(ManufactureType);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SoftDelete(long id)
        {
            var manufacture = _unitOfWork.ManufactureRepository.GetByid(id);

            manufacture.IsActive = false;
            try
            {
                _unitOfWork.ManufactureRepository.Update(manufacture);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<object> GetManufacture()
        {
            var ManufactureList = _unitOfWork.ManufactureRepository
                .GetAll()
                .DistinctBy(c => c.ManufactureTypeId);
            //var ModelList = await _unitOFWork.ModelTypeRepository.GetAllEnumerableAsync();
            var modelObject = new List<object>();

            foreach (var manufacture in ManufactureList)
            {
                if (manufacture.ManufactureTypeId is 0 | manufacture.ModelTypeId is 0)
                {
                    continue;
                }
                var model = _unitOfWork.ManufactureTypeRepository.GetByid(
                    manufacture.ManufactureTypeId
                );

                try
                {
                    var modelOb = new
                    {
                        manufactureId = manufacture.Id,
                        manufcatureTypeId = manufacture.ManufactureTypeId,
                        ManufactureName = model.Name
                        //modelYear = modellist.ModelYear.Year,
                        //ManufactureName = $"{model.Name} {modellist.ModelYear.Year}"
                    };
                    modelObject.Add(modelOb);
                }
                catch { }
            }

            return modelObject;
        }

        public List<object> GetModel(long ManufactureId)
        {
            var ModelList = _unitOfWork.ManufactureRepository.GetModel(ManufactureId);

            return ModelList;
        }
        
        public ModelType SingleModel(long ModelIdId)
        {
            var ModelType = _unitOfWork.ModelTypeRepository.GetByid(ModelIdId);

            return ModelType;
        }
        //public async Task<List<ModelType>> GetModelYear()
        //{
        //    //var vehicleName = _unitOfWork.vehicleTypeRepository.GetByid().VehicleName;
        //    var Models =  _unitOfWork.ModelTypeRepository.GetAll();
        //    //var data = _unitOfWork.ManufactureTypeRepository.GetByid();

        //    return (List<ModelType>)Models;
        //}
        //public object GetTypeYearCat(int id)
        //  {
        //    var vehicleName=   _unitOfWork.vehicleTypeRepository.GetByid(id);
        //    var data = _unitOfWork.ManufactureTypeRepository.GetByid(id);

        //    return data;
        //  }

        //public object GetDisableField(long id)
        //{
        //    var Vehicle = _unitOfWork.ModelRepository.GetByid(id);
        //    var vehicleType = _unitOfWork.vehicleTypeRepository.GetByid(Vehicle.VehicleCategory);

        //    return new
        //    {
        //        VehicleIsStanderd = (Vehicle.IsStanderd==false)? "Hybrid" : "Standard",
        //        vehicleType = vehicleType.VehicleName,
        //        year= Vehicle.ModelYear
        //    };
        //}
    }
}
