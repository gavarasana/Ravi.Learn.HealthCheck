using AutoMapper;
using Ravi.Learn.HealthCheck.Books.Entities;
using Ravi.Learn.HealthCheck.Books.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravi.Learn.HealthCheck.Books.Mappers
{
    public class BookMapperProfile : Profile
    {
        public BookMapperProfile()
        {
            CreateMap<Book, BookResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom<AuthorResolver>())
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishDate));

        }
    }

    public class AuthorResolver : IValueResolver<Book, BookResponse, string>
    {
        public string Resolve(Book source, BookResponse destination, string destMember, ResolutionContext context)
        {
            return "John Grisham";
        }
    }
}
