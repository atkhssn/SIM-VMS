using VMS.Infrastructure.Model;
using VMS.Persistence;
using VMS.Domain.Entity;
using VMS.Persistence.UnitOfWork;

namespace VMS.Infrastructure.Service
{
    public class MerchantService
    {
        public readonly IUnitOfWork unitOfWork;
        public MerchantService() { }
        public MerchantService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<MerchantModel> Get()
        {
            var merchantList = unitOfWork.MerchantRepository.GetAll().Where(c=>c.IsActive==true);
            var viewModel = new List<MerchantModel>();

            foreach (var merchant in merchantList)
            {
                var data = new MerchantModel()
                {
                    Id = merchant.Id,
                    MerchantName = merchant.MerchantName,
                    DepartmentName = merchant.DepartmentName,
                    ResponsiblePerson = merchant.ResponsiblePerson,
                    MerchantEmail = merchant.MerchantEmail,
                    MerchantPhone = merchant.MerchantPhone
                };
                viewModel.Add(data);
            }
            return viewModel;
        }
        public bool Add(MerchantModel model)
        {
            var addMerchant = new Merchant()
            {
                MerchantName = model.MerchantName,
                DepartmentName = model.DepartmentName,
                ResponsiblePerson = model.ResponsiblePerson,
                MerchantPhone = model.MerchantPhone,
                MerchantEmail = model.MerchantEmail,
                IsActive = true
            };

            try
            {
                unitOfWork.MerchantRepository.Add(addMerchant);
                unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public MerchantModel GetMerchant(long id)
        {
            var merchant = unitOfWork.MerchantRepository.GetByid(id);
            var merchantModel = new MerchantModel()
            {
                Id = merchant.Id,
                MerchantName = merchant.MerchantName,
                DepartmentName = merchant.DepartmentName,
                ResponsiblePerson = merchant.ResponsiblePerson,
                MerchantPhone = merchant.MerchantPhone,
                MerchantEmail = merchant.MerchantEmail
            };
            return merchantModel;
        }
        public bool UpdateMerchant(MerchantModel modelRequest)
        {
            var merchant = unitOfWork.MerchantRepository.GetByid(modelRequest.Id);

            try
            {
                if (merchant != null)
                {
                    merchant.MerchantName = modelRequest.MerchantName;
                    merchant.DepartmentName = modelRequest.DepartmentName;
                    merchant.ResponsiblePerson = modelRequest.ResponsiblePerson;
                    merchant.MerchantPhone = modelRequest.MerchantPhone;
                    merchant.MerchantEmail = modelRequest.MerchantEmail;
                    unitOfWork.MerchantRepository.Update(merchant);
                    unitOfWork.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteMerchant(MerchantModel modelRequest)
        {
            var merchant = unitOfWork.MerchantRepository.GetByid(modelRequest.Id);

            try
            {
                if (merchant != null)
                {
                    merchant.IsActive = false;
                    unitOfWork.MerchantRepository.Update(merchant);
                    unitOfWork.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
