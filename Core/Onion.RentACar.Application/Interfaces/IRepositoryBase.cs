using Onion.RentACar.Domain.Entities;
using System.Linq.Expressions;

namespace Onion.RentACar.Application.Interfaces
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<int> CommitAsync();
        Task<T?> CreateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetByIdAsync(object id);
        Task Remove(T entity);
        Task UpdateAsync(T entity);
    }
}
