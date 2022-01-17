using AutoMapper;
using WebApi.AuthorOperations.Commands.CreateAuthor;
using WebApi.AuthorOperations.Queries;
using WebApi.Entities;

namespace WebApi.Common.Mappings.AuthorMappings
{
    public class AuthorMappingProfile:Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, GetAuthorsQueryModel>();
            CreateMap<Author, AuthorDetailViewModel>();
        }
    }
}