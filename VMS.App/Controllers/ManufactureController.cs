using Autofac;
using Microsoft.AspNetCore.Mvc;
using VMS.Infrastructure.Model;
using VMS.Infrastructure.Service;

namespace VMS.App.Controllers
{
    public class ManufactureController : Controller
    {
        public ManufactureService _manufactureService { get; set; }
        public VehicleService _vehicleService { get; set; }
        public ILifetimeScope scope { get; set; }

        public ManufactureController(
            ManufactureService manufactureService,
            VehicleService vehicleService,
            ILifetimeScope Scope
        )
        {
            _manufactureService = manufactureService;
            _vehicleService = vehicleService;
            scope = Scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateAsync(ManufactureModel model)
        {
            if (!ModelState.IsValid)
            {
                _manufactureService = scope.Resolve<ManufactureService>();

                var isCreate = await _manufactureService.CreateAsync(model);
            }

            return RedirectToAction("Index");
        }

        public JsonResult GetManufacture()
        {
            var manufacture = _manufactureService.GetManufacture();

            return Json(manufacture);
        }

        public JsonResult GetManufactureType(int id)
        {
            var data = _manufactureService.GetAllManufactureTypes(id);
            return Json(data);
        }

        public JsonResult GetManufactureData()
        {
            var data = _manufactureService.GetManufactureData();
            return Json(data);
        }

        [HttpGet]
        public JsonResult Edit(long id)
        {
            var modelData = _manufactureService.GetByManufacture(id);
            return Json(modelData);
        }

        [HttpPost]
        public IActionResult Edit(ManufactureModel model)
        {
            _manufactureService.EditManufacture(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            _manufactureService.SoftDelete(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetModel(long id)
        {
            var manufacture = _manufactureService.GetModel(id);

            return Json(manufacture);
        }
        public JsonResult GetSingleModel(long id)
        {
            var manufacture = _manufactureService.SingleModel(id);

            return Json(manufacture);
        }

        //public IActionResult GetDisableField(long id)

        //{
        //    var _manufactureService = scope.Resolve<ManufactureService>();
        //    var data = _manufactureService.GetDisableField(id);


        //    return Json(data);
        //}
    }
}
