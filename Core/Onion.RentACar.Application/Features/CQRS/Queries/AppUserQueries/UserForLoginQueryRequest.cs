using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Helpers.JWT;

namespace Onion.RentACar.Application.Features.CQRS.Queries.AppUser
{
    public class UserForLoginQueryRequest : IRequest<UserAccessToken>
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
