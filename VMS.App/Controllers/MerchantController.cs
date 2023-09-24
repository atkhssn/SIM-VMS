using Autofac;
using Microsoft.AspNetCore.Mvc;
using VMS.Infrastructure.Model;
using VMS.Infrastructure.Service;

namespace VMS.App.Controllers
{
    public class MerchantController : Controller
    {
        public readonly MerchantService merchantService;
        public ILifetimeScope scope { get; set; }

        public MerchantController(MerchantService merchantService, ILifetimeScope lifetimeScope)
        {
            this.merchantService = merchantService;
            this.scope = lifetimeScope;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = new MerchantModel()
            {
                MerchantList = merchantService.Get()
            };
            return View(data);
        }

        [HttpPost]
        public IActionResult Add(MerchantModel modelRequest)
        {
            bool isCreate = merchantService.Add(modelRequest);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
             var model = merchantService.GetMerchant(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(MerchantModel modelRequest)
        {
            bool isUpdate = merchantService.UpdateMerchant(modelRequest);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(MerchantModel modelRequest)
        {
            bool isDelete = merchantService.DeleteMerchant(modelRequest);
            return RedirectToAction("Index");
        }
    }
}
