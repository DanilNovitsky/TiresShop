using TiresShop.Context;
using TiresShop.Models;

namespace TiresShop
{
    public class DBObjects
    {
        public static void Initial(ApplicationDbContext _dbContext)
        {
            if (!_dbContext.Category.Any()) 
            {
                _dbContext.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!_dbContext.Tires.Any())
            {
                _dbContext.Tires.AddRange(
                    new Tire
                    {
                        Brand = "Michelin",
                        Model = "Pilot Sport 4",
                        Size = "225/45 R17",
                        Image = "Michelin_Pilot_Sport4.jpg",
                        Price = 120,
                        IsFavourite = true,
                        Quantity = 10,
                        Category = Categories["Passenger"]
                    },
                    new Tire
                    {
                        Brand = "Bridgestone",
                        Model = "Turanza T005",
                        Size = "205/55 R16",
                        Image = "bridgestone-turanza-t005.jpg",
                        Price = 100,
                        IsFavourite = false,
                        Quantity = 15,
                        Category = Categories["Passenger"]
                    });
                            
            }

            _dbContext.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category {Name = "Passenger", Description = "These tires are designed for regular passenger cars"},
                        new Category {Name = "Truck", Description = "These tires are designed for trucks"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach(Category c  in list)
                    {
                        category.Add(c.Name, c);
                    }
                }
                return category;
            }
        }
    }
}
