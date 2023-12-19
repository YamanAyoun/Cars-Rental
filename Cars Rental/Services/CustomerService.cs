using Cars_Rental.Data;
using Cars_Rental.Models.DTOs;
using Cars_Rental.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Rental.Models.Services
{


    public class CustomerService : ICustomer
    {
        private readonly CarRentDbContext _context;

        public CustomerService(CarRentDbContext context)
        {
            _context = context;
        }


        public async Task<Customer> Create(Customer customer)
        {
            Customer newcustomer = new Customer
            {
                Id = customer.Id,
                UserName = customer.UserName,
                Email = customer.Email,
                Gender = customer.Gender,
                PhoneNumber = customer.PhoneNumber,
                NationalNumber = customer.NationalNumber,
                Address = customer.Address,
                Password = customer.Password
            };
            _context.Entry(newcustomer).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<CustomerDTO> GetCustomer(int id)
        {
            return await _context.customers
                .Select(cus => new CustomerDTO
                {                    
                    UserName = cus.UserName,
                    Email = cus.Email,
                    Gender = cus.Gender,
                    PhoneNumber = cus.PhoneNumber,
                    NationalNumber = cus.NationalNumber,
                    Address = cus.Address,                    
                }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Delete(int id)
        {
            CustomerDTO customer = await GetCustomer(id);

            _context.Entry(customer).State = EntityState.Deleted;

            await _context.SaveChangesAsync();


        }

        public async Task<List<CustomerDTO>> GetCustomer()
        {
            return await _context.customers
                .Select(cus => new CustomerDTO
                {
                    Id = cus.Id,
                    UserName = cus.UserName,
                    Email = cus.Email,
                    Gender = cus.Gender,
                    PhoneNumber = cus.PhoneNumber,
                    NationalNumber = cus.NationalNumber,
                    Address = cus.Address,
                 }).ToListAsync();
        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            Customer UpdateCustomer = new Customer
            {
                Id = customer.Id,
                UserName = customer.UserName,
                Email = customer.Email,
                Gender = customer.Gender,
                PhoneNumber = customer.PhoneNumber,
                NationalNumber = customer.NationalNumber,
                Address = customer.Address,
                Password = customer.Password
            };
            _context.Entry(UpdateCustomer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}