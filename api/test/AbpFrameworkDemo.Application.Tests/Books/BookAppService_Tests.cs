using System;
using System.Linq;
using System.Threading.Tasks;
using AbpFrameworkDemo.Application.Contracts.Authors;
using AbpFrameworkDemo.Application.Contracts.Books;
using AbpFrameworkDemo.Domain.Shared.Books;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;

namespace AbpFrameworkDemo.Application.Tests.Books;

public abstract class BookAppService_Tests<TStartupModule> : AbpFrameworkDemoApplicationTestBase<TStartupModule>
	where TStartupModule : IAbpModule
{
	private readonly IBookAppService _bookAppService;
	private readonly IAuthorAppService _authorAppService;

	protected BookAppService_Tests()
	{
		_bookAppService = GetRequiredService<IBookAppService>();
		_authorAppService = GetRequiredService<IAuthorAppService>();
	}

	[Fact]
	public async Task Should_Get_List_Of_Books()
	{
		//Act
		var result = await _bookAppService.GetListAsync(
			new PagedAndSortedResultRequestDto()
		);

		//Assert
		result.TotalCount.ShouldBeGreaterThan(0);
		result.Items.ShouldContain(b => b.Name == "1984" &&
										b.AuthorName == "George Orwell");
	}

	[Fact]
	public async Task Should_Create_A_Valid_Book()
	{
		var authors = await _authorAppService.GetListAsync(new GetAuthorListDTO());
		var firstAuthor = authors.Items.First();

		//Act
		var result = await _bookAppService.CreateAsync(
			new CreateUpdateBookDTO
			{
				AuthorId = firstAuthor.Id,
				Name = "New test book 42",
				Price = 10,
				PublishDate = System.DateTime.Now,
				Type = BookType.ScienceFiction
			}
		);

		//Assert
		result.Id.ShouldNotBe(Guid.Empty);
		result.Name.ShouldBe("New test book 42");
	}

	[Fact]
	public async Task Should_Not_Create_A_Book_Without_Name()
	{
		var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
		{
			await _bookAppService.CreateAsync(
				new CreateUpdateBookDTO
				{
					Name = "",
					Price = 10,
					PublishDate = DateTime.Now,
					Type = BookType.ScienceFiction
				}
			);
		});

		exception.ValidationErrors
			.ShouldContain(err => err.MemberNames.Any(m => m == "Name"));
	}
}
