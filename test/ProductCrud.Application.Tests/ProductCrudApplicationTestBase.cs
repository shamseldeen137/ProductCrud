using Volo.Abp.Modularity;

namespace ProductCrud;

public abstract class ProductCrudApplicationTestBase<TStartupModule> : ProductCrudTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
