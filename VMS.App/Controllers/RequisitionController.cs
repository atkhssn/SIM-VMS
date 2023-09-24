using Autofac;
using Microsoft.AspNetCore.Mvc;
using VMS.Infrastructure.Model;
using VMS.Infrastructure.Service;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace VMS.App.Controllers
{
    public class RequisitionController : Controller
    {
        [Obsolete]
        protected readonly IHostingEnvironment? _environment;
        protected readonly ILifetimeScope? _scope;
        protected RequsitionService? _service { get; set; }

        [Obsolete]
        public RequisitionController(IHostingEnvironment? environment, ILifetimeScope? scope, RequsitionService? service)
        {
            _environment = environment;
            _scope = scope;
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var requisitionList = new RequisitionModel()
            {
                RequisitionModels = _service?.Read()
            };
            return View(requisitionList);
        }

        [HttpPost]
        public IActionResult Add(RequisitionModel requisitionModel)
        {
            _service?.Create(requisitionModel);
            return RedirectToAction("Index");
        }
    }
}
