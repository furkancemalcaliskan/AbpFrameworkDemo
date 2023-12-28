using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AbpFrameworkDemo.AuthServer;

[Dependency(ReplaceServices = true)]
public class AbpFrameworkDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpFrameworkDemo";
}
