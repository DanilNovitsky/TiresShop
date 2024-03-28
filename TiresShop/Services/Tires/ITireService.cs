using TiresShop.Models;

namespace TiresShop.Services.Tires
{
    public interface ITireService
    {
        IEnumerable<Tire> GetAllTires { get; }
        IEnumerable<Tire> GetFavTires { get; }
        Tire GetTire(int id);
    }
}
