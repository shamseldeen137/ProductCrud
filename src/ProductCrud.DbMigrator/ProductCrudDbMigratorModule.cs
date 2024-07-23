using ProductCrud.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ProductCrud.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProductCrudEntityFrameworkCoreModule),
    typeof(ProductCrudApplicationContractsModule)
    )]
public class ProductCrudDbMigratorModule : AbpModule
{
}
