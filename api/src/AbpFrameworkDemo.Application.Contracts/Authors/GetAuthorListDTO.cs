using Volo.Abp.Application.Dtos;

namespace AbpFrameworkDemo.Application.Contracts.Authors;

public class GetAuthorListDTO : PagedAndSortedResultRequestDto
{
	public string? Filter { get; set; }
}
