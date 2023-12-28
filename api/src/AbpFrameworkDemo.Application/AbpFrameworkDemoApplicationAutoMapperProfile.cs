using AbpFrameworkDemo.Application.Contracts.Books;
using AbpFrameworkDemo.Domain.Books;
using AutoMapper;

namespace AbpFrameworkDemo.Application;

public class AbpFrameworkDemoApplicationAutoMapperProfile : Profile
{
    public AbpFrameworkDemoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Book, BookDTO>();
        CreateMap<CreateUpdateBookDTO, Book>();
    }
}
