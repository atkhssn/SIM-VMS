using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.Domain.Entity;
using VMS.Infrastructure.Model;
using VMS.Persistence.UnitOfWork;

namespace VMS.Infrastructure.Service
{
    public class RequsitionService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IHostingEnvironment _environment;
        public RequsitionService() { }

        public RequsitionService(IUnitOfWork unitOfWork, IHostingEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public bool Create(RequisitionModel model)
        {
            try
            {
                var requisition = new Requisition()
                {
                    MerchantId = 56465, // Assign from database
                    VehicleId = 9879, // Assign from database
                    DriverId = 3132, // Assign from database
                    VehicleType = model.VehicleType,
                    VehicleQuantity = model.VehicleQuantity,
                    TripStartDate = model.TripStartDate,
                    TripEndDate = model.TripEndDate,
                    StartLocation = model.StartLocation,
                    EndLocation = model.EndLocation,
                    Comments = model.Comments,
                    IsTripCompleted = "Booked",
                    IsActive = true
                };

                _unitOfWork.RequisitionRepository.Add(requisition);
                _unitOfWork.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<RequisitionModel> Read()
        {
            var requisitionList = _unitOfWork.RequisitionRepository.GetAll().Where(x => x.IsActive = true);
            var viewData = new List<RequisitionModel>();

            foreach (var requisition in requisitionList)
            {
                var iserData = new RequisitionModel()
                {
                    Id = requisition.Id,
                    MerchantId = requisition.MerchantId,
                    VehicleId = requisition.VehicleId,
                    DriverId = requisition.DriverId,
                    VehicleType = requisition.VehicleType,
                    VehicleQuantity = requisition.VehicleQuantity,
                    TripStartDate = requisition.TripStartDate,
                    TripEndDate = requisition.TripEndDate,
                    StartLocation = requisition.StartLocation,
                    EndLocation = requisition.EndLocation,
                    Comments = requisition.Comments,
                    IsTripCompleted = requisition.IsTripCompleted,
                };
                viewData.Add(iserData);
            }

            return viewData;
        }
    }
}
