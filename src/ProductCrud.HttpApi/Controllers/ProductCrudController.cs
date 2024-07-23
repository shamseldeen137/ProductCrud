using ProductCrud.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ProductCrud.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProductCrudController : AbpControllerBase
{
    protected ProductCrudController()
    {
        LocalizationResource = typeof(ProductCrudResource);
    }
}
