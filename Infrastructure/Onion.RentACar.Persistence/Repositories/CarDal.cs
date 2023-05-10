using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Domain.Entities;
using Onion.RentACar.Persistence.Context;

namespace Onion.RentACar.Persistence.Repositories
{
    public class CarDal : RepositoryBase<Car, RentACarDbContext>, ICarDal
    {
        public async Task<List<CarListDto>> GetList()
        {
            using (var context = new RentACarDbContext())
            {
                var result = from car in context.Cars
                             join category in context.Categories
                             on car.CategoryId equals category.Id
                             select new CarListDto
                             {
                                 Id = car.Id,
                                 Brand = car.Brand,
                                 Model = car.Model,
                                 Description = category.Description,
                                 Age = car.Age,
                                 Price = car.Price,
                                 imgPath = car.imgPath
                             };

                return result.ToList();
            }
        }

        public async Task<List<CarListDto>> GetByCategory(int id)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from car in context.Cars
                             join category in context.Categories
                             on car.CategoryId equals category.Id
                             where car.CategoryId == id
                             select new CarListDto
                             {
                                 Id = car.Id,
                                 Brand = car.Brand,
                                 Model = car.Model,
                                 Description = category.Description,
                                 Age = car.Age,
                                 Price = car.Price,
                                 imgPath = car.imgPath
                             };

                return result.ToList();
            }
        }
    }
}
