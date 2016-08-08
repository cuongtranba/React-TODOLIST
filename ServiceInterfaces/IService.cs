using System;
using System.Linq;
using System.Threading.Tasks;
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
        Task InsertAsync(T entity);
        void Insert(T entity);
        Task UpdateAync(T entity);
        void Update(T entity);
        Task DeleteAsync(V id);
        void Delete(V id);
        IQueryable<T> Get();
        IQueryable<T> GetAsync();
    }
}
