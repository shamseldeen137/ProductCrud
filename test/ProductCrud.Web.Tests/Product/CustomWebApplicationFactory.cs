using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductCrud.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCrud.Product
{
    public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the app's DbContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ProductCrudDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add a database context (YourDbContext) using an in-memory database for testing.
                services.AddDbContext<ProductCrudDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                // Ensure the database is created.
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ProductCrudDbContext>();
                    db.Database.EnsureCreated();
                    SeedDatabase(db);
                }

            });
        }


        private void SeedDatabase(ProductCrudDbContext context)
        {
            // Seed the database with test data.
            context.Products.Add(new Product
            {
                Id = 1,
                Name = "Test Product",
                Price = 100,
                Description = "10"
            });

            context.SaveChanges();
        }
    }
}
