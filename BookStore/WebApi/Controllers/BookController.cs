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
              
                   result = query.Handle();
              
             
               return Ok(result);
        }
        

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
              GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
              BookDetailViewModel result;
              GetBookDetailValidator validator = new GetBookDetailValidator();
              
                   query.BookId = id;
                   validator.ValidateAndThrow(query);
                   result = query.Handle();
              
              return Ok(result);
        }
        


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
             CreateBookCommand command = new CreateBookCommand(_context, _mapper);
             BookCommandValidator validator = new BookCommandValidator();
            
                 command.Model = newBook;
                 validator.ValidateAndThrow(command);
                 command.Handle();
             
             return Ok("Kitap Kaydedildi");


        }
  
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {
             UpdateBookCommand command = new UpdateBookCommand(_context);
             UpdateCommandValidator validator = new UpdateCommandValidator();
          
                  command.BookId = id;
                  command.Model = updateBook;
                  validator.ValidateAndThrow(command);
                  command.Handle();
              return Ok("Kitap Güncellendi");

        }


        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            BookDeleteCommandValidator validator = new BookDeleteCommandValidator();
           
                 command.BookId = id;
              
                 validator.ValidateAndThrow(command);
                 command.Handle();
           
            return Ok("Kitap Silindi");
        }
       
    }
}