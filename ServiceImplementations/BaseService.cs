﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;
using Domain.Model;
using LiteDB;

namespace ServiceImplementations
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"> entity type </typeparam>
    /// <typeparam name="V"> id type </typeparam>
    public abstract class BaseService<T, V> where T : new()
    {
        private readonly LiteDatabase _liteDatabase;
        protected LiteCollection<T> collection;
        protected BaseService(LiteDatabase liteDatabase)
        {
            _liteDatabase = liteDatabase;
            collection = _liteDatabase.GetCollection<T>($"{typeof(T).Name.ToLower()}s");
        }

        public async Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity, bool isActive = true)
        {
            collection.Insert(entity);
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



        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, bool isActive = true)
        {
            return collection.Find(predicate);
        }

        public IQueryable<T> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
