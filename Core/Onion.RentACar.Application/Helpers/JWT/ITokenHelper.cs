using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Helpers.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AppUser appUser, List<AppRole> appRoles);
    }
}
