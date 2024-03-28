namespace TiresShop.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TireId { get; set; }
        public uint Price { get; set; }
        public virtual Tire Tire{ get; set; }
        public virtual Order Order{ get; set; }
    }
}
