using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
