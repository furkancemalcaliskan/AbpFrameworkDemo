using AbpFrameworkDemo.Application;
using Volo.Abp.Modularity;

namespace AbpFrameworkDemo;

[DependsOn(
    typeof(AbpFrameworkDemoApplicationModule),
    typeof(AbpFrameworkDemoDomainTestModule)
)]
public class AbpFrameworkDemoApplicationTestModule : AbpModule
{

}
