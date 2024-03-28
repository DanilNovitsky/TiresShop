using Microsoft.EntityFrameworkCore;
using TiresShop.Context;
using TiresShop.Models;
using TiresShop.Services.Categories;

namespace TiresShop.Services.Tires
{
    public class TireService : ITireService
    {
        private readonly ApplicationDbContext _dbContext;

        public TireService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Tire> GetAllTires => _dbContext.Tires.Include(t => t.Category);
       
        public IEnumerable<Tire> GetFavTires => _dbContext.Tires.Where(t => t.IsFavourite).Include(t => t.Category);

        public Tire GetTire(int id) => _dbContext.Tires.FirstOrDefault(t => t.Id == id);
    }
}
