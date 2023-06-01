using MediatR;

namespace Onion.RentACar.Application.Features.CQRS.Commands.RentCommands
{
    public class UpdateStatusRentCommandRequest : IRequest
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
    }
}
