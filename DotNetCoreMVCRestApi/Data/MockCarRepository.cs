using DotNetCoreMVCRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCRestApi.Data
{
    public class MockCarRepository : ICarRepository
    {
        public void CreateCar(Car car)
        {
            throw new NotImplementedException();
        }

        public async Task <List<Car>> GetAllCarsAsync()
        {
            return new List<Car>
            {
                new Car() { Id = 1, Make = "Tesla", Model = "Cyber Truck", Year = "2021", Color = "Silver", VIN = "2B3CA3CV5AH250416" },
                new Car() { Id = 2, Make = "BMW", Model = "330e", Year = "2017", Color = "White", VIN = "JT2SK11E1S0239653" },
                new Car() { Id = 3, Make = "Toyota", Model = "Camry", Year = "2007", Color = "Yellow", VIN = "1G1ZT54805F257183" }
            };
        }
        
        public async Task<Car> GetCarByIdAsync(int id)
        {
            return new Car() { Id = 1, Make = "Tesla", Model = "Cyber Truck", Year = "2021", Color = "Silver", VIN = "2B3CA3CV5AH250416" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
