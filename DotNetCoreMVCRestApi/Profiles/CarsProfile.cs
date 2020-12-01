using AutoMapper;
using DotNetCoreMVCRestApi.DataTransferObjects;
using DotNetCoreMVCRestApi.Models;

namespace DotNetCoreMVCRestApi.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Car, CarReadDto>();
        }
    }
}
