using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQueries
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMoviesQueries(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetMoviesViewModel> Handle()
        {
            var movies = _dbContext.Movies.Include(movie => movie.Director).Include(movie=>movie.Genre).ToList();
            if(movies.Count < 1) throw new InvalidOperationException("Film verisi bulunamadı!");
            List<GetMoviesViewModel> viewModels = _mapper.Map<List<GetMoviesViewModel>>(movies);
            return viewModels;
        }
    }

    public class GetMoviesViewModel
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; } 

    }
}