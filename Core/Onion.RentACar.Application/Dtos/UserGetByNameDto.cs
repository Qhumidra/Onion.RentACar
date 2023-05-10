namespace Onion.RentACar.Application.Dtos
{
    public class UserGetByNameDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Sokak { get; set; }
        public string? Mahalle { get; set; }
        public string? Ilce { get; set; }
        public string? Il { get; set; }
        public string? AdresNotu { get; set; }
    }
}
