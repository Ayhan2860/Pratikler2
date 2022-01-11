using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly  BookStoreDbContext _context;
       

        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
           
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
             GetBooksQuery query = new GetBooksQuery(_context,_mapper);
             List<BookViewModel> result;
              try
              {
                   result = query.Handle();
              }
              catch (Exception ex)
              {
                   return BadRequest(ex.Message);
              }
               return Ok(result);
        }
        

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
              GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
              BookDetailViewModel result;
              GetBookDetailValidator validator = new GetBookDetailValidator();
              try
              {
                   query.BookId = id;
                   validator.ValidateAndThrow(query);
                   result = query.Handle();
              }
              catch (Exception ex)
              {
                  
                   return BadRequest(ex.Message);
              }
              return Ok(result);
        }
        


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
             CreateBookCommand command = new CreateBookCommand(_context, _mapper);
             BookCommandValidator validator = new BookCommandValidator();
             try
             {
                 command.Model = newBook;
                 validator.ValidateAndThrow(command);
                 command.Handle();
             }
             catch (Exception ex)
             {
                 
                 return BadRequest(ex.Message);
             }

             return Ok("Kitap Kaydedildi");


        }
  
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {
             UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
             UpdateCommandValidator validator = new UpdateCommandValidator();
             try
             {
                  command.BookId = id;
                  command.Model = updateBook;
                  validator.ValidateAndThrow(command);
                  command.Handle();
             }
             catch (Exception ex)
             {
                 
                return BadRequest(ex.Message);
             }
              return Ok("Kitap Güncellendi");

        }


        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            BookDeleteCommandValidator validator = new BookDeleteCommandValidator();
            try
            {
                 command.BookId = id;
              
                 validator.ValidateAndThrow(command);
                 command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok("Kitap Silindi");
        }
       
    }
}