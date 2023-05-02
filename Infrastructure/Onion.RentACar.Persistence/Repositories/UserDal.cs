using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Domain.Entities;
using Onion.RentACar.Persistence.Context;

namespace Onion.RentACar.Persistence.Repositories
{
    public class UserDal : RepositoryBase<AppUser, RentACarDbContext>, IUserDal
    {
        public List<AppRole> GetClaims(AppUser user)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from appRole in context.AppRoles
                             join appUserRole in context.AppUserRoles
                                 on appRole.Id equals appUserRole.AppRoleId
                             where appUserRole.AppUserId == user.Id
                             select new AppRole { Id = appRole.Id, Name = appRole.Name };

                return result.ToList();
            }
        }
    }
}
