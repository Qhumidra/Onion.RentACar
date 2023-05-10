using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Queries.CategoryQuery
{
    public class GetRentCategoriesQueryRequest : IRequest<List<RentCategoryListDto>>
    {
    }
}
