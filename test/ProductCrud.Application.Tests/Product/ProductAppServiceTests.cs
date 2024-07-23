using Moq;
using NSubstitute;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Xunit;

namespace ProductCrud.Product;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IIdentityUserAppService here).
 * Only test your own application services.
 */
public  class ProductAppServiceTests 
{
    private readonly ProductService _productAppService;




    private readonly Mock<IProductRepo> _productRepositoryMock;
   // private readonly ProductCrudAppService _productAppService;

    public ProductAppServiceTests()
    {
        _productRepositoryMock = new Mock<IProductRepo>();
        _productAppService = new ProductService(_productRepositoryMock.Object);
    }

    [Fact]
    public async Task GetProductAsync_Should_Return_Product_When_Product_Exists()
    {
        // Arrange
        var productId = 1;
        var product = new Product { Id = productId, Name = "Test Product", Price = 100 };
        _productRepositoryMock.Setup(repo => repo.GetById(productId)).ReturnsAsync(product);

        // Act
        var result = await _productAppService.GetProduct(productId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(productId, result.Id);
        Assert.Equal("Test Product", result.Name);
    }



    [Fact]
    public async Task GetProductAsync_Should_Return_ProductNotFoundException_When_Product_Not_Exists()
    {
        // Arrange
        var productId = 100;
        var product = new Product { Id = productId, Name = "Test Product", Price = 100 };
        _productRepositoryMock.Setup(repo => repo.GetById(productId)).ReturnsAsync((Product)null);


        var exception = await Assert.ThrowsAsync<BusinessException>(() => _productAppService.GetProduct(productId));
        Assert.Equal("404", exception.Code);
        Assert.Equal(productId, exception.Data["ProductId"]);
    }

 

    [Fact]
    public async Task CreateProduct_With_Empty_Name_Should_Return_Exception()
    {
        //Act
      

        var product = new CreateProductDto
        {
            Description = string.Empty,
            Name = string.Empty,
            Price = 10
        };
        //Assert
        var exception = await Assert.ThrowsAsync<BusinessException>(() => _productAppService.CreateAsync(product));
        Assert.Equal("400", exception.Code);
        Assert.Equal(string.Empty, exception.Data["Name"]);

       
    }

    [Fact]
    public async Task CreateProduct_With_Negative_Price_Should_Return_Exception()
    {
        //Act


        var product = new CreateProductDto
        {
            Description = string.Empty,
            Name = "test",
            Price = -10
        };
        //Assert
        var exception = await Assert.ThrowsAsync<BusinessException>(() => _productAppService.CreateAsync(product));
        Assert.Equal("400", exception.Code);
        Assert.Equal(product.Price, exception.Data["Price"]);


    }



    [Fact]
    public async Task CreateProduct_Success()
    {
        //Act


        var CreateProductDto = new CreateProductDto
        {
            Description = "Test",
            Name = "test",
            Price = 10
        };
        var product = new Product
        {
            Description = CreateProductDto.Description,
            Name = CreateProductDto.Name,
            Price = CreateProductDto.Price
        };


        _productRepositoryMock.Setup(repo => repo.Create(It.IsAny<Product>())).ReturnsAsync(product);

        //Assert
        var result = await _productAppService.CreateAsync(CreateProductDto);

        Assert.NotNull(result);

      
        Assert.Equal(product.Name, result.Name);


    }





    [Fact]
    public async Task Delete_Should_Return_ProductNotFoundException_When_Product_Not_Exists()
    {
        // Arrange
        var productId = 100;
        var product = new Product { Id = productId, Name = "Test Product", Price = 100 };
        _productRepositoryMock.Setup(repo => repo.Delete(productId));


        var exception = await Assert.ThrowsAsync<BusinessException>(() => _productAppService.DeleteAsync(productId));
        Assert.Equal("404", exception.Code);
        Assert.Equal(productId, exception.Data["ProductId"]);
    }


    //[Fact]
    //public async Task Delete_Success()
    //{
    //    // Arrange
    //    var productId = 1;



    //    await _productAppService.DeleteAsync(productId);

    //    _productRepositoryMock.Setup(repo => repo.Delete(productId));



    //}


}
