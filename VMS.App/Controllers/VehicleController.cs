using Autofac;
using Microsoft.AspNetCore.Mvc;
using VMS.Infrastructure.Model;
using VMS.Infrastructure.Service;
using VMS.Infrastructure.Utility;

namespace VMS.App.Controllers
{
    public class VehicleController : Controller
    {
        protected readonly VehicleService _vehicleService;
        public ILifetimeScope Scope { get; set; }

        public VehicleController(ILifetimeScope lifeScope, VehicleService vehicleService)
        {
            Scope = lifeScope;
            _vehicleService = vehicleService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleModel model)
        {

            model.PhotoUrl = _vehicleService.UplodeImage(model.Photo.FileName, model.Photo).Result;
            model.DocumentUrl = _vehicleService.UplodeDocument(
                model.Document.FileName,
                model.Document
            );

            _vehicleService.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Edit(VehicleModel model)
        {
            bool isEdit = _vehicleService.Edit(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetSingleObject(long id)
        {
            var vehicleObject = _vehicleService.SearchEdit(id);
            return Json(vehicleObject);
        }

        [HttpGet]
        public JsonResult SoftDelete(long id)
        {
            var vehicleObject = _vehicleService.SoftDelete(id);
            return Json(vehicleObject);
        }

        public IActionResult GetAll()
        {
            var vehicleService2 = new DataTableAjaxRequest(Request);
            var data = _vehicleService.GetDataTable();

            return Json(data);
        }

        public IActionResult GetModelYear()
        {
            var vehicleService = Scope.Resolve<VehicleService>();
            var data = vehicleService.ModelYear();

            return Json(data);
        }

        public JsonResult GetById()
        {
            return Json(null);
        }

        public JsonResult GetVehicleType()
        {
            var vehicleList = _vehicleService.GetAllVehicleType();
            return Json(vehicleList);
        }

        public JsonResult GetAllTableData()
        {
            //var vehicleService2 = new DataTableAjaxRequest(Request);
            var data = _vehicleService.GetDataTable();

            var jsonResult = Json(data);
            return jsonResult;
        }
    }
}
