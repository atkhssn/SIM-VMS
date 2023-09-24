using VMS.Infrastructure.Model;
using VMS.Persistence;
using VMS.Infrastructure.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using VMS.Domain.Entity;
using VMS.Persistence.UnitOfWork;
using static VMS.Infrastructure.Utility.EnumCollection;

namespace VMS.Infrastructure.Service
{
    public class VehicleService
    {
        protected readonly IUnitOfWork _unitOFWork;
        public IHostingEnvironment _Environment;

        public VehicleService() { }

        public VehicleService(IUnitOfWork unitOfWork, IHostingEnvironment Environment)
        {
            _unitOFWork = unitOfWork;
            _Environment = Environment;
        }

        public bool Create(VehicleModel model)
        {
            //var IsVehicleDuplicate = _unitOFWork.vehicleTypeRepository.IsVehicleDuplicate(
            //    model.VehicleCategory
            //);
            //if (IsVehicleDuplicate == 0)
            //{
            //    _unitOFWork.vehicleTypeRepository.CreateAsync(model.VehicleCategory);
            //    _unitOFWork.SaveChanges();
            //    IsVehicleDuplicate = _unitOFWork.vehicleTypeRepository
            //        .GetIdAsync(model.VehicleCategory)
            //        .Result;
            //}

            //if (IsVehicleDuplicate == 0)
            //    return false;
           
            try
            {
                var manufacture = _unitOFWork.ManufactureRepository.GetByid(model.ManufacturedBy);
                var vehicleCapacity= model.VehicleCapacityId == 0 ? "Ton" : "Person";
                Vehicle vehicle = new Vehicle()
                {
                    VehicleTypeId = model.VehicleCategoryId,
                    ModelId = model.ModelId,
                    ManufactureId = model.ManufacturedBy,
                    color = model.Color,
                    ModelYear = Convert.ToDateTime($"1/1/{model.Modelyear}"),
                    IsStandard = model.VehicleType == 0 ? false : true,
                    VendorId=model.VehicleMode,
                    VehicleCapacity=$"{model.VehicleCapacity} {vehicleCapacity}" ,
                    VehicleMileage=model.VehicleMileage,
                    RegNo = model.RegNo,
                    RegDate = model.RegDate,
                    RegExpiryDate = model.Reg_ExpiryDate,
                    ChassisNo = model.Chassis,
                    EngineNo = model.Engine,
                    TaxTokenFitness = model.fitness_TaxToken,
                    TaxFitnessExpiryDate = model.fitnessExpireDate,
                    ImageUrl = model.PhotoUrl??"",
                    DocumentUrl = model.DocumentUrl ?? "",
                    IsActive = true,
                    CreatedOn = DateTime.Now
                };

                _unitOFWork.VehicleRepository.Add(vehicle);
                _unitOFWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<VehicleType> GetAllVehicleType()
        {
            var vehicleTypeData = _unitOFWork.vehicleTypeRepository.GetAll();

            return (List<VehicleType>)vehicleTypeData;
        }

        public List<object> GetDataTable()
        {
            List<object> vehicleModels = new List<object>();
            var vehiclelist = _unitOFWork.VehicleRepository.GetAll().Where(c=>c.IsActive==true);
            int N = 1;
            foreach (var vehicle in vehiclelist)
            {
                //var manufactureId = _unitOFWork.ManufactureRepository.GetByid(vehicle.ModelId);
                if ((vehicle.ModelId == 0 || vehicle.VehicleTypeId == 0))
                    continue;
                try
                {
                    var TableObject = new
                    {
                        sl = N,
                        //vehicleType = vehicle.VehicleTypeId,
                        vehicleId = vehicle.Id,
                        modelType = _unitOFWork.ModelTypeRepository.GetByid(vehicle.ModelId).Name??null,
                        modelId = vehicle.ModelId,
                        regNo = vehicle.RegNo,
                        regEx = DateOnly.FromDateTime(vehicle.RegExpiryDate),
                        //chassis = vehicle.ChassisNo,
                        capacity=vehicle.VehicleCapacity
                    };
                    vehicleModels.Add(TableObject);
                    N++;
                }
                catch
                {

                }
                
            }

            return vehicleModels;
        }

        public async Task<List<object>> GetDataTableFilterdAsync(DataTableAjaxRequest dataTable)
        {
            //var data= await _unitOFWork.VehicleRepository

            return new List<object> { dataTable };
        }

        public List<VehicleModel> ModelYear()
        {
            var ModelList = _unitOFWork.ManufactureRepository.GetAll();
            //var ModelList = await _unitOFWork.ModelTypeRepository.GetAllEnumerableAsync();
            var modelObject = new List<VehicleModel>();

            foreach (var modellist in ModelList)
            {
                var model = _unitOFWork.ModelTypeRepository.GetByid(modellist.ModelTypeId);

                try
                {
                    var modelOb = new VehicleModel()
                    {
                        ManufacturedBy = modellist.Id,
                        //modelYear = modellist.ModelYear.Year,
                        //ManufactureName = $"{model.Name} {modellist.ModelYear.Year}"
                    };
                    modelObject.Add(modelOb);
                }
                catch { }
            }

            return modelObject;
        }




        public object SearchEdit(long id)
        {
            var Vehicle = _unitOFWork.VehicleRepository.GetByid(id);
            var Manufacture = _unitOFWork.ManufactureRepository.GetByid(Vehicle.ManufactureId);
            var VehicleObject = new


            {
                VehicleId = Vehicle.Id,
                manufactureId = Vehicle.ManufactureId,
                manufactureName = _unitOFWork.ManufactureTypeRepository.GetByid(Manufacture.ManufactureTypeId).Name,
                vahicleModelId = Vehicle.ModelId,
                vahicleModelName = _unitOFWork.ModelTypeRepository.GetByid(Manufacture.ModelTypeId).Name,
                vehicleCategoryId = Vehicle.VehicleTypeId,
                vehicleCategoryName =Enum.GetName(typeof(vehicleCategory),Vehicle.VehicleTypeId),
                modelYear = DateOnly.FromDateTime(Vehicle.ModelYear).Year.ToString(),
                vehicleTypeId = Vehicle.IsStandard==false?0:1,
                vehicleTypeName = Vehicle.IsStandard==false? "Hybrid" : "Standard",
                colorId= Vehicle.color,
                colorName= Enum.GetName(typeof(color),Vehicle.color),
                VehicleMode= Vehicle.VendorId,
                VehicleModeName= Vehicle.VendorId==1? "Own": "Rental",
                vehicleCapacity=Vehicle.VehicleCapacity,
                vehicleMileage= Vehicle.VehicleMileage,
                
                regNo= Vehicle.RegNo,
                regDate= DateOnly.FromDateTime(Vehicle.RegDate),
                regEX= DateOnly.FromDateTime(Vehicle.RegExpiryDate),
                fitnessToken= Vehicle.TaxTokenFitness,
                fitnessExpiry= DateOnly.FromDateTime(Vehicle.TaxFitnessExpiryDate),
                chasiss= Vehicle.ChassisNo.ToString(),
                engine= Vehicle.EngineNo

            };
            return VehicleObject;   


        }

        public bool Edit(VehicleModel model)
        {
            var vehicleObject = _unitOFWork.VehicleRepository.GetByid(model.VehicleId);
            var vehicleCapacity = model.VehicleCapacityId == 0 ? "Ton" : "Person";
            try
            {
                vehicleObject.ManufactureId = model.ManufacturedBy;
                vehicleObject.ModelId = model.ModelId;
                vehicleObject.ModelYear = Convert.ToDateTime($"1/1/{model.Modelyear}");
                //vehicleObject.VehicleTypeId = model;
                vehicleObject.VehicleTypeId = model.VehicleCategoryId;
                vehicleObject.color = model.Color;
                vehicleObject.VendorId = model.VehicleMode;
                vehicleObject.VehicleCapacity = $"{model.VehicleCapacity} {vehicleCapacity}";
                vehicleObject.VehicleMileage = model.VehicleMileage;
                vehicleObject.RegNo = model.RegNo;
                vehicleObject.RegDate = model.RegDate;
                vehicleObject.RegExpiryDate = model.Reg_ExpiryDate;
                vehicleObject.TaxTokenFitness = model.fitness_TaxToken;
                vehicleObject.TaxFitnessExpiryDate = model.fitnessExpireDate;
                vehicleObject.ChassisNo = model.Chassis;
                vehicleObject.EngineNo = model.Engine;
                vehicleObject.DocumentUrl = model.DocumentUrl ?? vehicleObject.DocumentUrl;
                vehicleObject.ImageUrl = model.PhotoUrl ?? vehicleObject.ImageUrl;
                vehicleObject.UpdatedOn= DateTime.Now;
                _unitOFWork.VehicleRepository.Update(vehicleObject);
                _unitOFWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool SoftDelete(long id)
        {
            try
            {
                var vehicle = _unitOFWork.VehicleRepository.GetByid(id);

                vehicle.IsActive = false;
                _unitOFWork.VehicleRepository.Update(vehicle);
                _unitOFWork.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
          


        }
        public async Task<string> UplodeImage(string FileName, IFormFile file)
        {
            
            var vehicleLastid = _unitOFWork.VehicleRepository.LastObjectId();
            string FIlePath =
                $"ProjectFiles/Images/ImageID{vehicleLastid+ 1}_"
                /*  $"{DateTime.Now.ToString("MM/dd/yyyy HH:mm")}_" */+ FileName;
            return UplodeContent(FIlePath, file);
        }

        public string UplodeDocument(string FileName, IFormFile file)
        {
            var lastVehicleId = _unitOFWork.VehicleRepository.LastObjectId();
            
            string FIlePath =
                $"ProjectFiles/Document/DocumentID{lastVehicleId+1}_"
                /* $"{DateTime.Now.ToString("MMddyyyy HH:mm")}_"*/+ FileName;
            return UplodeContent(FIlePath, file);
        }

        public string UplodeContent(string FIlePath, IFormFile file)
        {
            string ProjectPath = _Environment.WebRootPath;

            string FullPath = Path.Combine(ProjectPath, FIlePath);
            using (FileStream stream = new FileStream(FullPath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }

            return FullPath;
        }
    }
}
