using VMS.Infrastructure.Model;
using VMS.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using VMS.Domain.Entity;
using VMS.Persistence.UnitOfWork;

namespace VMS.Infrastructure.Service
{
    public class DriverService
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IHostingEnvironment _environment;
        public DriverService() { }

        public DriverService(IUnitOfWork unitOfWork, IHostingEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            _environment = environment;
        }

        public bool Create(DriverModel model)
        {
            try
            {
                var driver = new Driver()
                {
                    DName = model.DName,
                    LicenceNo = model.LicenceNo,
                    LicenceValidation = model.LicenceValidation,
                    NIDNumber = model.NIDNumber,
                    DriverShift = model.DriverShift,
                    DriverType = model.DriverType,
                    DriverPhotoUrl = model.DriverPhotoUrl,
                    LicenceDocumentUrl = model.LicenceDocumentUrl,
                    NIDDocumentUrl = model.NIDDocumentUrl,
                    IsAvailable = true,
                    IsActive = true
                };

                unitOfWork.DriverRepository.Add(driver);
                unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<DriverModel> GetAllData()
        {
            var driverList = unitOfWork.DriverRepository.GetAll().Where(x => x.IsActive == true);
            var viewModel = new List<DriverModel>();

            foreach (var driver in driverList)
            {
                var data = new DriverModel()
                {
                    DId = driver.DId,
                    DName = driver.DName,
                    LicenceNo = driver.LicenceNo,
                    LicenceValidation = driver.LicenceValidation,
                    NIDNumber = driver.NIDNumber,
                    DriverShift = driver.DriverShift,
                    DriverType = driver.DriverType,
                    IsAvailable = driver.IsAvailable,

                };
                viewModel.Add(data);
            }

            return viewModel;
        }

        public DriverModel GetDriver(long id)
        {
            var driver = unitOfWork.DriverRepository.GetByid(id);
            var driverData = new DriverModel()
            {
                DId = driver.DId,
                DName = driver.DName,
                LicenceNo = driver.LicenceNo,
                LicenceValidation = driver.LicenceValidation,
                NIDNumber = driver.NIDNumber,
                DriverShift = driver.DriverShift,
                DriverType = driver.DriverType,
                IsAvailable = driver.IsAvailable,
            };
            return driverData;
        }

        public bool UpdateDriver(DriverModel model)
        {
            var driver = unitOfWork.DriverRepository.GetByid(model.DId);

            if (driver != null)
            {
                driver.DName = model.DName;
                driver.LicenceNo = model.LicenceNo;
                driver.LicenceValidation = model.LicenceValidation;
                driver.NIDNumber = model.NIDNumber;
                driver.DriverShift = model.DriverShift;
                driver.DriverType = model.DriverType;

                unitOfWork.DriverRepository.Update(driver);
                unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteDriver(long id)
        {
            var driver = unitOfWork.DriverRepository.GetByid(id);

            if (driver != null)
            {
                driver.IsActive = false;
                unitOfWork.DriverRepository.Update(driver);
                unitOfWork.SaveChanges();

                return true;
            }
            return false;
        }

        // Upload methods
        public string UploadImage(string fileName, IFormFile formFile) // Image file path
        {
            Random random = new Random();
            string filePath = $"ProjectFiles/Drivers/" + random.Next(00000, 99999) + "_Photo_" + fileName;
            return UploadContent(filePath, formFile);
        }

        public string UploadLicense(string fileName, IFormFile formFile) // License file path
        {
            Random random = new Random();
            string filePath = $"ProjectFiles/Drivers/" + random.Next(00000, 99999) + "_Driving_License_" + fileName;
            return UploadContent(filePath, formFile);
        }

        public string UploadNid(string fileName, IFormFile formFile) // Nid file path
        {
            Random random = new Random();
            string filePath = $"ProjectFiles/Drivers/" + random.Next(00000, 99999) + "_NID_" + fileName;
            return UploadContent(filePath, formFile);
        }

        public string UploadContent(string filePath, IFormFile formFile) // Copy local machine to server machine
        {
            string folderPath = _environment.WebRootPath;
            string fullPath = Path.Combine(folderPath, filePath);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            return fullPath;
        }
    }
}
