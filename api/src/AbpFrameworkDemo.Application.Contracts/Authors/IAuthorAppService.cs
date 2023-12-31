using AbpFrameworkDemo.Application.Contracts.Authors;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpFrameworkDemo.Application.Contracts.Authors;

public interface IAuthorAppService : IApplicationService
{
	Task<AuthorDTO> GetAsync(Guid id);

	Task<PagedResultDto<AuthorDTO>> GetListAsync(GetAuthorListDTO input);

	Task<AuthorDTO> CreateAsync(CreateAuthorDTO input);

	Task UpdateAsync(Guid id, UpdateAuthorDTO input);

	Task DeleteAsync(Guid id);
}
