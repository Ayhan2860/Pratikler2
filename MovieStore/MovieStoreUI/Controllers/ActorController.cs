using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreUI.Application.ActorOperations.Commands.CreateActor;
using MovieStoreUI.Application.ActorOperations.Commands.DeleteActor;
using MovieStoreUI.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreUI.Application.ActorOperations.Queries.GetActorDetail;
using MovieStoreUI.Application.ActorOperations.Queries.GetActors;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorQueries query = new GetActorQueries(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetActorDetail(int id)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            query.ActorId = id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateActor([FromBody]CreateActorViewModel actor)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            CreateActorValidator validator = new CreateActorValidator();
            command.Model = actor;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok(actor.FirstName + " " + actor.LastName +" "+ " İsimli Aktor Eklendi");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor([FromBody] UpdateActorViewModel actor, int id)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.ActorId = id;
            command.Model = actor;
            command.Handle();
            return Ok("Actor Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = id;
            command.Handle();
            return Ok("Actor Silindi");
        }
    }
}