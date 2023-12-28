using System.Threading.Tasks;

namespace AbpFrameworkDemo.Domain.Data;

public interface IAbpFrameworkDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
