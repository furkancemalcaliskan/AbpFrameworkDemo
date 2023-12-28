using Volo.Abp.Settings;

namespace AbpFrameworkDemo.Domain.Settings;

public class AbpFrameworkDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpFrameworkDemoSettings.MySetting1));
    }
}
