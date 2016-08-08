using System;
using System.Linq;
using System.Runtime.InteropServices;
using ServiceInterfaces;

namespace ServiceImplementations
{
    public abstract class BaseService<T,V>
    {
        public void InsertAsync(T entity)
        {
            
        }

        void Insert(T entity)
        {
            
        }

        void UpdateAync(T entity)
        {
            
        }

        void Update(T entity)
        {
            
        }

        void DeleteAsync(V id)
        {
            
        }

        void Delete(V id)
        {
            
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
