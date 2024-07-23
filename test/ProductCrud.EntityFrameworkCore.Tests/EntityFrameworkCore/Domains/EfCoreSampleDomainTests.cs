using ProductCrud.Samples;
using Xunit;

namespace ProductCrud.EntityFrameworkCore.Domains;

[Collection(ProductCrudTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ProductCrudEntityFrameworkCoreTestModule>
{

}
