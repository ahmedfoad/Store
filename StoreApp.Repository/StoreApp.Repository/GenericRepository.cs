using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Context;

namespace StoreApp.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly StoreDBContext dbContext;
        private readonly DbSet<T> dbSet;
        private StoreDBContext dbContext1;

        public GenericRepository(StoreDBContext _dbContext)
        {
            dbContext = _dbContext;
            dbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return  dbSet.ToList();
        }

        public  T Find(int id)
        {
            return  dbSet.Find(id);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public  bool Any(int id)
        {
            var temp= dbSet.Find(id);
            return (temp != null) ? true : false;
        }
    }
}
