using AutoMapper;
using DotNetCoreMVCRestApi.Data;
using DotNetCoreMVCRestApi.Models;
using DotNetCoreMVCRestApi.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreMVCRestApi.Controllers
{
    [Route("api/cars")]
    [ApiController]
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
        public async Task<ActionResult<List<CarReadDto>>> GetAllCarsAsync()
        {
            var cars = await _repository.GetAllCarsAsync();

            if (cars == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CarReadDto>>(cars));
        }

        // GET api/cars/{id}
        [HttpGet("{id}", Name = "GetCarByIdAsync")]
        public async Task<ActionResult<CarReadDto>> GetCarByIdAsync(int id)
        {
            var car = await _repository.GetCarByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CarReadDto>(car));
        }

        // POST api/cars
        [HttpPost]
        public async Task<ActionResult<CarReadDto>> CreateCarAsync([Bind("Make,Model,Year,Color,VIN")] CarCreateDto carCreateDto)
        {
            if (ModelState.IsValid)
            {
                var carModel = _mapper.Map<Car>(carCreateDto);

                await _repository.CreateCarAsync(carModel);
                await _repository.SaveChangesAsync();

                var carReadDto = _mapper.Map<CarReadDto>(carModel);

                return CreatedAtRoute(nameof(GetCarByIdAsync), new { Id = carReadDto.Id }, carReadDto);
            }

            return BadRequest();
        }

        // PUT api/cars/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCarAsync(int id, [Bind("Make,Model,Year,Color,VIN")] CarUpdateDto carUpdateDto)
        {
            var carModelFromRepository = await _repository.GetCarByIdAsync(id);

            if (carModelFromRepository == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _mapper.Map(carUpdateDto, carModelFromRepository);

                await _repository.UpdateCarAsync(carModelFromRepository);
                await _repository.SaveChangesAsync();

                return NoContent();
            }

            return BadRequest();
        }
    }
}
