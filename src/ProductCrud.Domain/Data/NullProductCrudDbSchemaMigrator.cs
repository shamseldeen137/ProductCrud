using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ProductCrud.Data;

/* This is used if database provider does't define
 * IProductCrudDbSchemaMigrator implementation.
 */
public class NullProductCrudDbSchemaMigrator : IProductCrudDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
