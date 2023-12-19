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
    public class CompanyService : ICompany
    {
        private readonly CarRentDbContext _context;

        public CompanyService(CarRentDbContext context)
        {
            _context = context;
        }
        
        public async Task<Company> CreateCompany(Company company)
        {
            Company NewCompany = new Company
            {
                Id = company.Id,
                Email = company.Email,
                Password = company.Password,
                UserName = company.UserName,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                CommercialRegistrationNumber = company.CommercialRegistrationNumber,
                Rate = 0 ,
                ProfilePicture = company.ProfilePicture,
                RateCount = 0
            };
            _context.Entry(NewCompany).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task DeleteCompany(int Id)
        {
            Company company = await _context.Companies.FindAsync(Id);
            _context.Entry(company).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompanyDTO>> GetCompanies()
        {

            return await _context.Companies.Select(C => new CompanyDTO
            {
                Id = C.Id,
                UserName = C.UserName,
                Address = C.Address,
                PhoneNumber = C.PhoneNumber,
                Rate = C.Rate,
                ProfilePicture = C.ProfilePicture,
                Cars = C.Cars.Select(cars => new CarDTO
                {
                    Id = cars.Id,
                    Name = cars.Name,
                    Color = cars.Color,
                    Year = cars.Year,
                    Model = cars.Model,
                    PlateNumber = cars.PlateNumber,
                    ImageUrl = cars.ImageUrl,
                    PricePerDay = cars.PricePerDay
                }).ToList(),
                bookingCars = C.bookingCars.Select(reservation => new BookingCarDTO
                {
                    Id = reservation.Id,
                    PickupDate = reservation.PickupDate,
                    ReturnDate = reservation.ReturnDate,
                    NumberOfDays = reservation.NumberOfDays,
                    Price = reservation.Price                    
                }).ToList(),
                Employees = C.Employees.Select(employee => new EmployeeDTO
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    PhoneNumber = employee.PhoneNumber,
                    ProfilePicture = employee.ProfilePicture,
                    Email = employee.Email
                }).ToList()
            }).ToListAsync();
        }

        public async Task<CompanyDTO> GetCompany(int Id)
        {

            return await _context.Companies.Select(C => new CompanyDTO
            {
                Id = C.Id,
                UserName = C.UserName,
                Address = C.Address,
                PhoneNumber = C.PhoneNumber,
                Rate = C.Rate,
                ProfilePicture = C.ProfilePicture,                
                Cars = C.Cars.Select(cars => new CarDTO
                {
                    Id = cars.Id,
                    Name = cars.Name,
                    Color = cars.Color,
                    Year = cars.Year,
                    Model = cars.Model,
                    PlateNumber = cars.PlateNumber,
                    ImageUrl = cars.ImageUrl,
                    PricePerDay = cars.PricePerDay
                }).ToList(),
                bookingCars = C.bookingCars.Select(reservation => new BookingCarDTO
                {
                    Id = reservation.Id,
                    PickupDate = reservation.PickupDate,
                    ReturnDate = reservation.ReturnDate,
                    NumberOfDays = reservation.NumberOfDays,
                    Price = reservation.Price
                }).ToList(),
                Employees = C.Employees.Select(employee => new EmployeeDTO
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    ProfilePicture = employee.ProfilePicture,                    
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == Id);
        }       

        public async Task<Company> UpdateCompany(int Id, Company company)
        {
            Company UpdateCompany = new Company
            {
                Id = company.Id,
                Email = company.Email,
                Password = company.Password,
                UserName = company.UserName,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                CommercialRegistrationNumber = company.CommercialRegistrationNumber,
                ProfilePicture = company.ProfilePicture
            };
            _context.Entry(UpdateCompany).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return company;
        }
        
        public async Task AddCarToCompany(int CarId, int CompanyId) 
        {                         
            Car car = new Car()
            {
                Id = CarId,
                CompanyId = CompanyId
            };

            _context.Entry(car).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task AddEmployeeToCompany(int EmployeeId, int CompanyId)
        {
            Employee employee = new Employee()
            {
                Id = EmployeeId,
                CompanyId = CompanyId
            };

            _context.Entry(employee).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task AddReservationToCompany(int bookingCarId, int CompanyId)
        {
            BookingCar bookingCar = new BookingCar()
            {
                Id = bookingCarId,
                CompanyId = CompanyId
            };

            _context.Entry(bookingCar).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveCarFromCompany(int CarId, int CompanyId)  
        {
            Car car = await _context.Cars.Where(o => o.Id == CarId && o.CompanyId == CompanyId).FirstOrDefaultAsync();

            _context.Entry(car).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveEmployeeFromCompany(int EmployeeId, int CompanyId)
        {
            Employee employee = await _context.Employees.Where(l => l.Id == EmployeeId && l.CompanyId == CompanyId).FirstOrDefaultAsync();

            _context.Entry(employee).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveReservationFromCompany(int bookingCarId, int CompanyId)
        {
            BookingCar reservation = await _context.BookingCar.Where(a => a.Id == bookingCarId && a.CompanyId == CompanyId).FirstOrDefaultAsync();

            _context.Entry(reservation).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        
        public async Task<List<CompanyDTO>> SearchByName(string term)
        {
            var result = _context.Companies.Select(C => new CompanyDTO
            {
                UserName = C.UserName,
                Address = C.Address,
                PhoneNumber = C.PhoneNumber,
                ProfilePicture = C.ProfilePicture,
                Rate = C.Rate                
            })
                .Where(x => x.UserName.Contains(term));
            
           var  c = await result.Select(m => new CompanyDTO { 
               UserName = m.UserName,
           }).AsNoTracking().ToListAsync();

            return c;
        }

        public async Task<List<CompanyDTO>> SearchByAddress(string address) 
        {
             return await _context.Companies.Select(company => new CompanyDTO
            { 
                UserName = company.UserName,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,                
                ProfilePicture = company.ProfilePicture,
                Rate = company.Rate,
                Cars = company.Cars
                .Select(cars  => new CarDTO
                {
                    Name = cars.Name,
                    Color = cars.Color,
                    Model = cars.Model,
                    Year = cars.Year
                }).ToList()

            }).Where(x => x.Address.Contains(address)).ToListAsync();
         
        }

        public async Task<Company> UpdateRate(Company company, int rate)
        {
            Company updatedCompany = new Company
            {
                Id = company.Id,
                UserName = company.UserName,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
                Password = company.Password,
                ProfilePicture = company.ProfilePicture,
                RateCount = company.RateCount,
                Rate = (company.Rate + rate)/(company.RateCount + 1),
            };
            _context.Entry(updatedCompany).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return company;
        }

    }
}