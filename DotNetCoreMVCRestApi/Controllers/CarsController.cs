using DotNetCoreMVCRestApi.Data;
using DotNetCoreMVCRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCRestApi.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
       //private readonly MockCarRepository _repository = new MockCarRepository();
        private readonly ICarRepository _repository;

        public CarsController(ICarRepository repository)
        {
            _repository = repository;
        }

        // GET api/cars
        [HttpGet]
        public ActionResult<List<Car>> GetAllCars()
        {
            var carItems = _repository.GetAllCars();

            if(carItems == null)
            {
                return NotFound();
            }

            return Ok(carItems);
        }

        // GET api/cars/{id}
        [HttpGet("{id}")]
        public ActionResult<List<Car>> GetCarById(int id)
        {
            var carItems = _repository.GetCarById(id);

            if(carItems ==  null)
            {
                return NotFound();
            }

            return Ok(carItems);
        }
    }
}
