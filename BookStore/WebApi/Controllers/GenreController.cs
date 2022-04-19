using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.GenreOperations.Commands.CreateCommand;
using WebApi.GenreOperations.Commands.DeleteCommand;
using WebApi.GenreOperations.Commands.UpdateCommand;
using WebApi.GenreOperations.Queries;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController:ControllerBase
    {
        private readonly  IBookStoreDbContext _context;
       

        private readonly IMapper _mapper;

        public GenreController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
             GetGenresQuery query = new GetGenresQuery(_context, _mapper);
             List<GetGenresViewModel> result;
             result = query.Handle();

             return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdGenre(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            GetGenreDetailValidator validator = new GetGenreDetailValidator();
            
            GetGenreDetailViewModel result;
            query.GenreId = id;
            validator.ValidateAndThrow(query);
             result =  query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreViewModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            CreateGenreValidator validator = new CreateGenreValidator();
                 command.Model = newGenre;
                 validator.ValidateAndThrow(command);
                 command.Handle();
                 return Ok("Tür Adı Sisteme Kaydedildi");
        }

        [HttpPut]
        public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreViewModel newGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context,_mapper);
            UpdateGenreValidator validator = new UpdateGenreValidator();
            command.GenreId = id;
            command.Model = newGenre;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Tür Adı Sistem Üzerinde Güncellendi");
        }

        [HttpDelete]
        public IActionResult UpdateGenre(int id)
        {
             DeleteGenreCommand command = new DeleteGenreCommand(_context);
             DeleteGenreValidator validator = new DeleteGenreValidator();
             command.GenreId = id;
             validator.ValidateAndThrow(command);
             command.Handle();

             return Ok("Tür Adı Sistem Üzerinden Silindi");
        }
    }
}