using System;
using Volo.Abp.Application.Dtos;

namespace AbpFrameworkDemo.Application.Contracts.Authors;

public class AuthorDTO : EntityDto<Guid>
{
	public string Name { get; set; }

	public DateTime BirthDate { get; set; }

	public string ShortBio { get; set; }
}
