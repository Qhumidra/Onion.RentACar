namespace Onion.RentACar.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Sokak { get; set; }
        public string? Mahalle { get; set; }
        public string? Ilce { get; set; }
        public string? Il { get; set; }
        public string? AdresNotu { get; set; }
        public bool Status { get; set; }

    }
}
