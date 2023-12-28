using AbpFrameworkDemo.Application.Contracts;
using AbpFrameworkDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Modularity;

namespace AbpFrameworkDemo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpFrameworkDemoEntityFrameworkCoreModule),
    typeof(AbpFrameworkDemoApplicationContractsModule)
    )]
public class AbpFrameworkDemoDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "AbpFrameworkDemo:"; });
    }
}
