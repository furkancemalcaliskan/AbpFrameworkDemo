using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AbpFrameworkDemo.Application.Contracts.Books;
using AbpFrameworkDemo.Application.Contracts.Permissions;
using AbpFrameworkDemo.Domain.Authors;
using AbpFrameworkDemo.Domain.Books;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace AbpFrameworkDemo.Application.Books;

[Authorize(AbpFrameworkDemoPermissions.Books.Default)]
public class BookAppService :
	CrudAppService<
		Book, //The Book entity
		BookDTO, //Used to show books
		Guid, //Primary key of the book entity
		PagedAndSortedResultRequestDto, //Used for paging/sorting
		CreateUpdateBookDTO>, //Used to create/update a book
	IBookAppService //implement the IBookAppService
{
	private readonly IAuthorRepository _authorRepository;

	public BookAppService(
		IRepository<Book, Guid> repository,
		IAuthorRepository authorRepository)
		: base(repository)
	{
		_authorRepository = authorRepository;
		GetPolicyName = AbpFrameworkDemoPermissions.Books.Default;
		GetListPolicyName = AbpFrameworkDemoPermissions.Books.Default;
		CreatePolicyName = AbpFrameworkDemoPermissions.Books.Create;
		UpdatePolicyName = AbpFrameworkDemoPermissions.Books.Edit;
		DeletePolicyName = AbpFrameworkDemoPermissions.Books.Delete;
	}

	public override async Task<BookDTO> GetAsync(Guid id)
	{
		//Get the IQueryable<Book> from the repository
		var queryable = await Repository.GetQueryableAsync();

		//Prepare a query to join books and authors
		var query = from book in queryable
					join author in await _authorRepository.GetQueryableAsync() on book.AuthorId equals author.Id
					where book.Id == id
					select new { book, author };

		//Execute the query and get the book with author
		var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
		if (queryResult == null)
		{
			throw new EntityNotFoundException(typeof(Book), id);
		}

		var bookDto = ObjectMapper.Map<Book, BookDTO>(queryResult.book);
		bookDto.AuthorName = queryResult.author.Name;
		return bookDto;
	}

	public override async Task<PagedResultDto<BookDTO>> GetListAsync(PagedAndSortedResultRequestDto input)
	{
		//Get the IQueryable<Book> from the repository
		var queryable = await Repository.GetQueryableAsync();

		//Prepare a query to join books and authors
		var query = from book in queryable
					join author in await _authorRepository.GetQueryableAsync() on book.AuthorId equals author.Id
					select new { book, author };

		//Paging
		query = query
			.OrderBy(NormalizeSorting(input.Sorting))
			.Skip(input.SkipCount)
			.Take(input.MaxResultCount);

		//Execute the query and get a list
		var queryResult = await AsyncExecuter.ToListAsync(query);

		//Convert the query result to a list of BookDto objects
		var bookDtos = queryResult.Select(x =>
		{
			var bookDto = ObjectMapper.Map<Book, BookDTO>(x.book);
			bookDto.AuthorName = x.author.Name;
			return bookDto;
		}).ToList();

		//Get the total count with another query
		var totalCount = await Repository.GetCountAsync();

		return new PagedResultDto<BookDTO>(
			totalCount,
			bookDtos
		);
	}

	public async Task<ListResultDto<AuthorLookupDTO>> GetAuthorLookupAsync()
	{
		var authors = await _authorRepository.GetListAsync();

		return new ListResultDto<AuthorLookupDTO>(
			ObjectMapper.Map<List<Author>, List<AuthorLookupDTO>>(authors)
		);
	}

	private static string NormalizeSorting(string sorting)
	{
		if (sorting.IsNullOrEmpty())
		{
			return $"book.{nameof(Book.Name)}";
		}

		if (sorting.Contains("authorName", StringComparison.OrdinalIgnoreCase))
		{
			return sorting.Replace(
				"authorName",
				"author.Name",
				StringComparison.OrdinalIgnoreCase
			);
		}

		return $"book.{sorting}";
	}
}
