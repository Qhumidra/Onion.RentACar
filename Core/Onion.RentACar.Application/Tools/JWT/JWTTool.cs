using Onion.RentACar.Application.Helpers.JWT;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Tools.JWT
{
    public static class JWTTool
    {
        public static AccessToken CreateAccessToken(AppUser user, ITokenHelper tokenHelper, IUserDal userDal)
        {
            var claims = userDal.GetClaims(user);
            var accessToken = tokenHelper.CreateToken(user, claims);
            return accessToken;
        }
    }
}
