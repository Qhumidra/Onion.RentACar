using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Interfaces
{
    public interface IRentListDal : IRepositoryBase<RentList>
    {
        Task<List<RentListDto>> GetList();
        Task<List<RentListDto>> GetByCategory(int id);
    }
}
