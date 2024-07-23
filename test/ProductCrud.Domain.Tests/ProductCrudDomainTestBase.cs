using Volo.Abp.Modularity;

namespace ProductCrud;

/* Inherit from this class for your domain layer tests. */
public abstract class ProductCrudDomainTestBase<TStartupModule> : ProductCrudTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
