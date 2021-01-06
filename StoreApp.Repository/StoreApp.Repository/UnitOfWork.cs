using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StoreApp.Data.Context;
using StoreApp.Repository.ModelRepository;
using StoreApp.Repository.ModelRepository.Product;

namespace StoreApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDBContext dbContext;

        public ProductRepository ProductRepository { get; }

        public UnitOfWork(StoreDBContext _dbContext)
        {
            this.dbContext = _dbContext;

            //Inject Product
            ProductRepository = new ProductRepository(dbContext);
        }
        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
