﻿using Cars_Rental.Data;
using Cars_Rental.Models.DTOs;
using Cars_Rental.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Rental.Models.Service
{
    public class CarService : ICar
    {
        private readonly CarRentDbContext _context;

        public CarService(CarRentDbContext context)
        {
            _context = context;
        }

        public async Task<Car> CreateCar(Car car)
        {
            Car NewCar = new Car
            {
                Name = car.Name,
                Color = car.Color,
                Year = car.Year,
                Model = car.Model,
                PlateNumber = car.PlateNumber,
                PricePerDay = car.PricePerDay,
                ImageUrl = car.ImageUrl,
                CompanyId = car.CompanyId
            };
            _context.Entry(NewCar).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return NewCar;
        }

        public async Task DeleteCar(int Id) // logic for Delete Car
        {
            Car car = await _context.Cars.FindAsync(Id);
            _context.Entry(car).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<CarDTO> GetCar(int Id)
        {
            return await _context.Cars.Select(car => new CarDTO
            {
                Id = car.Id,
                Name = car.Name,
                Color = car.Color,
                Year = car.Year,
                Model = car.Model,
                PlateNumber = car.PlateNumber,
                PricePerDay = car.PricePerDay,
                ImageUrl = car.ImageUrl

            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<CarDTO>> GetCars() 
        {
            return await _context.Cars.Select(car => new CarDTO
            {
                Id = car.Id,
                Name = car.Name,
                Color = car.Color,
                Year = car.Year,
                Model = car.Model,
                PlateNumber = car.PlateNumber,
                PricePerDay = car.PricePerDay,
                ImageUrl = car.ImageUrl

            }).ToListAsync();
        }

        public async Task<Car> UpdateCar(int id, Car car) 
        {
            Car updateCar = new Car
            {
                Id = car.Id,
                Name = car.Name,
                Color = car.Color,
                Year = car.Year,
                Model = car.Model,
                PlateNumber = car.PlateNumber,
                ImageUrl = car.ImageUrl,
                PricePerDay = car.PricePerDay                
            };
            _context.Entry(updateCar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return car;
        }
        

        public async Task<List<CarDTO>> FilterOnCar(string name, int year, string color, string model)
        {
            var result = await _context.Cars.Select(

                       car1 => new CarDTO
                       {
                           Name = car1.Name.ToLower(),
                           Color = car1.Color.ToLower(),
                           Year = car1.Year,
                           Model = car1.Model.ToLower(),
                           PlateNumber = car1.PlateNumber,
                           PricePerDay = car1.PricePerDay,
                           ImageUrl = car1.ImageUrl
                       }
               )
               .AsNoTracking()
                .ToListAsync();
            if (name != null)
            {
                result = result.Where(y => y.Name.Contains(name)).ToList();
            }
            if (year > 0)
            {
                result = result.Where(y => y.Year.Equals(year)).ToList();
            }
            if (color != null)
            {
                result = result.Where(y => y.Color.Contains(color)).ToList();
            }
            if (model != null)
            {
                result = result.Where(y => y.Model.Contains(model)).ToList();
            }

            return result;
        }
        public async Task<List<CarDTO>> SortYear() 
        {
            var car =  await _context.Cars.Select(

                      car1 => new CarDTO
                      {
                          Id = car1.Id,
                          Name = car1.Name,
                          Color = car1.Color,
                          Year = car1.Year,
                          Model = car1.Model,
                          PlateNumber = car1.PlateNumber,
                          PricePerDay = car1.PricePerDay,
                          ImageUrl = car1.ImageUrl
                      }

              ).OrderByDescending(car => car.Year).ToListAsync();
            return car;
        }
        public async Task<List<CarDTO>> SortByPrice(int price) 
        {
            var car = await _context.Cars.Select(

                         car1 => new CarDTO
                         {
                             Id = car1.Id,
                             Name = car1.Name,
                             Color = car1.Color,
                             Year = car1.Year,
                             Model = car1.Model,
                             PlateNumber = car1.PlateNumber,
                             PricePerDay = car1.PricePerDay,
                             ImageUrl = car1.ImageUrl
                         }).Where(p => p.PricePerDay <= price).OrderByDescending(car =>car.PricePerDay).ToListAsync();
            return car;

        }



    }
}