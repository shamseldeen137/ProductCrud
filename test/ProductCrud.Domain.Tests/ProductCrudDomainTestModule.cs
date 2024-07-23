using Volo.Abp.Modularity;

namespace ProductCrud;

[DependsOn(
    typeof(ProductCrudDomainModule),
    typeof(ProductCrudTestBaseModule)
)]
public class ProductCrudDomainTestModule : AbpModule
{

}
