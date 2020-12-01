using AutoMapper;
using DotNetCoreMVCRestApi.Data;
using DotNetCoreMVCRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetCoreMVCRestApi.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public CarsController(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
