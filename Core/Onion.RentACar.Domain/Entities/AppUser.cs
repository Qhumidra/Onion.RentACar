namespace Onion.RentACar.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
