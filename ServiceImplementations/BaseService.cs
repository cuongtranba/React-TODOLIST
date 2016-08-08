using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceImplementations
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"> entity type </typeparam>
    /// <typeparam name="V"> id type </typeparam>
    public abstract class BaseService<T,V>
    {
        public async Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(V id)
        {
            throw new NotImplementedException();
        }

        public void Delete(V id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
