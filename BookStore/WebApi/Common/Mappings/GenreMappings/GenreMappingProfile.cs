using AutoMapper;
using WebApi.Entities;
using WebApi.GenreOperations.Commands.CreateCommand;
using WebApi.GenreOperations.Queries;

namespace WebApi.Common.Mappings.GenreMappings
{
    public class GenreMappingProfile:Profile
    {
        public GenreMappingProfile()
        {
            CreateMap<CreateGenreViewModel, Genre>();
            CreateMap<Genre, GetGenresViewModel>();
            CreateMap<Genre,GetGenreDetailViewModel>();
        }
    }
}