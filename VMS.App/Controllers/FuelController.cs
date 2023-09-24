using Autofac;
using Microsoft.AspNetCore.Mvc;
using VMS.Infrastructure.Model;
using VMS.Infrastructure.Service;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace VMS.App.Controllers
{
    public class FuelController : Controller
    {
        [Obsolete]
        protected readonly IHostingEnvironment? _environment;
        protected readonly ILifetimeScope? _scope;
        protected FuelService? _service { get; set; }

        [Obsolete]
        public FuelController(IHostingEnvironment? environment, ILifetimeScope? scope, FuelService? service)
        {
            _environment = environment;
            _scope = scope;
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var fuelList = new FuelModel()
            {
                Fuels = _service?.Read()
            };

            return View(fuelList);
        }

        [HttpPost]
        public IActionResult Add(FuelModel fuelModel)
        {
            _service?.Create(fuelModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var data = _service?.Edit(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(FuelModel fuelModel)
        {
            _service?.Update(fuelModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(FuelModel fuelModel)
        {
            _service?.Delete(fuelModel.Id);
            return RedirectToAction("Index");
        }
    }
}
