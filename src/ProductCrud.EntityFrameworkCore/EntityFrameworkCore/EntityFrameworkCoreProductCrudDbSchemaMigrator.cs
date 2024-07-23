using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductCrud.Data;
using Volo.Abp.DependencyInjection;

namespace ProductCrud.EntityFrameworkCore;

public class EntityFrameworkCoreProductCrudDbSchemaMigrator
    : IProductCrudDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreProductCrudDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ProductCrudDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ProductCrudDbContext>()
            .Database
            .MigrateAsync();
    }
}
