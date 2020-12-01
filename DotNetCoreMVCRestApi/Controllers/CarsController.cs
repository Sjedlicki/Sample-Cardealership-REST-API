using AutoMapper;
using DotNetCoreMVCRestApi.Data;
using DotNetCoreMVCRestApi.Models;
using DotNetCoreMVCRestApi.DataTransferObjects;
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
        public ActionResult <List<CarReadDto>> GetAllCars()
        {
            var cars = _repository.GetAllCars();

            if(cars == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CarReadDto>>(cars));
        }

        // GET api/cars/{id}
        [HttpGet("{id}")]
        public ActionResult <CarReadDto> GetCarById(int id)
        {
            var car = _repository.GetCarById(id);

            if(car ==  null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CarReadDto>(car));
        }
    }
}
