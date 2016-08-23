using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">entity type</typeparam>
    /// <typeparam name="V">id type</typeparam>
    public interface IService<T, V>
    {
        void Insert(T entity, bool isActive = true);
        void Update(T entity);
        void Delete(V id);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, bool isActive = true);
        IQueryable<T> GetAsync();
    }
}
