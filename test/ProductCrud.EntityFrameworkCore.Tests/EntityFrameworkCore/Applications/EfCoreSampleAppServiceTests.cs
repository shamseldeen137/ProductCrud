using ProductCrud.Samples;
using Xunit;

namespace ProductCrud.EntityFrameworkCore.Applications;

[Collection(ProductCrudTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ProductCrudEntityFrameworkCoreTestModule>
{

}
