using AutoMapper;
using WebApi.BookOperations.CreateAuthor;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetAuthor;
using WebApi.BookOperations.GetBooks;
namespace WebApi.Common.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
           
            CreateMap<Book, BookViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, GetAuthorsQueryModel>();
            CreateMap<Author, AuthorDetailViewModel>();
            
        }
        
    }
}