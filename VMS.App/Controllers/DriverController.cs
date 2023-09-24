using Autofac;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using VMS.Infrastructure.Model;
using VMS.Infrastructure.Service;

namespace VMS.App.Controllers
{
    public class DriverController : Controller
    {
        public IHostingEnvironment Environment;
        public DriverService _driverService { get; set; }
        public ILifetimeScope Scope { get; set; }

        public DriverController(ILifetimeScope lifeScope, DriverService driverService, IHostingEnvironment environment)
        {
            Scope = lifeScope;
            Environment = environment;
            _driverService = driverService;
        }

        public IActionResult Index()
        {
            var data = new DriverModel()
            {
                Drivers = _driverService.GetAllData()
            };

            return View(data);
        }

        [HttpPost]
        public IActionResult Create(DriverModel model)
        {
            model.DriverPhotoUrl = _driverService.UploadImage(model.DriverPhoto.FileName, model.DriverPhoto);
            model.LicenceDocumentUrl = _driverService.UploadLicense(model.LicenceDocument.FileName, model.LicenceDocument);
            model.NIDDocumentUrl = _driverService.UploadNid(model.NIDDocument.FileName, model.NIDDocument);
            _driverService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var driver = _driverService.GetDriver(id);
            return View(driver);
        }

        [HttpPost]
        public IActionResult Update(DriverModel model)
        {
            bool isUpdate = _driverService.UpdateDriver(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(DriverModel model)
        {
            bool isDelete = _driverService.DeleteDriver(model.DId);
            return RedirectToAction("Index");
        }
    }
}

