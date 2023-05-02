using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarQueryRequest : IRequest<CarListDto?>
    {
        public int Id { get; set; }

        public GetCarQueryRequest(int id)
        {
            Id = id;
        }
    }
}
