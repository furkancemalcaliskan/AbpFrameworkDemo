using AbpFrameworkDemo.Domain.Shared.Books;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpFrameworkDemo.Application.Contracts.Books;

public class BookDTO : AuditedEntityDto<Guid>
{
	public string Name { get; set; }

	public BookType Type { get; set; }

	public DateTime PublishDate { get; set; }

	public float Price { get; set; }

}
