using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.GenreOperations.Commands.CreateCommand
{
    public class CreateGenreCommand
    {
        public CreateGenreViewModel Model { get; set;}
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Name == Model.Name);
            if (genre is not null) throw new InvalidOperationException("Bu Tür Adı Sistemde Zaten Kayıtlı");

            genre = _mapper.Map<Genre>(Model);
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }
    public class CreateGenreViewModel
    {
        public string Name { get; set; }

        
    }
}