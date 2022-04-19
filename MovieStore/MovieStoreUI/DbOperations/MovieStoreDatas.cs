using System;
using System.Collections.Generic;
using System.Linq;
using MovieStoreUI.Entities;

namespace MovieStoreUI.DbOperations
{
    public static class MovieStoreDatas
    {
        public static List<Actor> _actors;
        public static List<Director> _directors;
        public static List<Genre> _genries;
        public static List<Movie> _movies;
        public static List<MovieActor> _movieActors;
        
        
        static MovieStoreDatas()
        {
             _actors = new List<Actor>
            {
                new  Actor{FirstName = "Alexander",LastName = "Pittman"},
	            new Actor{FirstName = "Laurel",LastName = "Hines"},
	            new Actor{FirstName = "Nyssa",LastName = "Long"},
	            new Actor{FirstName = "Hanae",LastName = "Guzman"},
	            new Actor{FirstName = "Keegan",LastName = "Lara"}
            };
            _directors = new List<Director>
            {
                new Director{FirstName = "Linus",LastName = "Potts"},
	            new Director{FirstName = "Armando",LastName = "Ellis"},
	            new Director{FirstName = "Kyra",LastName = "Francis"},
	            new Director{FirstName = "Yasir",LastName = "Love"},
	            new Director{FirstName = "Shoshana",LastName = "Garner"}
            };
            _genries = new List<Genre>
            {
                new Genre{Name = "Drama"},
                new Genre{Name = "Comedy"},
                new Genre{Name = "Action"},
                new Genre{Name = "Animation"},
                new Genre{Name = "Romance"}

            };
            _movies = new List<Movie>
            {
                new Movie{ Title = "Tattoo", ReleaseDate = new DateTime(2012), Price = 12.99, GenreId =5, DirectorId =1 },
                new Movie{ Title = "Little Darlings", ReleaseDate = new DateTime(12015), Price = 15.59, GenreId =1, DirectorId=1 },
                new Movie{ Title = "Beaufort", ReleaseDate = new DateTime(2019), Price = 22.79, GenreId =3, DirectorId =3 },
                new Movie{ Title = "Nana", ReleaseDate = new DateTime(2017), Price = 14.99, GenreId =2, DirectorId = 2 },
                new Movie{ Title = "Tattoo", ReleaseDate = new DateTime(2012), Price = 12.89, GenreId =1, DirectorId = 2 },
            };

            _movieActors = new List<MovieActor>
            {
                new MovieActor {ActorId = 2, MovieId = 2},
                new MovieActor {ActorId = 1, MovieId = 2},
                new MovieActor {ActorId = 3, MovieId = 4},
                new MovieActor {ActorId = 5, MovieId = 3},
                new MovieActor {ActorId = 1, MovieId = 5}
               
            };
             

        }

        public static List<Actor> GetActors()
        {
            return _actors.ToList();
        }

        public static List<Director> GetDirectors()
        {
            return _directors.ToList();

        }

        public static List<Genre> GetGenres()
        {
            return _genries.ToList();
        }

        public static List<Movie> GetMovies()
        {
            return _movies.ToList();
        }

        public static List<MovieActor> GetMovieActors()
        {
            return _movieActors;
        }

    }
}