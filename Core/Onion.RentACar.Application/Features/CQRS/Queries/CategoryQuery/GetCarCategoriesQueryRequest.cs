using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Queries.CategoryQuery
{
    public class GetCarCategoriesQueryRequest : IRequest<List<CarCategoryListDto>>
    {
    }
}
