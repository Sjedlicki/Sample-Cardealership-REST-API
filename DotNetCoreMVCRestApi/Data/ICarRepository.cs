using DotNetCoreMVCRestApi.Models;
using System.Collections.Generic;

namespace DotNetCoreMVCRestApi.Data
{
    public interface ICarRepository
    {
        List<Car> GetAllCars(); // Read
        Car GetCarById(int id); // Read
    }
}
