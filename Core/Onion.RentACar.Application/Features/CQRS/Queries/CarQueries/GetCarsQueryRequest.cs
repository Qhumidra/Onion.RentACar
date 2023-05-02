using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarsQueryRequest : IRequest<List<CarListDto>>
    {
    }
}
