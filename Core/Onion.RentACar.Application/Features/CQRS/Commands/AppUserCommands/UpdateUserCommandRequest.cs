using MediatR;

namespace Onion.RentACar.Application.Features.CQRS.Commands.AppUserCommand
{
    public class UpdateUserCommandRequest : IRequest
    {
        public string? CurrentName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public string? Sokak { get; set; }
        public string? Mahalle { get; set; }
        public string? Ilce { get; set; }
        public string? Il { get; set; }
        public string? AdresNotu { get; set; }
    }
}
