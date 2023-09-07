using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.BLL.DTOs.Locations;
using SEDC.BurgerApp.BLL.Services;

namespace SEDC.BurgerApp.Web.Controllers
{
    public class LocationController : Controller
    {

        private readonly ILocationService locationService;
        private readonly ILogger<LocationController> logger;

        public LocationController(ILocationService locationService, ILogger<LocationController> logger)
        {
            this.locationService = locationService;
            this.logger = logger;
        }


        // GET: LocationController
        public ActionResult Index()
        {
            var DTOs = locationService.GetAll();
            return View(DTOs);
        }


        // GET: LocationController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("ViewNotFound");
            }
            try
            {
                var location = locationService.GetById(id.Value);
                return View(location);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }
        }

        // GET: LocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLocationDTO createLocation)
        {
            locationService.Create(createLocation);
            return RedirectToAction("Index");
        }

        

        // GET: LocationController/Edit/5
        public ActionResult Edit(int id)
        {

            if (id == null)
            {
                return View("ViewNotFound");
            }
            try
            {
                var location = locationService.GetById(id);
                return View(location);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");

            }
        }

        // POST: LocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocationDTO model)
        {
            try
            {
                var order = locationService.Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }
        }



        // POST: LocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            locationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
