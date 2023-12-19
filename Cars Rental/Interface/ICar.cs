using Cars_Rental.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Rental.Models.Interface
{
    public interface ICar
    {
        Task<Car> CreateCar(Car car);

        Task<List<CarDTO>> GetCars();

        Task<CarDTO> GetCar(int Id);

        Task<Car> UpdateCar(int Id, Car car);

        Task DeleteCar(int Id);

        Task<List<CarDTO>> FilterOnCar(string name, int year, string color, string model);
        Task<List<CarDTO>> SortYear();
        Task<List<CarDTO>> SortByPrice(int price);



    }
}