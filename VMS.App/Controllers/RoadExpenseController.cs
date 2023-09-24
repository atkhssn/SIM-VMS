using Autofac;
using Microsoft.AspNetCore.Mvc;
using VMS.Infrastructure.Model;
using VMS.Infrastructure.Service;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace VMS.App.Controllers
{
    public class RoadExpenseController : Controller
    {
        [Obsolete]
        protected readonly IHostingEnvironment? _environment;
        protected readonly ILifetimeScope? _scope;
        protected RoadExpenseService? _service { get; set; }

        [Obsolete]
        public RoadExpenseController(IHostingEnvironment? environment, ILifetimeScope? scope, RoadExpenseService? service)
        {
            _environment = environment;
            _scope = scope;
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roadExpenseList = new RoadExpenseModel()
            {
                RoadExpenseModels = _service?.Read()
            };

            return View(roadExpenseList);
        }

        [HttpPost]
        public IActionResult Add(RoadExpenseModel roadExpenseModel)
        {
            _service?.Create(roadExpenseModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var roadExpense = _service?.Edit(id);
            return View(roadExpense);
        }

        [HttpPost]
        public IActionResult Update(RoadExpenseModel roadExpenseModel)
        {
            _service?.Update(roadExpenseModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(RoadExpenseModel roadExpenseModel)
        {
            _service?.Delete(roadExpenseModel.Id);
            return RedirectToAction("Index");
        }
    }
}
