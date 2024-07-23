using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductCrud.Product
{
    public class ProductServiceIntegrationTests : IClassFixture<CustomWebApplicationFactory<ProductCrud.Web.Program>>
    {
        private readonly HttpClient _client;

        public ProductServiceIntegrationTests(CustomWebApplicationFactory<ProductCrud.Web.Program> factory)
        {
            _client = factory.CreateClient();
        }
       
        [Fact]
        public async Task GetProduct_Returns_Product_When_Product_Exists()
        {
            // Arrange
            var productId = 1;
            var requestUri = $"/api/products/{productId}";

            // Act
            var response = await _client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDto>(responseString);

            // Assert
            Assert.NotNull(product);
            Assert.Equal(productId, product.Id);
        }

        [Fact]
        public async Task GetProduct_Returns_NorFound_When_Product_Not_Exists()
        {
            // Arrange
            var productId = 10;
            var requestUri = $"/api/products/{productId}";

            // Act
            var response = await _client.GetAsync(requestUri);
            

            var responseString = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDto>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            //Assert.Equal(productId, exception.Data["ProductId"]);
        }
        [Fact]
        public async Task CreateProduct_Creates_Product_Successfully()
        {
            // Arrange
            var productDto = new ProductDto { Name = "New Product", Price = 200, Description = "desc" };
            var requestContent = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/products", requestContent);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<ProductDto>(responseString);

            // Assert
            Assert.NotNull(createdProduct);
            Assert.Equal("New Product", createdProduct.Name);
        }

        [Fact]
        public async Task CreateProduct_Error_EmptyName()
        {
            // Arrange
            var productDto = new ProductDto { Name = "", Price = 200, Description = "desc" };
            var requestContent = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/products", requestContent);

            var responseString = await response.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<ProductDto>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task CreateProduct_Error_NegativePrice()
        {
            // Arrange
            var productDto = new ProductDto { Name = "test", Price = -200, Description = "desc" };
            var requestContent = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/products", requestContent);

            var responseString = await response.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<ProductDto>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task DeleteProduct_Error_NotFound()
        {
            // Arrange
            int id = 10;
            // Act
            var response = await _client.DeleteAsync("/api/products/"+id);

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


        [Fact]
        public async Task DeleteProduct_Success()
        {
            // Arrange
            int id = 1;
            // Act
            var response = await _client.DeleteAsync("/api/products/" + id);

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
