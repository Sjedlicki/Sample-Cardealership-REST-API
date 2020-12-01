using DotNetCoreMVCRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreMVCRestApi.Data
{
    public class SqlCarRepository : ICarRepository
    {
        private readonly CarContext _context;

        public SqlCarRepository(CarContext context)
        {
            _context = context;
        }

        public void CreateCar(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            _context.Car.Add(car);

        }

        public List<Car> GetAllCars()
        {
            var cars = _context.Car.ToList();

            return cars;
        }

        public Car GetCarById(int id)
        {
            var car = _context.Car.FirstOrDefault(car => car.Id == id);

            return car;
        }

        public bool SaveChanges()
        {
           return  (_context.SaveChanges() >= 0);
        }
    }
}
