using System;
using System.Collections.Generic;
using System.Text;
using ProductCrud.Localization;
using Volo.Abp.Application.Services;

namespace ProductCrud;

/* Inherit your application services from this class.
 */
public abstract class ProductCrudAppService : ApplicationService
{
    protected ProductCrudAppService()
    {
        LocalizationResource = typeof(ProductCrudResource);
    }
}
