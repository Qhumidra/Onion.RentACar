using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Queries.AppUser
{
    public class GetUserByNameQueryRequest : IRequest<UserGetByNameDto>
    {
        public string? Name { get; set; }

        public GetUserByNameQueryRequest(string? name)
        {
            Name = name;
        }
    }
}
