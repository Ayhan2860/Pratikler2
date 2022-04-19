using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.AuthorOperations.Commands.CreateAuthor;
using WebApi.AuthorOperations.Commands.DeleteAuthor;
using WebApi.AuthorOperations.Commands.UpdateAuthor;
using WebApi.AuthorOperations.Queries;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
     public class  AuthorController:Controller
     {
         private readonly  IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery query  =new GetAuthorQuery(_context,_mapper);
            List<GetAuthorsQueryModel> result;
              result =  query.Handle();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetByAuthorId(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
             AuthorDetailViewModel result;
              query.AuthorId = id;
              validator.ValidateAndThrow(query);
               result = query.Handle();
              return Ok(result);

        }

        


        [HttpPost]
        public IActionResult AuthorAdd([FromBody] CreateAuthorModel model)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            AuthorCommandValidator validator = new AuthorCommandValidator();
            command.Model =model;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Yazar Eklendi");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorViewModel model)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            command.AuthorId = id;
            command.Model = model;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok("Yazar Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            command.AuthorId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok("Yazar Silindi");
            
        }
    }


}