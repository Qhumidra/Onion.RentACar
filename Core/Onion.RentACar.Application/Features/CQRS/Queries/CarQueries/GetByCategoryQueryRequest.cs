using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Queries.CarQueries
{
    public class GetByCategoryQueryRequest : IRequest<List<CarListDto?>>
    {
        public int Id { get; set; }

        public GetByCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
