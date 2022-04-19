using System;
using System.Linq;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
       public int ActorId { get; set; }
       private readonly IMovieStoreDbContext _dbContext;

        public DeleteActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(actor=>actor.Id == ActorId);
            if(actor is null) throw new InvalidOperationException("Actor Bulunamadı");
            _dbContext.Actors.Remove(actor);
            _dbContext.SaveChanges();
        }

    }
}