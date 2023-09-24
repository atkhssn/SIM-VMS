using VMS.Domain.Entity;
using VMS.Infrastructure.Model;
using VMS.Persistence;
using VMS.Persistence.UnitOfWork;

namespace VMS.Infrastructure.Service
{
    public class TransportAgencyService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public TransportAgencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Create(TransportAgencyModel model)
        {
            var IsDuplicate = _unitOfWork.TransportAgencyRepository
                .IsDuplicateAsync(model.Name)
                .Result;
            if (IsDuplicate)
            {
                return false;
            }

            try
            {
                TransportAgency transportAgency = new TransportAgency()
                {
                    Name = model.Name,
                    Owner = model.Owner,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                };
                _unitOfWork.TransportAgencyRepository.Add(transportAgency);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<object> GetById(long TransportAgencyId)
        {
            try
            {
                var Agency = await _unitOfWork.TransportAgencyRepository.GetByidAsync(
                    TransportAgencyId
                );

                return Agency;
            }
            catch
            {
                return null;
            }
        }

        public List<object> GetAllDataTable()
        {
            var AgencyList = new List<object>();

            var AgencyDatabaseList = _unitOfWork.TransportAgencyRepository.GetActiveList();
            var Sl = 1;
            foreach (var Agency in AgencyDatabaseList)
            {
                var agency = new
                {
                    sl = Sl,
                    Id = Agency.Id,
                    Name = Agency.Name,
                    Owner = Agency.Owner,
                    PhoneNumber = Agency.PhoneNumber,
                    Address = Agency.Address,
                };

                AgencyList.Add(agency);

                Sl++;
            }
            return AgencyList;
        }
        public List<object> GetAllAgency()
        {
            var AgencyList = new List<object>();

            var AgencyDatabaseList = _unitOfWork.TransportAgencyRepository.GetActiveList();
          
            foreach (var Agency in AgencyDatabaseList)
            {
                var agency = new
                {

                    manufactureId = Agency.Id,
                    manufactureName = Agency.Name,
                   
                };

                AgencyList.Add(agency);

                
            }
            return AgencyList;
        }

        public async Task<bool> EditAsync(TransportAgencyModel transportAgency)
        {
            try
            {
                var model = await _unitOfWork.TransportAgencyRepository.GetByidAsync(
                    transportAgency.Id
                );

                model.Name = transportAgency.Name;
                model.Owner = transportAgency.Owner;
                model.PhoneNumber = transportAgency.PhoneNumber;
                model.Address = transportAgency.Address;
                model.UpdatedOn = DateTime.Now;

                _unitOfWork.TransportAgencyRepository.Update(model);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="TransportAgency"></param>
        /// <returns></returns>
        public async Task<bool> SoftDeleteAsync(long TransportAgency)
        {
            try
            {
                var model = await _unitOfWork.TransportAgencyRepository.GetByidAsync(
                    TransportAgency
                );

                model.IsActive = false;
                _unitOfWork.TransportAgencyRepository.Update(model);
                _unitOfWork.SaveChanges();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
