using Volo.Abp.Modularity;

namespace AbpFrameworkDemo;

public abstract class AbpFrameworkDemoApplicationTestBase<TStartupModule> : AbpFrameworkDemoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
