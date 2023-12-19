using Cars_Rental.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars_Rental.Models.Interface
{
    public interface IEmployee
    {
        Task<Employee> CreateEmployee(Employee employee);

        Task<List<EmployeeDTO>> GetEmployees();

        Task<EmployeeDTO> GetEmployee(int id);

        Task<Employee> UpdateEmployee(int id, Employee employee);

        Task DeleteEmployee(int id);

        Task<List<EmployeeDTO>> SearchByName(string term);
    }
}