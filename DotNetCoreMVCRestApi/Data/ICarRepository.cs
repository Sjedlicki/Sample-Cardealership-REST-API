using DotNetCoreMVCRestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreMVCRestApi.Data
{
    public interface ICarRepository
    {
        Task<bool> SaveChangesAsync();
        Task CreateCarAsync(Car car); //Create
        Task<List<Car>> GetAllCarsAsync(); // Read
        Task<Car> GetCarByIdAsync(int id); // Read
        Task UpdateCarAsync(Car car); // Update
        Task DeleteCarAsync(Car car); // Delete
    }
}
