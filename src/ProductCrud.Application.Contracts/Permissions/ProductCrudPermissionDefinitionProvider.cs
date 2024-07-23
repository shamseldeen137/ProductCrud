using ProductCrud.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProductCrud.Permissions;

public class ProductCrudPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProductCrudPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ProductCrudPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductCrudResource>(name);
    }
}
