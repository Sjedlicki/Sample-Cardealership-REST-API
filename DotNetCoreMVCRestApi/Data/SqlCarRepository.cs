using DotNetCoreMVCRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCRestApi.Data
{
    public class SqlCarRepository : ICarRepository
    {
        private readonly CarContext _context;

        public SqlCarRepository(CarContext context)
        {
            _context = context;
        }

        public async Task CreateCarAsync(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            await _context.Car.AddAsync(car);

        }

        public async Task <List<Car>> GetAllCarsAsync()
        {
            var cars = await _context.Car.ToListAsync();

            return cars;
        }

        public async Task <Car> GetCarByIdAsync(int id)
        {
            var car = await _context.Car.FirstOrDefaultAsync(car => car.Id == id);

            return car;
        }

        public async Task<bool> SaveChangesAsync()
        {
           return  (await _context.SaveChangesAsync() >= 0);
        }
    }
}
