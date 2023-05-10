using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Domain.Entities;
using Onion.RentACar.Persistence.Context;

namespace Onion.RentACar.Persistence.Repositories
{
    public class RentListDal : RepositoryBase<RentList, RentACarDbContext>, IRentListDal
    {
        public async Task<List<RentListDto>> GetList()
        {
            using (var context = new RentACarDbContext())
            {
                var result = from rentList in context.RentList
                             join car in context.Cars
                             on rentList.CarId equals car.Id
                             join user in context.AppUsers
                             on rentList.AppUserId equals user.Id
                             join status in context.Status
                             on rentList.StatusId equals status.Id
                             select new RentListDto
                             {
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 Brand = car.Brand,
                                 Model = car.Model,
                                 PaymentType = rentList.PaymentType,
                                 Price = rentList.Price,
                                 IssueDate = rentList.IssueDate,
                                 PurchaseDate = rentList.PurchaseDate,
                                 Status = status.Name
                             };

                return result.ToList();
            }
        }


        public async Task<List<RentListDto>> GetByCategory(int id)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from rentList in context.RentList
                             join car in context.Cars
                             on rentList.CarId equals car.Id
                             join user in context.AppUsers
                             on rentList.AppUserId equals user.Id
                             join status in context.Status
                             on rentList.StatusId equals status.Id
                             where rentList.StatusId == id
                             select new RentListDto
                             {
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 Brand = car.Brand,
                                 Model = car.Model,
                                 PaymentType = rentList.PaymentType,
                                 Price = rentList.Price,
                                 IssueDate = rentList.IssueDate,
                                 PurchaseDate = rentList.PurchaseDate,
                                 Status = status.Name
                             };

                return result.ToList();
            }
        }
    }
}