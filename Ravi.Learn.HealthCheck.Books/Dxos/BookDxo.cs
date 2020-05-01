using AutoMapper;
using Ravi.Learn.HealthCheck.Books.Entities;
using Ravi.Learn.HealthCheck.Books.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravi.Learn.HealthCheck.Books.Dxos
{
    public class BookDxo : IEntityDxo<Book, BookResponse>
    {

        private readonly IMapper _mapper;

        public BookDxo()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap< Book, BookResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom<AuthorResolver>())
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishDate))
            );

            _mapper = config.CreateMapper();           

        }
        public BookResponse MapTo(Book book)
        {
            return _mapper.Map<Book, BookResponse>(book);
        }

        public class AuthorResolver : IValueResolver<Book, BookResponse, string>
        {
            public string Resolve(Book source, BookResponse destination, string destMember, ResolutionContext context)
            {
                return "John Grisham";
            }
        }
    }
}
