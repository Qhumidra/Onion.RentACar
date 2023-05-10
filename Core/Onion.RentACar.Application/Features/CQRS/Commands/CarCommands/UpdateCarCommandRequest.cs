using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateCarCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int CategoryId { get; set; }
        public string? Age { get; set; }
        public int Price { get; set; }
    }
}
