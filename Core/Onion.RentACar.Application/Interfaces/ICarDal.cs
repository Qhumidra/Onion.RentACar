using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Interfaces
{
    public interface ICarDal : IRepositoryBase<Car>
    {
        public Task<List<CarListDto>> GetList();
        public Task<List<CarListDto>> GetByCategory(int id);

    }
   
}
