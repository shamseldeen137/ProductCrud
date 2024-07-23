using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ProductCrud.Product
{
    public interface IProductRepo : IRepository<Product, int>
    {
        Task<Product> GetById(int Id);
        Task<Product> Create(Product product);
       Product Update(Product product);
        Task Delete(int Id);
        Task<IQueryable< Product> > GetAllProducts();
    }
}

