using AutoMapper;
using WebApi.AuthorOperations.Commands.CreateAuthor;
using WebApi.AuthorOperations.Queries;
using WebApi.BookOperations.Commands.CreateBook;
using WebApi.BookOperations.Queries;
using WebApi.Entities;
using WebApi.GenreOperations.Commands.CreateCommand;
using WebApi.GenreOperations.Queries;
using WebApi.UserOperations.Commands.CreateUser;

namespace WebApi.Common.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, GetAuthorsQueryModel>();
            CreateMap<Author, AuthorDetailViewModel>();

            CreateMap<CreateBookModel,Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src =>src.Author.FirstName + " " + src.Author.LastName));
            
            CreateMap<Book, BookViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src =>src.Author.FirstName + " " + src.Author.LastName));

            CreateMap<CreateGenreViewModel, Genre>();
            CreateMap<Genre, GetGenresViewModel>();
            CreateMap<Genre,GetGenreDetailViewModel>();
            
             CreateMap<CreateUserModel,User>();
            
        }
    }
}