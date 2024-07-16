﻿using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using System.Data.Entity;

namespace Net_React.Server.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ECommerceSampContext _context;
        public Repository(ECommerceSampContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id); 
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
