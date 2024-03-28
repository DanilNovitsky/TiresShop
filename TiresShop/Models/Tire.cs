namespace TiresShop.Models
{
    public class Tire
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }
        public ushort Price { get; set; }
        public bool IsFavourite { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
