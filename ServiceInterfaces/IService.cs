using System;
using System.Linq;
using Domain;

namespace ServiceInterfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">entity type</typeparam>
    /// <typeparam name="V">id type</typeparam>
    public interface IService<T, V>
    {
        void InsertAsync(T entity);
        void Insert(T entity);
        void UpdateAync(T entity);
        void Update(T entity);
        void DeleteAsync(V id);
        void Delete(V id);
        IQueryable<T> Get();
        IQueryable<T> GetAsync();
    }
}
