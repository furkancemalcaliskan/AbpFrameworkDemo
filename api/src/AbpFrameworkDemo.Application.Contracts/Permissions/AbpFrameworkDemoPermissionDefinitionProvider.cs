using AbpFrameworkDemo.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpFrameworkDemo.Application.Contracts.Permissions;

public class AbpFrameworkDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpFrameworkDemoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpFrameworkDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpFrameworkDemoResource>(name);
    }
}
