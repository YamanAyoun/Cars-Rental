using Cars_Rental.Models.Interface;
using System.ComponentModel.DataAnnotations;

namespace Cars_Rental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public char Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public long NationalNumber { get; set; }

        public string Address { get; set; }

        public List<BookingCar> bookingCars { get; set; }

    }
}
