using Microsoft.EntityFrameworkCore;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Domain.Entities;
using System.Linq.Expressions;
namespace Onion.RentACar.Persistence.Repositories
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext, new()
    {

        public async Task<int> CommitAsync()
        {
            using (var _context = new TContext())
            {
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<TEntity?> CreateAsync(TEntity entity)
        {
            using (var _context = new TContext())
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using (var _context = new TContext())
            {
                return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<TEntity?> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var _context = new TContext())
            {
                return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<TEntity?> GetByIdAsync(object id)
        {
            using (var _context = new TContext())
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
        }
        public async Task Remove(TEntity entity)
        {
            using (var _context = new TContext())
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var _context = new TContext())
            {
                var updatedEntity = _context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
