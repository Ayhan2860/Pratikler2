using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
              try
              {
                   query.BookId = id;
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
             
             try
             {
                 command.Model = newBook;
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
             try
             {
                  command.BookId = id;
                  command.Model = updateBook;
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
            try
            {
                 command.BookId = id;
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