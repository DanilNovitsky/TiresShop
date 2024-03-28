using Microsoft.EntityFrameworkCore;
using TiresShop.Context;

namespace TiresShop.Models
{
    public class ShopCart
    {
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
        private readonly ApplicationDbContext _dbContext;

        public ShopCart(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context)
            {
                ShopCartId = shopCartId
            };
        }

        public void AddToCart(Tire tire)
        {
            _dbContext.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Tire = tire,
                Price = tire.Price,
            });

            _dbContext.SaveChanges();
        }

        public void RemoveFromCart(Tire tire)
        {
            var cartItem = _dbContext.ShopCartItem.FirstOrDefault(item => item.Tire.Id == tire.Id && item.ShopCartId == ShopCartId);
            if (cartItem != null)
            {
                _dbContext.ShopCartItem.Remove(cartItem);
                _dbContext.SaveChanges();
            }
        }

        public List<ShopCartItem> getShopItems()
        {
            return _dbContext.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Tire).ToList();
        }
    }
}
