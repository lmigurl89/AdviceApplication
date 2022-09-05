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
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IUnitOfWork repositories, IBaseRepository<TEntity> baseRepository)
        {
            _repositories = repositories;
            _baseRepository = baseRepository;
        }

        public virtual async Task<EntityEntry<TEntity>> AddAsync(TEntity entity) => await _baseRepository.AddAsync(entity);
        public virtual EntityEntry<TEntity> Delete(TEntity entity) => _baseRepository.Remove(entity);
        public virtual async Task<int> SaveChangesAsync() => await _baseRepository.SaveChangesAsync();
        public virtual EntityEntry<TEntity> Update(TEntity entity) => _baseRepository.Update(entity);
        public virtual void UpdateRange(List<TEntity> entities) => _baseRepository.UpdateRange(entities);
        public virtual async Task<TEntity?> FindByIdAsync(int id) => await _baseRepository.GetByIdAsync(id);
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _baseRepository.GetAllAsync();
        public virtual async Task<(IEnumerable<TEntity>, int)> GetPagedListAsync(int skipCount, int? maxResultCount, params Expression<Func<TEntity, bool>>[] filters)
        {
            IQueryable<TEntity> query = _baseRepository.GetQuery();

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