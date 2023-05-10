using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdQueryRequest : IRequest<CarListDto>
    {
        public int Id { get; set; }

        public GetCarByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
