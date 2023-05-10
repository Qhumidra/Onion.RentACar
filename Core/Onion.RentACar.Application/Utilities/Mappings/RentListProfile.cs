using AutoMapper;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Commands.RentCommands;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Utilities.Mappings
{
    public class RentListProfile : Profile
    {
        public RentListProfile()
        {
            CreateMap<RentList, RentListDto>().ReverseMap();
            CreateMap<RentList, RentCreateDto>().ReverseMap();
            CreateMap<CreateRentCommandRequest, RentList>();
        }
    }
}
