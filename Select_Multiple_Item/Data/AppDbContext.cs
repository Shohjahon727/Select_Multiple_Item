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
                    Color = Colors.Black,
                    Price = 10000
                },
            new Car
            {
                Id = 2,
                Manufacturer = Manufacturers.Chevrolet,
                Model = "Malibu",
                Color = Colors.Black,
                Price = 15000
			},
            new Car
            {
                Id = 3,
                Manufacturer = Manufacturers.Toyota,
                Model = "Camry",
                Color = Colors.Green,
                Price = 12000

			},
            new Car
            {
                Id = 4,
                Manufacturer = Manufacturers.Honda,
                Model = "Civic",
                Color = Colors.Red,
                Price = 10000

			},
            new Car
            {
                Id = 5,
                Manufacturer = Manufacturers.Ford,
                Model = "Focus",
                Color = Colors.Yellow,
                Price = 13000

			},
            new Car
            {
                Id = 6,
                Manufacturer = Manufacturers.BMW,
                Model = "X5",
                Color = Colors.Black,
                Price = 35000

			},
            new Car
            {
                Id = 7,
                Manufacturer = Manufacturers.Audi,
                Model = "A4",
                Color = Colors.Blue,
                Price = 30000

			},
            new Car
            {
                Id = 8,
                Manufacturer = Manufacturers.Mercedes,
                Model = "C-Class",
                Color = Colors.White,
                Price = 20000
            },
            new Car
            {
                Id = 9,
                Manufacturer = Manufacturers.Hyundai,
                Model = "Elantra",
                Color = Colors.White,
                Price = 25000

			},
            new Car
            {
                Id = 10,
                Manufacturer = Manufacturers.Kia,
                Model = "Optima",
                Color = Colors.Green,
                Price = 15000

			}

            );
        }
    }
}
