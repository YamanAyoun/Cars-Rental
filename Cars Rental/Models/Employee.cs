using System.ComponentModel.DataAnnotations;

namespace Cars_Rental.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string ProfilePicture { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}
