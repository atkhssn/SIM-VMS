using VMS.Domain.Entity;
using VMS.Infrastructure.Model;
using VMS.Persistence;
using VMS.Infrastructure.Utility;
using VMS.Persistence.UnitOfWork;

namespace VMS.Infrastructure.Service
{
    public class MaintenanceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaintenanceService() { }

        public MaintenanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Create(string PartsName, decimal PartsPrice, string Description,
                 int status, decimal serviceBill, string serviceDate, long TripId,
                 long vehicleId, List<MaintenanceModel> RowDataArray)
        {


            try
            {


                var maintaince = new Maintenance()
                {
                    VehicleId = vehicleId,
                    TripId = TripId,
                    ServiceDate = Convert.ToDateTime(serviceDate),
                    Status = status,
                    Description = Description ?? "",
                    CreatedOn = DateTime.Now
                };

                _unitOfWork.MaintenanceRepository.Add(maintaince);
                _unitOfWork.SaveChanges();

                var maintainceId = _unitOfWork.MaintenanceRepository.LastId();

                try
                {
                    bool isPartsCreate = CreateParts(maintainceId, PartsName, PartsPrice, RowDataArray);
                    return isPartsCreate;
                }
                catch
                {
                    return false;
                }
            }
            catch
            {

            }





            return false;
        }
        public bool CreateParts(long maintainceId, string PartsName,
                                            decimal PartsPrice, List<MaintenanceModel> RowDataArray)
        {

            if (maintainceId < 1 | maintainceId == null)
            {
                return false;
            }

            var partsList = new List<MaintenanceParts>();

            if (PartsName != null && PartsPrice > 0)
            {
                var parts = new MaintenanceParts()
                {
                    MaintainanceId = maintainceId,
                    PartsName = PartsName,
                    PartsPrice = Convert.ToDecimal(PartsPrice),
                    CreatedOn = DateTime.Now
                };
                partsList.Add(parts);
            }


            if (RowDataArray != null | RowDataArray.Count > 0)
            {



                foreach (var parts in RowDataArray)
                {
                    if (Convert.ToDecimal(parts.Price) < 1 | parts.Name is null)
                    {
                        continue;
                    }
                    var partObject = new MaintenanceParts()
                    {
                        PartsName = parts.Name,
                        PartsPrice = Convert.ToDecimal(parts.Price),
                        MaintainanceId = maintainceId,
                        CreatedOn = DateTime.Now

                    };
                    partsList.Add(partObject);
                }

                try
                {
                    _unitOfWork.MaintenancePartsRepository.AddRangeAsync(partsList);
                    _unitOfWork.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }


        public List<Maintenance> GetAllData()
        {
            var maintenanceData = _unitOfWork.MaintenanceRepository.GetAll();
            return (List<Maintenance>)maintenanceData;
        }

        public object GetAllMaintenanceTypes(int id)
        {
            throw new NotImplementedException();
        }

        public List<MaintenanceModel> GetDataTable()
        {
            List<MaintenanceModel> MaintenanceModels = new List<MaintenanceModel>();
            var maintenlist = GetAllData();
            foreach (var maintain in maintenlist)
            {
                MaintenanceModel model = new MaintenanceModel();
                //var maintenance = _unitOfWork.MaintenanceRepository.GetByid(maintain.VId);
                //model.VehicleId = _unitOfWork.MaintenanceRepository.GetByid(maintain.Id).Id;
                model.ServiceDate = maintain.ServiceDate;
                model.Description = maintain.Description;
                //model.PartsName = maintain.PartsName;
                //model.PartsPrice = maintain.PartsPrice;
                //model.WorkshopBill = maintain.WorkshopBill;
                //model.Status = maintain.Status;
                //MaintenanceModels.Add(model);
            }

            return MaintenanceModels;
        }

        public async Task<List<object>> GetDataTableFilterdAsync(DataTableAjaxRequest dataTable)
        {
            //var data= await _unitOFWork.VehicleRepository

            return new List<object> { dataTable };
        }

        public object GetDisableField(long id)
        {
            throw new NotImplementedException();
        }


    }
}
