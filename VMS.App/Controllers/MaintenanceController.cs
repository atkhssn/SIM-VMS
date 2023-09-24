using Autofac;
using Microsoft.AspNetCore.Mvc;
using VMS.Infrastructure.Model;
using VMS.Infrastructure.Service;
using VMS.Infrastructure.Utility;

namespace VMS.App.Controllers
{
    public class MaintenanceController : Controller
    {
        public MaintenanceService _maintenanceService;

        public ILifetimeScope scope { get; set; }

        public MaintenanceController(MaintenanceService maintenanceService, ILifetimeScope scope)
        {
            _maintenanceService = maintenanceService;
            this.scope = scope;
        }

        public IActionResult Index()
        {
            MaintenanceModel maintenance = new MaintenanceModel();
            return View();
        }

        [HttpPost]
        public IActionResult Create(string PartsName, decimal PartsPrice, string Description,
                                  int Status, decimal serviceBill, string serviceDate, long TripId,
                                     long vehicleId, List<MaintenanceModel> RowDataArray)

        {
            _maintenanceService = scope.Resolve<MaintenanceService>();
            var isCreate = _maintenanceService.Create(
                PartsName, PartsPrice, Description, Status,
                serviceBill, serviceDate, TripId, vehicleId, RowDataArray);

            return RedirectToAction(nameof(Index));


        }

        public IActionResult Edit()
        {
            MaintenanceModel maintenance = new MaintenanceModel();
            return View();
        }

        public IActionResult GetAll()
        {
            var maintaenServ2 = new DataTableAjaxRequest(Request);
            var data = _maintenanceService.GetDataTable();

            return Json(data);
        }

        public JsonResult GetMaintenanceType(int id)
        {
            var data = _maintenanceService.GetAllMaintenanceTypes(id);
            return Json(data);
        }

        public IActionResult GetDisableField(long id)
        {
            var _maintenanceService = scope.Resolve<MaintenanceService>();
            var data = _maintenanceService.GetDisableField(id);

            return Json(data);
        }

        public JsonResult GetById()
        {
            return Json(null);
        }
    }
}
