using DotNetCoreMVCRestApi.Models;
using System.Collections.Generic;

namespace DotNetCoreMVCRestApi.Data
{
    public interface ICarRepository
    {
        bool SaveChanges();

        void CreateCar(Car car); //Create
        List<Car> GetAllCars(); // Read
        Car GetCarById(int id); // Read
    }
}
