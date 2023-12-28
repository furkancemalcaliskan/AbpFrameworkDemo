using AbpFrameworkDemo.Domain.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpFrameworkDemo.HttpApi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpFrameworkDemoController : AbpControllerBase
{
    protected AbpFrameworkDemoController()
    {
        LocalizationResource = typeof(AbpFrameworkDemoResource);
    }
}
