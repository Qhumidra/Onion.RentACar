using AutoMapper;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Commands.CarCommands;
using Onion.RentACar.Domain.Entities;
using System.Drawing;

namespace Onion.RentACar.Application.Utilities.Mappings
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarListDto>().ReverseMap();
            CreateMap<Car, CarCreatedDto>().ReverseMap();
            CreateMap<Car, CarUpdatedDto>().ReverseMap();
            CreateMap<CreateCarCommandRequest, Car>();
        }
    }
}
