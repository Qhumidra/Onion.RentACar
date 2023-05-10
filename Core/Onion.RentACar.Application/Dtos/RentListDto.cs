namespace Onion.RentACar.Application.Dtos
{
    public class RentListDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? PaymentType { get; set; }
        public int Price { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? Status { get; set; }
    }
}
