using Microsoft.AspNetCore.Mvc;
using TiresShop.Models;
using TiresShop.Services.Tires;

namespace TiresShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ITireService _tireService;
        private readonly ShopCart _shopCart;

        public ShopCartController(ITireService tireService, ShopCart shopCart)
        {
            _tireService = tireService;
            _shopCart = shopCart;
        }

        public IActionResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };

            return View(obj);
        }

        public IActionResult addToCart(int id)
        {
            var item = _tireService.GetAllTires.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var item = _tireService.GetAllTires.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.RemoveFromCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
