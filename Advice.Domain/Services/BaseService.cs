using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.Model;
using Advice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Reflection;

namespace Advice.Domain.Services
{
    public abstract class BaseService<TEntity> where TEntity : EntityBase
    {
        protected readonly IUnitOfWork _repositories;

        public BaseService(IUnitOfWork repositories)
        {
            _repositories = repositories;
        }

        public virtual async Task<EntityEntry<TEntity>> AddAsync(TEntity entity) => await _repositories.Context<TEntity>().AddAsync(entity);
        public virtual EntityEntry<TEntity> Delete(TEntity entity) => _repositories.Context<TEntity>().Remove(entity);
        public virtual async Task<int> SaveChangesAsync() => await _repositories.SaveChangesAsync();
        public virtual EntityEntry<TEntity> Update(TEntity entity) => _repositories.Context<TEntity>().Update(entity);
        public virtual void UpdateRange(List<TEntity> entities) => _repositories.Context<TEntity>().UpdateRange(entities);
        public virtual async Task<TEntity?> FindByIdAsync(int id) => await _repositories.Context<TEntity>().FirstOrDefaultAsync( entity=> entity.Id == id);
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _repositories.Context<TEntity>().ToListAsync();
        public virtual async Task<(IEnumerable<TEntity>, int)> GetPagedListAsync(int skipCount, int? maxResultCount, params Expression<Func<TEntity, bool>>[] filters)
        {
            IQueryable<TEntity> query = _repositories.Context<TEntity>();

            //Filtering
            filters.Aggregate(query, (current, filters) => current.Where(filters));
            //Counting
            int total = await query.CountAsync();
            //Paginating
            query = query.Skip(skipCount).Take(maxResultCount.GetValueOrDefault(total));

            return (await query.ToListAsync(), total);
        }
       
    }
}