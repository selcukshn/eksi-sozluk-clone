using System.Linq.Expressions;
using Domain;

namespace Application.Interfaces.Repository
{
    public interface IRepository<T> : IBaseRepository
    where T : BaseEntity
    {
        Task<bool> HaveAsync(Expression<Func<T, bool>> filter);
        bool Have(Expression<Func<T, bool>> filter);

        Task<T> GetOneAsync(Guid id);
        Task<T> GetOneAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        T GetOne(Guid id);
        T GetOne(Guid id, params Expression<Func<T, object>>[] includes);
        T GetOne(Expression<Func<T, bool>> filter);
        T GetOne(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);


        Task<IList<T>> GetAllAsync(bool tracking = false);
        Task<IList<T>> GetAllAsync(bool tracking = false, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetAllAsync(int count, bool tracking = false);
        Task<IList<T>> GetAllAsync(int count, bool tracking = false, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool tracking = false);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool tracking = false, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, int count, bool tracking = false);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, int count, bool tracking = false, params Expression<Func<T, object>>[] includes);
        IList<T> GetAll(bool tracking = false);
        IList<T> GetAll(bool tracking = false, params Expression<Func<T, object>>[] includes);
        IList<T> GetAll(int count, bool tracking = false);
        IList<T> GetAll(int count, bool tracking = false, params Expression<Func<T, object>>[] includes);
        IList<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = false);
        IList<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = false, params Expression<Func<T, object>>[] includes);
        IList<T> GetAll(Expression<Func<T, bool>> filter, int count, bool tracking = false);
        IList<T> GetAll(Expression<Func<T, bool>> filter, int count, bool tracking = false, params Expression<Func<T, object>>[] includes);

        Task<int> CreateAsync(T entity);
        Task<int> CreateAsync(IEnumerable<T> entities);
        int Create(T entity);
        int Create(IEnumerable<T> entities);


        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(T entity);
        int Delete(Guid id);
        int Delete(T entity);
        Task<int> DeleteRangeAsync(Expression<Func<T, bool>> filter);
        int DeleteRange(Expression<Func<T, bool>> filter);


        Task<int> UpdateAsync(T entity);
        int Update(T entity);


        IQueryable<T> AsQueryable();
    }
}