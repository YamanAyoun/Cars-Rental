using Cars_Rental.Models.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_Rental.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        [Required]
        public double PricePerDay { get; set; }

        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public List<BookingCar> BookingCars { get; set; }

        public enum CarType
        {
            Micro,
            Sport,
            Van,
            SUV,
            Luxury
        }
    }
}
