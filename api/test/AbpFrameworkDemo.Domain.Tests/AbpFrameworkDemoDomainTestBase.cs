using Volo.Abp.Modularity;

namespace AbpFrameworkDemo;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpFrameworkDemoDomainTestBase<TStartupModule> : AbpFrameworkDemoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
