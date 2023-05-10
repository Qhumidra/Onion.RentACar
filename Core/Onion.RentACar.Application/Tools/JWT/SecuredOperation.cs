using Onion.RentACar.Application.Utilities.JWT;
namespace Onion.RentACar.Application.Tools.JWT
{
    public static class SecuredOperation
    {
        public static bool Role(string roles)
        {
            string[] _roles = roles.Split(',');

            RoleQuery query = new RoleQuery();
            var result = query.Role(_roles);
            if (result)
            {
                return true;
            }
            return false;
        }
    }
}
