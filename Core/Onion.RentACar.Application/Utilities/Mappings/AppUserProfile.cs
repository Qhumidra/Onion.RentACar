using AutoMapper;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Utilities.Mappings
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, UserGetByNameDto>().ReverseMap();
        }

    }
}
