using AbpFrameworkDemo.Domain.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace AbpFrameworkDemo.Application;

/* Inherit your application services from this class.
 */
public abstract class AbpFrameworkDemoAppService : ApplicationService
{
    protected AbpFrameworkDemoAppService()
    {
        LocalizationResource = typeof(AbpFrameworkDemoResource);
    }
}
