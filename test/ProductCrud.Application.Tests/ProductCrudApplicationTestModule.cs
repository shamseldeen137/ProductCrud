using Volo.Abp.Modularity;

namespace ProductCrud;

[DependsOn(
    typeof(ProductCrudApplicationModule),
    typeof(ProductCrudDomainTestModule)
)]
public class ProductCrudApplicationTestModule : AbpModule
{

}
