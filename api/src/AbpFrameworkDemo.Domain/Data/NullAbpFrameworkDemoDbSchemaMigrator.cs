using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpFrameworkDemo.Domain.Data;

/* This is used if database provider does't define
 * IAbpFrameworkDemoDbSchemaMigrator implementation.
 */
public class NullAbpFrameworkDemoDbSchemaMigrator : IAbpFrameworkDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
