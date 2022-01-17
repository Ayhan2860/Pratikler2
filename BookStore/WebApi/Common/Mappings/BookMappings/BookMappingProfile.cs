using AutoMapper;
using WebApi.AuthorOperations.Commands.CreateAuthor;
using WebApi.AuthorOperations.Queries;
using WebApi.BookOperations.Commands.CreateBook;
using WebApi.BookOperations.Queries;
using WebApi.Entities;

namespace WebApi.Common.Mappings.BookMappings
{
    public class BookMappingProfile:Profile
    {
        public BookMappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src =>src.Author.FirstName + " " + src.Author.LastName));
           
            CreateMap<Book, BookViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src =>src.Author.FirstName + " " + src.Author.LastName));
            
            
        }
        
    }
}