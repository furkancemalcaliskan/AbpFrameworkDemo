using AbpFrameworkDemo.Domain;
using Volo.Abp.Modularity;

namespace AbpFrameworkDemo;

[DependsOn(
    typeof(AbpFrameworkDemoDomainModule),
    typeof(AbpFrameworkDemoTestBaseModule)
)]
public class AbpFrameworkDemoDomainTestModule : AbpModule
{

}
