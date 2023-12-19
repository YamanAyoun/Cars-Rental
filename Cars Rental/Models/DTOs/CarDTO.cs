﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Rental.Models.DTOs
{
    public class CarDTO
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

        public CompanyDTO Company { get; set; }

        public CustomerDTO Customer { get; set; }

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
