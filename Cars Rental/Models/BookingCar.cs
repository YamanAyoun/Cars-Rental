using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_Rental.Models
{
    public class BookingCar
    {
        public int Id { get; set; }
        
        public DateTime PickupDate { get; set; }
        
        public DateTime ReturnDate { get; set; }

        public int NumberOfDays { get; set; }
        [Required]
        public double Price { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }

        public int CarId { get; set; }
    }
}
