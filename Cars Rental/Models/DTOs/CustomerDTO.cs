
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Rental.Models.DTOs
{
    public class CustomerDTO
    {

        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public char Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public long NationalNumber { get; set; }
        public string Address { get; set; }
        public List<CarDTO> Cars { get; set; }
        public List<BookingCarDTO> Reservations { get; set; }
    }
}