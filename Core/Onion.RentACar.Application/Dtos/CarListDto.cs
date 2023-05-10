namespace Onion.RentACar.Application.Dtos
{
    public class CarListDto
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public string? Age { get; set; }
        public int Price { get; set; }
        public string? imgPath { get; set; }
    }
}
