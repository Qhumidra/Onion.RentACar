using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Interfaces
{
    public interface IUserDal : IRepositoryBase<AppUser>
    {
        List<AppRole> GetClaims(AppUser user);
    }
}
