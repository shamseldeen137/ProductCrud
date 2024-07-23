using System.Threading.Tasks;

namespace ProductCrud.Data;

public interface IProductCrudDbSchemaMigrator
{
    Task MigrateAsync();
}
