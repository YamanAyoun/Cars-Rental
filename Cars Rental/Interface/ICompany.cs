﻿using Cars_Rental.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Rental.Models.Interface
{
    public interface ICompany
    {
        Task<Company> CreateCompany(Company company);

        Task<List<CompanyDTO>> GetCompanies();
        
        Task<CompanyDTO> GetCompany(int Id);                        

        Task<Company> UpdateCompany(int Id, Company company);
        
        Task DeleteCompany(int Id);

        Task AddCarToCompany(int CarId, int CompanyId);

        Task AddEmployeeToCompany(int EmployeeId, int CompanyId);

        Task AddReservationToCompany(int ReservationId, int CompanyId);

        Task RemoveCarFromCompany(int CarId, int CompanyId);

        Task RemoveReservationFromCompany(int ReservationId, int CompanyId);

        Task RemoveEmployeeFromCompany(int EmployeeId, int CompanyId);                

        Task <List<CompanyDTO>> SearchByName(string name);
        Task<List<CompanyDTO>> SearchByAddress(string address);

        public Task<Company> UpdateRate(Company company, int rate);


    }
}