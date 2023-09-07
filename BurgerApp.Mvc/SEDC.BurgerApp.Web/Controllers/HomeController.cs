using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEDC.BurgerApp.BLL.Services;
using SEDC.BurgerApp.BLL.Services.Implementation;
using SEDC.BurgerApp.Web.Models;
using System.Diagnostics;

namespace SEDC.BurgerApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocationService locationService;
        private readonly IOrderService orderService;
        private readonly ILogger<LocationController> logger;

        public HomeController(ILocationService locationService, IOrderService orderService, ILogger<LocationController> logger)
        {
            this.locationService = locationService;
            this.orderService = orderService;
            this.logger = logger;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            var orders = orderService.GetAll();
            var orderCount = orders.Count();
            var locations = locationService.GetAll();

            ViewBag.MostPopularBurger = orderCount <= 0 ? null : orders.GroupBy(x => x.Burger.Name).OrderByDescending(group => group.Count()).FirstOrDefault();
            ViewBag.TotalOrders = orderCount <= 0 ? 0 : orderCount;
            ViewBag.AveragePrice = orderCount <= 0 ? 0 : orders.Average(o => o.Burger.Price);
            ViewBag.Locations = locations;
            ViewBag.TotalLocations = locations.Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}