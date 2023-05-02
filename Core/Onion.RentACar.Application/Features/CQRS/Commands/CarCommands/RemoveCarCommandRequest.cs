using MediatR;

namespace Onion.RentACar.Application.Features.CQRS.Commands.CarCommands
{
    public class RemoveCarCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveCarCommandRequest(int id)
        {
            Id = id;
        }
    }
}
