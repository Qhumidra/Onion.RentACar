namespace Onion.RentACar.Domain.Entities
{
    public class RentList : BaseEntity
    {
        public int CustomerId { get; set; }
        public int AppUserId { get; set; }
        public int CarId { get; set; }
        public string? PaymentType { get; set; }
        public int Price { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
