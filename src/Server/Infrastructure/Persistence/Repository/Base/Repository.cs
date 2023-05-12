using System.Linq.Expressions;
using Application.Interfaces.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext Context;
        protected DbSet<T> Entity => Context.Set<T>();
        public Repository(DbContext context)
        {
            Context = context;
        }

        #region Create
        public int Create(T entity)
        {
            Entity.Add(entity);
            return this.Save();
        }

        public int Create(IEnumerable<T> entity)
        {
            Entity.AddRange(entity);
            return this.Save();
        }

        public async Task<int> CreateAsync(T entity)
        {
            await Entity.AddAsync(entity);
            return await this.SaveAsync();
        }

        public async Task<int> CreateAsync(IEnumerable<T> entity)
        {
            await Entity.AddRangeAsync(entity);
            return await this.SaveAsync();
        }
        #endregion

        #region Delete
        public int Delete(T entity)
        {
            Entity.Remove(entity);
            return this.Save();
        }
        public int Delete(Guid id)
        {
            return this.Delete(Entity.Find(id));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await this.DeleteAsync(await Entity.FindAsync(id));
        }

        public async Task<int> DeleteAsync(T entity)
        {
            Entity.Remove(entity);
            return await this.SaveAsync();
        }

        public int DeleteRange(Expression<Func<T, bool>> filter)
        {
            Context.RemoveRange(Entity.Where(filter));
            return Save();
        }

        public async Task<int> DeleteRangeAsync(Expression<Func<T, bool>> filter)
        {
            Context.RemoveRange(Entity.Where(filter));
            return await SaveAsync();
        }
        #endregion

        #region GetAll
        public IList<T> GetAll(bool tracking = false)
        {
            var entity = this.AsQueryable();
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.ToList();
        }
        public IList<T> GetAll(bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.ToList();
        }
        public IList<T> GetAll(int count, bool tracking = false)
        {
            var entity = this.AsQueryable();
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.Take(count).ToList();
        }

        public IList<T> GetAll(int count, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.Take(count).ToList();
        }
        public IList<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = false)
        {
            var entity = this.AsQueryable();
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.ToList();
        }
        public IList<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.ToList();
        }
        public IList<T> GetAll(Expression<Func<T, bool>> filter, int count, bool tracking = false)
        {
            var entity = this.AsQueryable();
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.Take(count).ToList();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> filter, int count, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.Take(count).ToList();
        }
        public async Task<IList<T>> GetAllAsync(bool tracking = false)
        {
            var entity = this.AsQueryable();
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.ToListAsync();
        }
        public async Task<IList<T>> GetAllAsync(bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.ToListAsync();
        }
        public async Task<IList<T>> GetAllAsync(int count, bool tracking = false)
        {
            var entity = this.AsQueryable();
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.Take(count).ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(int count, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.Take(count).ToListAsync();
        }
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool tracking = false)
        {
            var entity = this.AsQueryable();
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.ToListAsync();
        }
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, int count, bool tracking = false)
        {
            var entity = this.AsQueryable();
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.Take(count).ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, int count, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.Take(count).ToListAsync();
        }
        #endregion

        #region GetOne
        public T GetOne(Guid id)
        {
            return Entity.Find(id);
        }

        public T GetOne(Guid id, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            return entity.SingleOrDefault(e => e.Id == id);
        }
        public T GetOne(Expression<Func<T, bool>> filter)
        {
            return Entity.FirstOrDefault(filter);
        }

        public T GetOne(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            return entity.FirstOrDefault(filter);
        }
        public async Task<T> GetOneAsync(Guid id)
        {
            return await Entity.FindAsync(id);
        }
        public async Task<T> GetOneAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            return await entity.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter)
        {
            return await Entity.FirstOrDefaultAsync(filter);
        }


        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = ApplyIncludes(entity, includes);
            return await entity.FirstOrDefaultAsync(filter);
        }

        #endregion

        #region Update
        public int Update(T entity)
        {
            Entity.Update(entity);
            return Save();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            Entity.Update(entity);
            return await SaveAsync();
        }
        #endregion

        #region Have
        public async Task<bool> HaveAsync(Expression<Func<T, bool>> filter)
        {
            return await Entity.Where(filter).AnyAsync();
        }

        public bool Have(Expression<Func<T, bool>> filter)
        {
            return Entity.Where(filter).Any();
        }
        #endregion

        protected int Save() => Context.SaveChanges();
        protected async Task<int> SaveAsync() => await Context.SaveChangesAsync();
        public IQueryable<T> AsQueryable() => Entity.AsQueryable();
        private IQueryable<T> ApplyIncludes(IQueryable<T> entity, params Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
                foreach (var include in includes)
                {
                    entity = entity.Include(include);
                }
            return entity;
        }


    }
}