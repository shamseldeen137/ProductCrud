using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ProductCrud
{
    public interface IProductService : IApplicationService
    {

        Task<List<ProductDto>> GetListAsync();
        Task<ProductDto> GetProduct(int id);
        Task<ProductDto> CreateAsync(CreateProductDto product);
        Task<ProductDto> Update(ProductDto product);
        Task DeleteAsync(int id);

    }
}
