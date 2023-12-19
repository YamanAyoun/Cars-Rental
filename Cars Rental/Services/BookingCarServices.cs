using Cars_Rental.Data;
using Cars_Rental.Models.DTOs;
using Cars_Rental.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Rental.Models.Service
{
    public class BookingCarServices : IBookingCar
    {
        private readonly CarRentDbContext _context;

        public BookingCarServices(CarRentDbContext context)
        {
            _context = context;
        }

        public async Task<Object> CreateReservation(BookingCar bookingCar)
        {
            var carForRent = await _context.Cars.FindAsync(bookingCar.CarId);
            List<BookingCar> reservCar = await _context.BookingCar.Where(x => x.CarId == carForRent.Id).ToListAsync();
            var IsRent = false;
            foreach (var item in reservCar)
            {
                if (bookingCar.PickupDate >= item.PickupDate && bookingCar.PickupDate <= item.ReturnDate)
                {
                    IsRent = true;
                }
                else if (bookingCar.ReturnDate >= item.PickupDate && bookingCar.ReturnDate <= item.ReturnDate)
                {
                    IsRent = true;
                }
                else if (bookingCar.PickupDate <= item.PickupDate && bookingCar.ReturnDate >= item.ReturnDate)
                {
                    IsRent = true;
                }
                else 
                {
                    IsRent = false;
                }
            }

            if (IsRent == false)
            {
                BookingCar NewbookingCar = new BookingCar
                {
                    Id = bookingCar.Id,
                    PickupDate = bookingCar.PickupDate,
                    ReturnDate = bookingCar.ReturnDate,
                    NumberOfDays = Convert.ToInt32(bookingCar.ReturnDate.Day - bookingCar.PickupDate.Day),
                    Price = bookingCar.Price,
                    CompanyId = bookingCar.CompanyId,
                    CustomerId = bookingCar.CustomerId,
                    CarId = bookingCar.CarId
                };
                _context.Entry(NewbookingCar).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return bookingCar;
            }
            else
                return IsRent;
        }

        public async Task DeleteReservation(int Id)
        {
            BookingCar reservation = await _context.BookingCar.FindAsync(Id);
            _context.Entry(reservation).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<BookingCarDTO> GetReservation(int Id)
        {
            return await _context.BookingCar.Select(bookingCar => new BookingCarDTO
            {
                Id = bookingCar.Id,
                PickupDate = bookingCar.PickupDate,
                ReturnDate = bookingCar.ReturnDate,
                NumberOfDays = bookingCar.NumberOfDays,
                Price = bookingCar.Price

            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<BookingCarDTO>> GetReservations()
        {
            return await _context.BookingCar.Select(bookingCar => new BookingCarDTO
            {
                Id = bookingCar.Id,
                PickupDate = bookingCar.PickupDate,
                ReturnDate = bookingCar.ReturnDate,
                NumberOfDays = bookingCar.NumberOfDays,
                Price = bookingCar.Price

            }).ToListAsync();
        }

        public async Task<BookingCar> UpdateReservation(int Id, BookingCar bookingCar)
        {
            BookingCar updatebookingCar = new BookingCar
            {
                Id = bookingCar.Id,
                PickupDate = bookingCar.PickupDate,
                ReturnDate = bookingCar.ReturnDate,
                NumberOfDays = bookingCar.NumberOfDays,
                Price = bookingCar.Price
            };
            _context.Entry(updatebookingCar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return bookingCar;
        }
    }
}