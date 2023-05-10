namespace Onion.RentACar.Application.Dtos
{
    public class RentCreateDto
    {
        public int AppUserId { get; set; }
        public int CarId { get; set; }
        public string? PaymentType { get; set; }
        public int Price { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
