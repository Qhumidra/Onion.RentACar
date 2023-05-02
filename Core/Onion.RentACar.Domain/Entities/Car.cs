namespace Onion.RentACar.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Class { get; set; }
        public string? Age { get; set; }
        public int Price { get; set; }
    }
}
