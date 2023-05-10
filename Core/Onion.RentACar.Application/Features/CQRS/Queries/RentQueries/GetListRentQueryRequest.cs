using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Queries.RentQueries
{
    public class GetListRentQueryRequest : IRequest<List<RentListDto>>
    {
    }
}
