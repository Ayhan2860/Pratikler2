using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreUI.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreUI.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStoreUI.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectors;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorsQueries query = new GetDirectorsQueries(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
            query.DirectorId =id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult CreateDirector(CreateDirectorViewModel director)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = director;
            command.Handle();
            return Ok("Yönetmen Eklendi");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(UpdateDirectorViewModel director, int id)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.DirectorId = id;
            command.Model = director;
            command.Handle();
            return Ok("Yönetmen Güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;
            command.Handle();
            return Ok("Yönetmen Silindi");
        }
    }
}