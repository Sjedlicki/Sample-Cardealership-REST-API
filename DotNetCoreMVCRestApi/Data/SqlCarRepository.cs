using DotNetCoreMVCRestApi.Models;
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
    }
}
