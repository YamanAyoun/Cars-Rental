using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Rental.Models.DTOs
{
    public class BookingCarDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime PickupDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }

        public int NumberOfDays { get; set; }
        [Required]
        public double Price { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
