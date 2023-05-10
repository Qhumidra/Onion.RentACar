using MediatR;

namespace Onion.RentACar.Application.Features.CQRS.Commands.RentCommands
{
    public class UpdateRentCommandRequest : IRequest
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int CarId { get; set; }
        public string? PaymentType { get; set; }
        public int Price { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int StatusId { get; set; }
    }
}
