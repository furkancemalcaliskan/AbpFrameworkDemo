using AbpFrameworkDemo.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpFrameworkDemo.Application.Contracts.Permissions;

public class AbpFrameworkDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
	public override void Define(IPermissionDefinitionContext context)
	{
		var abpFrameworkDemoGroup = context.AddGroup(AbpFrameworkDemoPermissions.GroupName, L("Permission:AbpFrameworkDemo"));

		var booksPermission = abpFrameworkDemoGroup.AddPermission(AbpFrameworkDemoPermissions.Books.Default, L("Permission:Books"));
		booksPermission.AddChild(AbpFrameworkDemoPermissions.Books.Create, L("Permission:Books.Create"));
		booksPermission.AddChild(AbpFrameworkDemoPermissions.Books.Edit, L("Permission:Books.Edit"));
		booksPermission.AddChild(AbpFrameworkDemoPermissions.Books.Delete, L("Permission:Books.Delete"));

		var authorsPermission = abpFrameworkDemoGroup.AddPermission(AbpFrameworkDemoPermissions.Authors.Default, L("Permission:Authors"));
		authorsPermission.AddChild(AbpFrameworkDemoPermissions.Authors.Create, L("Permission:Authors.Create"));
		authorsPermission.AddChild(AbpFrameworkDemoPermissions.Authors.Edit, L("Permission:Authors.Edit"));
		authorsPermission.AddChild(AbpFrameworkDemoPermissions.Authors.Delete, L("Permission:Authors.Delete"));

	}

	private static LocalizableString L(string name)
	{
		return LocalizableString.Create<AbpFrameworkDemoResource>(name);
	}
}
