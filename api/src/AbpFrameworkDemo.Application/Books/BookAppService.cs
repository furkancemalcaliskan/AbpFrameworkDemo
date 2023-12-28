﻿using AbpFrameworkDemo.Application.Contracts.Books;
using AbpFrameworkDemo.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpFrameworkDemo.Application.Books;

public class BookAppService : CrudAppService<
		Book, //The Book entity
		BookDTO, //Used to show books
		Guid, //Primary key of the book entity
		PagedAndSortedResultRequestDto, //Used for paging/sorting
		CreateUpdateBookDTO>, //Used to create/update a book
	IBookAppService //implement the IBookAppService
{
	public BookAppService(IRepository<Book, Guid> repository) : base(repository)
	{
	}
}