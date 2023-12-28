using System;
using System.Threading.Tasks;
using AbpFrameworkDemo.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace AbpFrameworkDemo.EntityFrameworkCore;

public class EntityFrameworkCoreAbpFrameworkDemoDbSchemaMigrator
    : IAbpFrameworkDemoDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpFrameworkDemoDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AbpFrameworkDemoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpFrameworkDemoDbContext>()
            .Database
            .MigrateAsync();
    }
}
