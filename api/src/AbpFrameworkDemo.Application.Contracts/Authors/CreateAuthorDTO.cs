using AbpFrameworkDemo.Domain.Shared.Authors;
using System;
using System.ComponentModel.DataAnnotations;

namespace AbpFrameworkDemo.Application.Contracts.Authors;

public class CreateAuthorDTO
{
	[Required]
	[StringLength(AuthorConsts.MaxNameLength)]
	public string Name { get; set; } = string.Empty;

	[Required]
	public DateTime BirthDate { get; set; }

	public string? ShortBio { get; set; }
}
