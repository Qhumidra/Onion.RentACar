using AutoMapper;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Utilities.Mappings
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, RentCategoryListDto>().ReverseMap();
        }
    }
}
