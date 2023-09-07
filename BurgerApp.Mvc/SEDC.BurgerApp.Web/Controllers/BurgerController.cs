using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.BLL.DTOs.Burgers;
using SEDC.BurgerApp.BLL.Services;
using SEDC.BurgerApp.BLL.Services.Implementation;

namespace SEDC.BurgerApp.Web.Controllers
{
    public class BurgerController : Controller
    {
        private readonly IBurgerService burgerService;
        private readonly ILogger<LocationController> logger;

        public BurgerController(IBurgerService burgerService, ILogger<LocationController> logger)
        {
            this.burgerService = burgerService;
            this.logger = logger;
        }

        // GET: BurgerController
        public ActionResult Index()
        {
            var DTOs = burgerService.GetAll();
            return View(DTOs);
        }

        // GET: BurgerController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("ViewNotFound");
            }
            try
            {
                var burger = burgerService.GetById(id.Value);
                return View(burger);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }
        }

        // GET: BurgerController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: BurgerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBurgerDTO burger)
        {
            burgerService.Create(burger);
            return RedirectToAction("Index");
        }

        // GET: BurgerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return View("ViewNotFound");
            }
            try
            {
                var burger = burgerService.GetById(id);
                return View(burger);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");

            }
        }

        // POST: BurgerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BurgerDTO model)
        {
            try
            {
                var burger = burgerService.Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }
        }

     

        // POST: BurgerController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            burgerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
