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
    public class RoadExpenseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IHostingEnvironment _environment;
        public RoadExpenseService() { }

        public RoadExpenseService(IUnitOfWork unitOfWork, IHostingEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        // Create new road expense
        public bool Create(RoadExpenseModel model)
        {
            try
            {
                var roadExpense = new RoadExpense()
                {
                    DonationType = model.DonationType,
                    DonationAmount = model.DonationAmount,
                    DonationDate = model.DonationDate,
                    Location = model.Location,
                    Comments = model.Comments,
                    IsActive = true
                };

                _unitOfWork.RoadExpenseRepository.Add(roadExpense);
                _unitOfWork.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Get all road expense list
        public List<RoadExpenseModel> Read()
        {
            var roadExpenseList = _unitOfWork.RoadExpenseRepository.GetAll().Where(x => x.IsActive == true);
            var viewData = new List<RoadExpenseModel>();

            foreach (var roadExpense in roadExpenseList)
            {
                var insertData = new RoadExpenseModel()
                {
                    Id = roadExpense.Id,
                    DonationType = roadExpense.DonationType,
                    DonationAmount = roadExpense.DonationAmount,
                    DonationDate = roadExpense.DonationDate,
                    Location = roadExpense.Location,
                    Comments = roadExpense.Comments
                };
                viewData.Add(insertData);
            }

            return viewData;
        }

        // Update single data 
        public bool Update(RoadExpenseModel model)
        {
            var roadExpense = _unitOfWork.RoadExpenseRepository.GetByid(model.Id);
            try
            {
                if (roadExpense != null)
                {
                    roadExpense.DonationType = model.DonationType;
                    roadExpense.DonationAmount = model.DonationAmount;
                    roadExpense.DonationDate = model.DonationDate;
                    roadExpense.Location = model.Location;
                    roadExpense.Comments = model.Comments;

                    _unitOfWork.RoadExpenseRepository.Update(roadExpense);
                    _unitOfWork.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Delete single data (Soft Delete)
        public bool Delete(long id)
        {
            var roadExpense = _unitOfWork.RoadExpenseRepository.GetByid(id);
            try
            {
                if (roadExpense != null)
                {
                    roadExpense.IsActive = false;

                    _unitOfWork.RoadExpenseRepository.Update(roadExpense);
                    _unitOfWork.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Get sigle data for edit
        public  RoadExpenseModel Edit(long id)
        {
            var getData = _unitOfWork.RoadExpenseRepository.GetByid(id);
            var insertData = new RoadExpenseModel()
            {
                Id = getData.Id,
                DonationType = getData.DonationType,
                DonationAmount = getData.DonationAmount,
                Location = getData.Location,
                Comments = getData.Comments
            };
            return insertData;
        }
    }
}
