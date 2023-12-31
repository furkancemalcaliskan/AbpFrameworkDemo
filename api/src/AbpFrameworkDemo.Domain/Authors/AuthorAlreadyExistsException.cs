using AbpFrameworkDemo.Domain.Shared;
using Volo.Abp;

namespace AbpFrameworkDemo.Domain.Authors;

public class AuthorAlreadyExistsException : BusinessException
{
	public AuthorAlreadyExistsException(string name)
		: base(AbpFrameworkDemoDomainErrorCodes.AuthorAlreadyExists)
	{
		WithData("name", name);
	}
}
