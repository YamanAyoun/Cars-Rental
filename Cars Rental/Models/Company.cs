using Cars_Rental.Models.Interface;
using System.ComponentModel.DataAnnotations;

namespace Cars_Rental.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string ProfilePicture { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        public int CommercialRegistrationNumber { get; set; }

        public double Rate { get; set; }

        public int RateCount { get; set; }

        public List<Car> Cars { get; set; }

        public List<BookingCar> bookingCars { get; set; }

        public List<Employee> Employees { get; set; }

    }
}
