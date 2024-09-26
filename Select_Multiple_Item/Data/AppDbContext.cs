using Microsoft.EntityFrameworkCore;
using Select_Multiple_Item.Entities;
using Select_Multiple_Item.Enums;

namespace Select_Multiple_Item.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Car> Cars { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Manufacturer = Manufacturers.Chevrolet,
                    Model = "Cobalt",
                    Color = Colors.black,
                    Price = (decimal)Prices.One
                },
            new Car
            {
                Id = 2,
                Manufacturer = Manufacturers.Chevrolet,
                Model = "Malibu",
                Color = Colors.black,
                Price = (decimal)Prices.Six
			},
            new Car
            {
                Id = 3,
                Manufacturer = Manufacturers.Toyota,
                Model = "Camry",
                Color = Colors.green,
                Price = (decimal)Prices.Three

			},
            new Car
            {
                Id = 4,
                Manufacturer = Manufacturers.Honda,
                Model = "Civic",
                Color = Colors.red,
                Price = (decimal)Prices.One

			},
            new Car
            {
                Id = 5,
                Manufacturer = Manufacturers.Ford,
                Model = "Focus",
                Color = Colors.yellow,
                Price = (decimal)Prices.Four

			},
            new Car
            {
                Id = 6,
                Manufacturer = Manufacturers.BMW,
                Model = "X5",
                Color = Colors.black,
                Price = (decimal)Prices.Fourteen

			},
            new Car
            {
                Id = 7,
                Manufacturer = Manufacturers.Audi,
                Model = "A4",
                Color = Colors.blue,
                Price = (decimal)Prices.Thirteen

			},
            new Car
            {
                Id = 8,
                Manufacturer = Manufacturers.Mercedes,
                Model = "C-Class",
                Color = Colors.white,
                Price = (decimal)Prices.Ten
            },
            new Car
            {
                Id = 9,
                Manufacturer = Manufacturers.Hyundai,
                Model = "Elantra",
                Color = Colors.white,
                Price = (decimal)Prices.Twelve

			},
            new Car
            {
                Id = 10,
                Manufacturer = Manufacturers.Kia,
                Model = "Optima",
                Color = Colors.green,
                Price = (decimal)Prices.Six

			}

            );
        }
    }
}
