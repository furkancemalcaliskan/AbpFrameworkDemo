using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpFrameworkDemo.Application.Contracts.Books
{
	public interface IBookAppService : ICrudAppService< //Defines CRUD methods
		BookDTO, //Used to show books
		Guid, //Primary key of the book entity
		PagedAndSortedResultRequestDto, //Used for paging/sorting
		CreateUpdateBookDTO> //Used to create/update a book
	{
	}
}
