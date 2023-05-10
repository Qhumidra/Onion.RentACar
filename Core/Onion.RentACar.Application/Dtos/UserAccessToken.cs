using Onion.RentACar.Application.Helpers.JWT;

namespace Onion.RentACar.Application.Dtos
{
    public class UserAccessToken : AccessToken
    {
        public string? Role { get; set; }
    }
}
