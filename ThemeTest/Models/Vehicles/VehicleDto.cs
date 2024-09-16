using System.ComponentModel.DataAnnotations;

namespace ThemeTest.Models.Vehicles
{
    public class VehicleDto
    {
        
        public Guid CarId { get; set; }
        public string Make { get; set; }  // Manufacturer or Brand of the car
        public string Model { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }  // e.g., SUV, Sedan, Hatchback
        public decimal PricePerDay { get; set; }
        public string Status { get; set; }  // e.g., Available, Rented
    }
}
