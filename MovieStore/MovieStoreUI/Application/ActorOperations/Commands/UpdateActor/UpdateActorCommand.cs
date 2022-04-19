using System;
using System.Linq;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public int ActorId { get; set; }
        public UpdateActorViewModel Model { get; set; }
        
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(actor=>actor.Id == ActorId);
            if(actor is null) throw new InvalidOperationException("Güncellenecek Actor bulunamadı");
            actor.FirstName = Model.FirstName != default ? Model.FirstName : actor.FirstName;
            actor.LastName = Model.LastName != default ? Model.LastName : actor.LastName;
            _dbContext.SaveChanges();
        }
    }

    public class UpdateActorViewModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        
    }
}