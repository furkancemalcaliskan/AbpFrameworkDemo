using AbpFrameworkDemo.Samples;
using Xunit;

namespace AbpFrameworkDemo.EntityFrameworkCore.Applications;

[Collection(AbpFrameworkDemoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpFrameworkDemoEntityFrameworkCoreTestModule>
{

}
