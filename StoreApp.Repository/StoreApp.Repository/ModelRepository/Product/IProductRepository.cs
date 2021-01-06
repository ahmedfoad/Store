using System;
using System.Collections.Generic;
using System.Text;


namespace StoreApp.Repository.ModelRepository.Product
{
    public interface IProductRepository
    {
        IEnumerable<Data.Models.Product> GetAll();
        Data.Models.Product Find(int id);
        void Add(Data.Models.Product entity);
        void Update(Data.Models.Product entity);
        void Delete(Data.Models.Product entity);
    }
}
