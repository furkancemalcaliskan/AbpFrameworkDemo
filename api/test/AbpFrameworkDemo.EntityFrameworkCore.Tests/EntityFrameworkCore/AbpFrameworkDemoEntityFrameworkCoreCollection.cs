using Xunit;

namespace AbpFrameworkDemo.EntityFrameworkCore;

[CollectionDefinition(AbpFrameworkDemoTestConsts.CollectionDefinitionName)]
public class AbpFrameworkDemoEntityFrameworkCoreCollection : ICollectionFixture<AbpFrameworkDemoEntityFrameworkCoreFixture>
{

}
