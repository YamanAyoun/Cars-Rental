using Cars_Rental.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Rental.Models.Interface
{
    public interface ICustomer
    {

        Task<Customer> Create(Customer customer);
        Task<CustomerDTO> GetCustomer(int id);
        Task Delete(int id);
        Task<List<CustomerDTO>> GetCustomer();
        Task<Customer> UpdateCustomer(int id, Customer customer);


    }
}