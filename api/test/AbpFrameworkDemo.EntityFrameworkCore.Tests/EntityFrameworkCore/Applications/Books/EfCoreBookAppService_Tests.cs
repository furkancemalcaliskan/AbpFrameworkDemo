using AbpFrameworkDemo.Application.Tests.Books;
using Xunit;

namespace AbpFrameworkDemo.EntityFrameworkCore.Tests.Applications.Books;

[Collection(AbpFrameworkDemoTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<AbpFrameworkDemoEntityFrameworkCoreTestModule>
{

}
