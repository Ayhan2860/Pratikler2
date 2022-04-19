using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetActorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ActorDetailViewModel Handle()
        {
             var actor = _dbContext.Actors.Include(actor =>actor.MovieActors).ThenInclude(ma =>ma.Movie).SingleOrDefault(actor => actor.Id == ActorId);
             if(actor is null) throw new InvalidOperationException("Actor Bulunamadı");
             ActorDetailViewModel viewModel = _mapper.Map<ActorDetailViewModel>(actor);
             return viewModel;

        }
    }
     public class ActorDetailViewModel
     {
         public int Id { get; set; }
         public string FullName { get; set; }
         public List<MovieActorViewModel> Movies { get; set; }
         
         
          public struct MovieActorViewModel
         {
             public int Id { get; set; }
             
             public string Title { get; set; } 
         }
     }
}