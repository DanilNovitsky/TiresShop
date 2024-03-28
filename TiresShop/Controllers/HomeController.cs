using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TiresShop.Models;
using TiresShop.Services.Tires;

namespace TiresShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITireService _tireService;

        public HomeController(ITireService tireService)
        {
            _tireService = tireService;
        }

        public IActionResult Index()
        {
            var favTire = new HomeViewModel
            {
                FavTires = _tireService.GetFavTires
            };
            return View(favTire);
        }
    }
}