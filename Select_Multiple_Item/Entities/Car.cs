using Select_Multiple_Item.Enums;
using System.ComponentModel.DataAnnotations;

namespace Select_Multiple_Item.Entities
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        public Manufacturers Manufacturer { get; set; }
        public string Model { get; set; }
        public Colors Color { get; set; }
        public decimal Price { get; set; }
    }
}
