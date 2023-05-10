using MediatR;
using Onion.RentACar.Application.Helpers.JWT;

namespace Onion.RentACar.Application.Features.CQRS.Commands.AppUserCommand
{
    public class UserForRegisterCommandRequest : IRequest<AccessToken>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
    }
}
