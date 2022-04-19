using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreUI.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreUI.Application.MovieOperations.Commands.DeleteMovie;
using MovieStoreUI.Application.MovieOperations.Commands.UpdateMovie;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class MovieController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieViewModel movieModel)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = movieModel;
            command.Handle();
            return Ok("Film eklendi");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie([FromBody] UpdateMovieViewModel movieModel, int id)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId = id;
            command.Model = movieModel;
            command.Handle();
            return Ok("Film güncellendi");
        }

         [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = id;
            command.Handle();
            return Ok("Film Silindi");
        }
    }
}