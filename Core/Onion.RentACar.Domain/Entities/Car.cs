namespace Onion.RentACar.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int CategoryId { get; set; }
        public string? Age { get; set; }
        public int Price { get; set; }
        public string? imgPath { get; set; }
    }
}
