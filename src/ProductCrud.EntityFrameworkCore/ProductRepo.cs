using Microsoft.EntityFrameworkCore;
using ProductCrud.EntityFrameworkCore;
using ProductCrud.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ProductCrud
{
    public class ProductRepo : EfCoreRepository<ProductCrudDbContext, Product.Product, int>, IProductRepo
    {
        private readonly ProductCrudDbContext _db;
        public ProductRepo(ProductCrudDbContext db, IDbContextProvider<ProductCrudDbContext> dbContextProvider)
       : base(dbContextProvider)
        {
            _db = db;
        }
        public async Task<Product.Product> Create(Product.Product product)
        {
            await _db.Products.AddAsync(product);
            _db.SaveChanges();
            return product;
        }

        public async Task Delete(int Id)
        {
            var dbSet = await GetDbSetAsync();
            var product= await dbSet.FirstOrDefaultAsync(P => P.Id == Id);
         
             dbSet.Remove(product);
            await _db.SaveChangesAsync();


        }

        public async Task<IQueryable<Product.Product>> GetAllProducts()
        {
            var dbSet = await GetDbSetAsync();

            return dbSet;
        }

        public async Task<Product.Product> GetById(int Id)
        {
            var dbSet = await GetDbSetAsync();

            return dbSet.FirstOrDefault(a=>a.Id==Id);
        }

        public Product.Product Update(Product.Product product)
        {
             _db.Products.Update(product);
            _db.SaveChanges();
            return product;
        }
    }
}
