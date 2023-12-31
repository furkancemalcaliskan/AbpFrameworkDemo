using AbpFrameworkDemo;
using AbpFrameworkDemo.Application.Tests.Authors;
using AbpFrameworkDemo.EntityFrameworkCore;
using Xunit;

namespace AbpFrameworkDemo.EntityFrameworkCore.Tests.Applications.Authors;

[Collection(AbpFrameworkDemoTestConsts.CollectionDefinitionName)]
public class EfCoreAuthorAppService_Tests : AuthorAppService_Tests<AbpFrameworkDemoEntityFrameworkCoreTestModule>
{

}
