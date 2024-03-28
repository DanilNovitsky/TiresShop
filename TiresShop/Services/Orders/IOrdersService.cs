using TiresShop.Models;

namespace TiresShop.Services.Orders
{
    public interface IOrdersService
    {
        void createOrder(Order order);
    }
}
