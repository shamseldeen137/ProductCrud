using Xunit;

namespace ProductCrud.EntityFrameworkCore;

[CollectionDefinition(ProductCrudTestConsts.CollectionDefinitionName)]
public class ProductCrudEntityFrameworkCoreCollection : ICollectionFixture<ProductCrudEntityFrameworkCoreFixture>
{

}
