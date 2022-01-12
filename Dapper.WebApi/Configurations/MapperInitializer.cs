using AutoMapper;
using Dapper.Core.Entities;
using Dapper.Core.Models;
using Dapper.Core.Models.Commands;

namespace CoreApiEdu1.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Car, CarInsertDTO>().ReverseMap();
            CreateMap<Car, CarUpdateDTO>().ReverseMap();
            CreateMap<Basket, BasketInsertDTO>().ReverseMap();
            CreateMap<Basket, BasketUpdateDTO>().ReverseMap();

        }
    }
}
