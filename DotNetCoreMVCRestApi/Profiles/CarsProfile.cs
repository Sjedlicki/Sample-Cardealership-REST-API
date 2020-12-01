using AutoMapper;
using DotNetCoreMVCRestApi.DataTransferObjects;
using DotNetCoreMVCRestApi.Models;

namespace DotNetCoreMVCRestApi.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            // Source -> Destination
            CreateMap<Car, CarReadDto>();
            CreateMap<CarCreateDto, Car>();
            CreateMap<CarUpdateDto, Car>();
        }
    }
}
