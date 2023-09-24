namespace VMS.Persistence.BaseRepo
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        bool Add(TEntity entity);
        bool Delete(long id);
        Task<bool> DeleteAsync(long id);
        bool Delete(int id);
        bool Update(TEntity entity);

        //IList<TEntity>GetAll();
        Task<IEnumerable<TEntity>> GetAllEnumerableAsync();
        IList<TEntity> GetAll();       
        Task<IList<TEntity>> GetAllAsync();
        TEntity GetByid(long id);
        TEntity GetByidint(int id);
        Task<TEntity> GetByidAsync(long id);
        //Task< TEntity> GetAllByidAsync(int id);
        Task<bool> AddRangeAsync(List<TEntity> ListModel);
    }
}
