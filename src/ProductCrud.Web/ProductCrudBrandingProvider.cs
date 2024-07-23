using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ProductCrud.Web;

[Dependency(ReplaceServices = true)]
public class ProductCrudBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ProductCrud";
}
