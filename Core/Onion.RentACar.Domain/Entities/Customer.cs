namespace Onion.RentACar.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public string? Street { get; set; }
        public string? Neighbourhood { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public string? AdressNote { get; set; }
    }
}
