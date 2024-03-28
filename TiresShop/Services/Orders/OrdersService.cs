using TiresShop.Context;
using TiresShop.Models;

namespace TiresShop.Services.Orders
{
    public class OrdersService : IOrdersService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ShopCart shopCart;

        public OrdersService(ApplicationDbContext dbContext, ShopCart shopCart)
        {
            _dbContext = dbContext;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.UtcNow;
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            var items = shopCart.ListShopItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    TireId = el.Tire.Id,
                    OrderId = order.Id,
                    Price = el.Tire.Price
                };
                _dbContext.OrderDetails.Add(orderDetail);
            }
            _dbContext.SaveChanges();
        }
    }
}
