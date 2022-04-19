using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.ActorOperations.Queries.GetActors
{
    public class GetActorQueries
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetActorQueries(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ActorsViewModel> Handle()
        {
            var actors = _dbContext.Actors.Include(a => a.MovieActors).ThenInclude(x =>  x.Movie).OrderBy(a => a.Id).ToList();
            if(actors.Count <1)  throw new InvalidOperationException("Actor Bulunamdı");
            List<ActorsViewModel>  viewModels = _mapper.Map<List<ActorsViewModel>>(actors);
            return viewModels;
        }
        
    }

    public class ActorsViewModel
    {
        public string FullName { get; set; }
        public List<MovieActorViewModel> Movies { get; set; }
         
         
          public struct MovieActorViewModel
         {
             public int Id { get; set; }
             
             public string Title { get; set; }
         }

    }

}