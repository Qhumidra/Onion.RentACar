using MediatR;
using Onion.RentACar.Application.Dtos;

namespace Onion.RentACar.Application.Features.CQRS.Commands.RentCommands
{
    public class CreateRentCommandRequest : IRequest<RentCreateDto>
    {
        public int AppUserId { get; set; }
        public int CarId { get; set; }
        public string? PaymentType { get; set; }
        public int Price { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int StatusId { get; set; }
    }
}
