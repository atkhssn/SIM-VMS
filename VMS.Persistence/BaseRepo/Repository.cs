using Microsoft.EntityFrameworkCore;

namespace VMS.Persistence.BaseRepo
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public readonly DbContext _Context;
        public readonly DbSet<TEntity> _Entities;

        public Repository(DbContext context)
        {
            _Context = context;
            _Entities = _Context.Set<TEntity>();
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _Entities.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            _Entities.Attach(entity);

            try
            {
                _Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            var data = _Entities.Find(id);
            DelectEntity(data);

            return (data != null ? true : false);
        }

        public bool Delete(int id)
        {
            var data = _Entities.Find(id);
            DelectEntity(data);
            return (data != null ? true : false);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var data = await _Entities.FindAsync(id);
            DelectEntity(data);

            return (data != null ? true : false);
        }

        private void DelectEntity(TEntity entity)
        {
            if (_Context.Entry(entity).State == EntityState.Detached)
            {
                _Entities.Attach(entity);
                _Entities.Remove(entity);
            }
        }

        public IList<TEntity> GetAll()
        {
            IQueryable<TEntity> queryable = _Entities;
            return queryable.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllEnumerableAsync()
        {
            IEnumerable<TEntity> queryable = await _Entities.ToListAsync();
            return queryable;
        }

        public TEntity GetByid(long id)
        {
            var data = _Entities.Find(id);
            return data;
        }

        public TEntity GetByidint(int id)
        {
            var data = _Entities.Find(id);

            return data;
        }

        public async Task<TEntity> GetByidAsync(long id)
        {
            var data = await _Entities.FindAsync(id);

            return data;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> queryable = _Entities;
            return await queryable.ToListAsync();
        }

        public async Task<bool> AddRangeAsync(List<TEntity> ListModel)
        {
            try
            {
                await _Entities.AddRangeAsync(ListModel);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
