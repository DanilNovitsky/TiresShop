namespace TiresShop.Models
{
    public class TiresListViewModel
    {
        public IEnumerable<Tire> AllTires { get; set; }
        public string TireCategory { get; set; }
    }
}
