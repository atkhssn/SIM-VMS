using Microsoft.AspNetCore.Mvc;
using VMS.Infrastructure.Model;
using VMS.Infrastructure.Service;

namespace VMS.App.Controllers
{
    public class TransportAgencyController : Controller
    {
        public readonly TransportAgencyService agencyService;

        public TransportAgencyController(TransportAgencyService agencyService)
        {
            this.agencyService = agencyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TransportAgencyModel transportAgency)
        {
            bool isCreate = agencyService.Create(transportAgency);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(TransportAgencyModel transportAgency)
        {
            bool isCreate = agencyService.EditAsync(transportAgency).Result;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(long transportAgencyId)
        {
            bool isCreate = agencyService.SoftDeleteAsync(transportAgencyId).Result;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult Get(long id)
        {
            var model = agencyService.GetById(id).Result;
            return Json(model);
        }

        public JsonResult GetAllTableData()
        {
            var agencyList = agencyService.GetAllDataTable();
            return Json(agencyList);
        }

        public JsonResult GetAllAgency()
        {
            var agencyList = agencyService.GetAllAgency();
            return Json(agencyList);
        }
    }
}
