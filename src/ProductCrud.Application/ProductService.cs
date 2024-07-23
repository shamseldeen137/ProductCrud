using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProductCrud.Product
{
    public class ProductService: ApplicationService, IProductService
    {
        private readonly IProductRepo _productRepository;

    public ProductService(IProductRepo productRepo)
    {
            _productRepository = productRepo;
    }
        
    
public async Task<ProductDto> CreateAsync(CreateProductDto product)
        {
            if (string.IsNullOrEmpty( product.Name))
            {
                throw new BusinessException("400").WithData("Name", product.Name);


            }  if (product.Price<=0)
            {
                throw new BusinessException("400").WithData("Price", product.Price);

            }
            var createdProduct = await _productRepository.Create(
         new Product {
             Name=product.Name,
             Description=product.Description,
             Price=product.Price,
         }
     );

            return new ProductDto
            {
                Id= createdProduct.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
        }

        public async Task<ProductDto> Update(ProductDto product)
        {
           var existedProduct=await _productRepository.GetById( product.Id );
            if (existedProduct == null)
            {
                throw new BusinessException("404").WithData("ProductId", product.Id);

            }
            existedProduct.Name = product.Name;
                existedProduct.Description = product.Description;
                existedProduct.Price = product.Price;

                    
            var todoItem =  _productRepository.Update(existedProduct);

   

            return product;
        }


        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                throw new BusinessException("404").WithData("ProductId", id);

            }
            await _productRepository.Delete(id);
        }  
        public async Task<ProductDto> GetProduct(int id)
        {
            var product=await _productRepository.GetById(id);
            if (product == null) {
                throw new BusinessException("404").WithData(  "ProductId" , id );
              
            }
                return new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                };
        
        }

        public async Task<List<ProductDto>> GetListAsync()
        {
            var items = await _productRepository.GetAllProducts();
            return items
                .Select(item => new ProductDto
                {
                    Id = item.Id,
                    Description = item.Description,
                    Name = item.Name,
                    Price = item.Price,

                }).ToList();
        }
    }
}
