using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Domain.Entities;
using Onion.RentACar.Persistence.Context;

namespace Onion.RentACar.Persistence.Repositories
{
    public class CategoryDal : RepositoryBase<Category, RentACarDbContext>, ICategoryDal
    {

    }
}
