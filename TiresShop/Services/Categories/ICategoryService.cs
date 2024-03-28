using TiresShop.Models;

namespace TiresShop.Services.Categories
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories { get; }
    }
}
