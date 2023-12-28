using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpFrameworkDemo.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AbpFrameworkDemoDbContextFactory : IDesignTimeDbContextFactory<AbpFrameworkDemoDbContext>
{
    public AbpFrameworkDemoDbContext CreateDbContext(string[] args)
    {
        AbpFrameworkDemoEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AbpFrameworkDemoDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new AbpFrameworkDemoDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpFrameworkDemo.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
