using TiresShop.Context;
using TiresShop.Models;

namespace TiresShop.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAllCategories => _dbContext.Category;
    }
}
