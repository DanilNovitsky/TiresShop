using Microsoft.AspNetCore.Mvc;
using TiresShop.Models;
using TiresShop.Services.Categories;
using TiresShop.Services.Tires;

namespace TiresShop.Controllers
{
    public class TireController : Controller
    {
        private readonly ITireService _tireService;
        private readonly ICategoryService _categoryService;

        public TireController(ITireService tireService, ICategoryService categoryService)
        {
            _tireService = tireService;
            _categoryService = categoryService;
        }

        [Route("Tire/GetAllTires")]
        [Route("Tire/GetAllTires/{category}")]
        public IActionResult GetAllTires(string category)
        {
            IEnumerable<Tire> tires = null;
            string _category = category;
            string currCategory = string.IsNullOrEmpty(category) ? "All" : category;
            if (string.IsNullOrEmpty(category))
            {
                tires = _tireService.GetAllTires.OrderBy(i => i.Id);
            } else
            {
                string categoryNormalized = category.ToUpperInvariant();
                tires = _tireService.GetAllTires
                    .Where(i => i.Category.Name.ToUpperInvariant() == categoryNormalized)
                    .OrderBy(i => i.Id);
            }
            
            var tireObj = new TiresListViewModel
            {
                AllTires = tires,
                TireCategory = currCategory
            };  
           
            return View(tireObj);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
