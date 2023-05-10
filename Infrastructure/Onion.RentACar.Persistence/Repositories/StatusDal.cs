using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Domain.Entities;
using Onion.RentACar.Persistence.Context;

namespace Onion.RentACar.Persistence.Repositories
{
    public class StatusDal : RepositoryBase<Status, RentACarDbContext>, IStatusDal
    {

    }
}
