namespace HRM.Infrastructure
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {

        private readonly DatabaseContext _dbContext;
        public BaseRepository(DatabaseContext databaseContext) 
        { 
            _dbContext = databaseContext;
        }
        public virtual IQueryable<T> All()
        { 
            IQueryable<T> query = _dbContext.Set<T>();
            return query;
        }
        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }
        public virtual void AddRange(List<T> values)
        { 
            _dbContext.Set<T>().AddRange(values);
        }
        public virtual void Delete(T entity) 
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
        }
    }
}
