using ProductCrud.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ProductCrud.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ProductCrudPageModel : AbpPageModel
{
    protected ProductCrudPageModel()
    {
        LocalizationResourceType = typeof(ProductCrudResource);
    }
}
