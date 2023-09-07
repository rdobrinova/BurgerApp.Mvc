using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEDC.BurgerApp.BLL.DTOs.Burgers;
using SEDC.BurgerApp.BLL.DTOs.Orders;
using SEDC.BurgerApp.BLL.Services;
using SEDC.BurgerApp.BLL.Services.Implementation;

namespace SEDC.BurgerApp.Web.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService orderService;
        private readonly IBurgerService _burgerService;
        private readonly ILogger<OrderController> logger;

        public OrderController(IOrderService orderService, IBurgerService burgerService, ILogger<OrderController> logger)
        {
            this.orderService = orderService;
            _burgerService = burgerService;
            this.logger = logger;
        }


        // GET: OrderController
        public ActionResult Index()
        {
            var DTOs = orderService.GetAll();
            return View(DTOs);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return View("ViewNotFound");
            }
            try
            {
                var order = orderService.GetById(id);
                return View(order);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }
        }


        // GET: OrderController/Create
        public ActionResult Create()
        {
            ViewBag.Burgers = new SelectList(_burgerService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateOrderDTO order)
        {
            orderService.Create(order);
            return RedirectToAction("Index");
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                if (id == null)
                    return View("ViewNotFound");

                var order = orderService.GetById(id);
                return View(order);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDTO model)
        {
            try
            {
                orderService.Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            orderService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
