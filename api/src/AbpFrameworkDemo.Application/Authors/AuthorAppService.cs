using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpFrameworkDemo.Application;
using AbpFrameworkDemo.Application.Contracts.Authors;
using AbpFrameworkDemo.Application.Contracts.Permissions;
using AbpFrameworkDemo.Domain.Authors;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace AbpFrameworkDemo.Application.Authors;

[Authorize(AbpFrameworkDemoPermissions.Authors.Default)]
public class AuthorAppService : AbpFrameworkDemoAppService, IAuthorAppService
{
	private readonly IAuthorRepository _authorRepository;
	private readonly AuthorManager _authorManager;

	public AuthorAppService(
		IAuthorRepository authorRepository,
		AuthorManager authorManager)
	{
		_authorRepository = authorRepository;
		_authorManager = authorManager;
	}

	//...SERVICE METHODS WILL COME HERE...

	[Authorize(AbpFrameworkDemoPermissions.Authors.Create)]
	public async Task<AuthorDTO> CreateAsync(CreateAuthorDTO input)
	{
		var author = await _authorManager.CreateAsync(
			input.Name,
			input.BirthDate,
			input.ShortBio
		);

		await _authorRepository.InsertAsync(author);

		return ObjectMapper.Map<Author, AuthorDTO>(author);
	}


	[Authorize(AbpFrameworkDemoPermissions.Authors.Delete)]
	public async Task DeleteAsync(Guid id)
	{
		await _authorRepository.DeleteAsync(id);
	}


	public async Task<AuthorDTO> GetAsync(Guid id)
	{
		var author = await _authorRepository.GetAsync(id);
		return ObjectMapper.Map<Author, AuthorDTO>(author);
	}


	public async Task<PagedResultDto<AuthorDTO>> GetListAsync(GetAuthorListDTO input)
	{
		if (input.Sorting.IsNullOrWhiteSpace())
		{
			input.Sorting = nameof(Author.Name);
		}

		var authors = await _authorRepository.GetListAsync(
			input.SkipCount,
			input.MaxResultCount,
			input.Sorting,
			input.Filter
		);

		var totalCount = input.Filter == null
			? await _authorRepository.CountAsync()
			: await _authorRepository.CountAsync(
				author => author.Name.Contains(input.Filter));

		return new PagedResultDto<AuthorDTO>(
			totalCount,
			ObjectMapper.Map<List<Author>, List<AuthorDTO>>(authors)
		);
	}


	[Authorize(AbpFrameworkDemoPermissions.Authors.Edit)]
	public async Task UpdateAsync(Guid id, UpdateAuthorDTO input)
	{
		var author = await _authorRepository.GetAsync(id);

		if (author.Name != input.Name)
		{
			await _authorManager.ChangeNameAsync(author, input.Name);
		}

		author.BirthDate = input.BirthDate;
		author.ShortBio = input.ShortBio;

		await _authorRepository.UpdateAsync(author);
	}

}
