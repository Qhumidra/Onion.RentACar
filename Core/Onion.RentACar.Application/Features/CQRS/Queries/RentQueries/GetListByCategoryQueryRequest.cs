using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Queries.RentQueries
{
    public class GetListByCategoryQueryRequest : IRequest<List<RentListDto>>
    {
        public int Id { get; set; }

        public GetListByCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
