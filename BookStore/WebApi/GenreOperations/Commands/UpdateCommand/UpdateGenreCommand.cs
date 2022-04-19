using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.GenreOperations.Commands.UpdateCommand
{
    public class UpdateGenreCommand
    {
          public UpdateGenreViewModel Model { get; set; }

          public int GenreId { get; set; }
          private readonly IBookStoreDbContext _dbContext;
          private readonly IMapper _mapper;

        public UpdateGenreCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Id == GenreId);
            if(genre is null) throw new InvalidOperationException("Tür Adı Bulunamadı");
             genre.Name = Model.Name !=default ? Model.Name: genre.Name;
             genre.Status = Model.Status != default ? Model.Status : genre.Status;
             _dbContext.SaveChanges();
        }
    }

      public class UpdateGenreViewModel
      {
          public string Name { get; set; }
          public bool Status { get; set; }
      }
}   