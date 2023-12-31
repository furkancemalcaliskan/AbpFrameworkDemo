using System;
using Volo.Abp.Application.Dtos;

namespace AbpFrameworkDemo.Application.Contracts.Books;

public class AuthorLookupDTO : EntityDto<Guid>
{
	public string Name { get; set; }
}
