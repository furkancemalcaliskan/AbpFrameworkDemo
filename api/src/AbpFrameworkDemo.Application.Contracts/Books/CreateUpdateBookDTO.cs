﻿using AbpFrameworkDemo.Domain.Shared.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpFrameworkDemo.Application.Contracts.Books;

public class CreateUpdateBookDTO
{
	[Required]
	[StringLength(128)]
	public string Name { get; set; } = string.Empty;

	[Required]
	public BookType Type { get; set; } = BookType.Undefined;

	[Required]
	[DataType(DataType.Date)]
	public DateTime PublishDate { get; set; } = DateTime.Now;

	[Required]
	public float Price { get; set; }

	public Guid AuthorId { get; set; }

}
