using AutoMapper;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Utilities.Mappings
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CarCategoryListDto>().ReverseMap();
        }
    }
}
