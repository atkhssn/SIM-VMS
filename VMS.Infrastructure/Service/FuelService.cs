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
    public class FuelService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IHostingEnvironment _environment;
        public FuelService() { }

        public FuelService(IUnitOfWork unitOfWork, IHostingEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public bool Create(FuelModel model)
        {
            try
            {
                var fuel = new Fuel()
                {
                    InitialFuel = model.InitialFuel,
                    loadedFuel = model.loadedFuel,
                    FuelCost = model.FuelCost,
                    Date = model.Date,
                    FuelStation = model.FuelStation,
                    StationLocation = model.StationLocation,
                    Comments = model.Comments,
                    VoucherUrl = "iii",
                    IsActive = true
                };

                _unitOfWork.FuelRepository.Add(fuel);
                _unitOfWork.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<FuelModel> Read()
        {
            var fuelList = _unitOfWork.FuelRepository.GetAll().Where(x => x.IsActive == true);
            var viewData = new List<FuelModel>();

            foreach (var fuel in fuelList)
            {
                var insertData = new FuelModel()
                {
                    Id = fuel.Id,
                    InitialFuel = fuel.InitialFuel,
                    loadedFuel = fuel.loadedFuel,
                    FuelCost = fuel.FuelCost,
                    Date = fuel.Date,
                    FuelStation = fuel.StationLocation,
                    StationLocation = fuel.StationLocation,
                    Comments = fuel.Comments
                };
                viewData.Add(insertData);
            };
            return viewData;
        }

        public bool Update(FuelModel model)
        {
            try
            {
                var getData = _unitOfWork.FuelRepository.GetByid(model.Id);
                if(getData != null)
                {
                    getData.InitialFuel = model.InitialFuel;
                    getData.loadedFuel = model.loadedFuel;
                    getData.FuelCost = model.FuelCost;
                    getData.Date = model.Date;
                    getData.FuelStation = model.FuelStation;
                    getData.StationLocation = model.StationLocation;
                    getData.Comments = model.Comments;

                    _unitOfWork.FuelRepository.Update(getData);
                    _unitOfWork.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var getData = _unitOfWork.FuelRepository.GetByid(id);
                if(getData != null)
                {
                    getData.IsActive = false;

                    _unitOfWork.FuelRepository.Update(getData);
                    _unitOfWork.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public FuelModel Edit(long id)
        {
            var getData = _unitOfWork.FuelRepository.GetByid(id);
            var insertData = new FuelModel()
            {
                Id = getData.Id,
                InitialFuel = getData.InitialFuel,
                loadedFuel = getData.loadedFuel,
                FuelCost = getData.FuelCost,
                Date = getData.Date,
                FuelStation = getData.FuelStation,
                StationLocation = getData.StationLocation,
                Comments = getData.Comments
            };

            return insertData;
        }

    }
}
