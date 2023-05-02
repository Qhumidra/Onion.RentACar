namespace Onion.RentACar.Application.Helpers.JWT
{
    public class AccessToken
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
