namespace TiresShop.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Tire Tire { get; set; }
        public int Price { get; set; }
        public string ShopCartId { get; set; }
    }
}
