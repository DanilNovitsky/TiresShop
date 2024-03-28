using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TiresShop.Models;
using TiresShop.Services.Orders;

namespace TiresShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly ShopCart _shopCart;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrdersService ordersService, ShopCart shopCart, ILogger<OrderController> logger)
        {
            _ordersService = ordersService;
            _shopCart = shopCart;
            _logger = logger;
        }

        public ActionResult Checkout()
        {
            var order = new Order
            {
                OrderDetails = new List<OrderDetail>()
            };
            return View(order);
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            _logger.LogInformation("Received order: {Order}", JsonConvert.SerializeObject(order));
            _shopCart.ListShopItems = _shopCart.getShopItems();

            _logger.LogInformation("ShopCart items: {ShopCartItems}", JsonConvert.SerializeObject(_shopCart.ListShopItems));
            if (_shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "You must have products!");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(p => p.ErrorMessage)).ToList();
                _logger.LogWarning("Model state is not valid. Errors: {ModelStateErrors}", JsonConvert.SerializeObject(errors));
            }

            if (ModelState.IsValid)
            {
                _ordersService.createOrder(order);
                _logger.LogInformation("Order successfully created: {OrderId}", order.Id);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public ActionResult Complete()
        {
            ViewBag.Message = "Order processed successfully";
            return View();
        }
    }
}
