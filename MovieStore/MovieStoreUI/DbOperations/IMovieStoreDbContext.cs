using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStoreUI.Entities;
namespace MovieStoreUI.DbOperations
{
    public interface IMovieStoreDbContext
    {
       DbSet<Movie> Movies{ get; set; }
       DbSet<Actor> Actors { get; set; }
       DbSet<Genre> Genres { get; set; }
       DbSet<Director> Directors { get; set; }
       DbSet<MovieActor> MovieActors { get; set; }

       int SaveChanges();
    }
}