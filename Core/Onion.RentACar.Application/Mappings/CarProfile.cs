using AutoMapper;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Commands.CarCommands;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Mappings
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            this.CreateMap<Car, CarListDto>().ReverseMap();
            this.CreateMap<Car, CarCreatedDto>().ReverseMap();
            this.CreateMap<Car, CarUpdatedDto>().ReverseMap();
            this.CreateMap<CreateCarCommandRequest, Car>();
        }
    }
}
