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
        public ActionResult<List<CarReadDto>> GetAllCars()
        {
            var cars = _repository.GetAllCars();

            if (cars == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CarReadDto>>(cars));
        }

        // GET api/cars/{id}
        [HttpGet("{id}", Name = "GetCarById")]
        public ActionResult<CarReadDto> GetCarById(int id)
        {
            var car = _repository.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CarReadDto>(car));
        }

        // POST api/cars
        [HttpPost]
        public ActionResult<CarReadDto> CreateCar([Bind("Make,Model,Year,Color,VIN")] CarCreateDto carCreateDto)
        {
            if (ModelState.IsValid)
            {
                var carModel = _mapper.Map<Car>(carCreateDto);

                _repository.CreateCar(carModel);
                _repository.SaveChanges();

                var carReadDto = _mapper.Map<CarReadDto>(carModel);

                return CreatedAtRoute(nameof(GetCarById), new { Id = carReadDto.Id } ,carReadDto);
            }

            return BadRequest();
        }
    }
}
