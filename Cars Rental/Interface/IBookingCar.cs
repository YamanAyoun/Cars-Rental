using Cars_Rental.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Rental.Models.Interface
{
    public interface IBookingCar
    {
        Task<BookingCarDTO> GetReservation(int Id);
        Task<List<BookingCarDTO>> GetReservations();
        Task<Object> CreateReservation(BookingCar bookingCar);

        Task<BookingCar> UpdateReservation(int Id, BookingCar bookingCar);
        Task DeleteReservation(int Id);
    }
}