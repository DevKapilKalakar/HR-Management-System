using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> All(); 
        void Add(T entity); 
        void AddRange(List<T> entities);
        void Update(T entity);
        void Delete(T entity);
    }
}
