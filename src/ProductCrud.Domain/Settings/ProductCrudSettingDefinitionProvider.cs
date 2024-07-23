using Volo.Abp.Settings;

namespace ProductCrud.Settings;

public class ProductCrudSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ProductCrudSettings.MySetting1));
    }
}
