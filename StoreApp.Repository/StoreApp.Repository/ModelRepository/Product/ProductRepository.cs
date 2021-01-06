using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Context;

namespace StoreApp.Repository.ModelRepository.Product
{
    public class ProductRepository : GenericRepository<Data.Models.Product>, IProductRepository
    {
        private readonly StoreDBContext dbContext;
        public ProductRepository(StoreDBContext _dbContext) : base(_dbContext)
        {
            this.dbContext = _dbContext;
        }

        ////////public async Task<IEnumerable<Data.Models.Product>> _GetAll()
        ////////{
        ////////    var list = await dbContext.Products.ToListAsync();
        ////////    return list;
        ////////}

        ////////public async Task<Data.Models.Product> _Find(int id)
        ////////{
        ////////    return await dbContext.Products.FirstOrDefaultAsync(a => a.Id == id);
        ////////}

        ////////public async void _Add(Data.Models.Product entity)
        ////////{
        ////////    dbContext.Products.AddAsync(entity);
        ////////}

        ////////public void _Update(Data.Models.Product entity)
        ////////{
        ////////    dbContext.Products.Attach(entity).State = EntityState.Modified;

        ////////}

        ////////public async void _Delete(Data.Models.Product entity)
        ////////{
        ////////    dbContext.Products.Remove(entity);
        ////////    //await dbContext.SaveChangesAsync();
        ////////}

        ////////public async Task<bool>_Any(int id)
        ////////{
        ////////    return await dbContext.Products.AnyAsync(a=>a.Id == id);
        ////////}
    }
}
