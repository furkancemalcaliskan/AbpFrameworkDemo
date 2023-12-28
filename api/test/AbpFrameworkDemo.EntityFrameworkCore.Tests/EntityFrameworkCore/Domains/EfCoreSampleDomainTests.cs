using AbpFrameworkDemo.Samples;
using Xunit;

namespace AbpFrameworkDemo.EntityFrameworkCore.Domains;

[Collection(AbpFrameworkDemoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpFrameworkDemoEntityFrameworkCoreTestModule>
{

}
