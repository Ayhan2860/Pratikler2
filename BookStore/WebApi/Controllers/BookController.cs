using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly  BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
             GetBooksQuery query = new GetBooksQuery(_context);
             var result = query.Handle();
           
              if (result == null)
              {
                   return BadRequest("Kitap Bulunamadı");
              }
               return Ok(result);
        }
        

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
              GetBookDetailQuery query = new GetBookDetailQuery(_context);
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
             CreateBookCommand command = new CreateBookCommand(_context);
             
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
             UpdateBookCommand command = new UpdateBookCommand(_context);
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
            var  book = _context.Books.SingleOrDefault(x=>x.Id == id);
            if (book is null)
            {
                return BadRequest("Kitap bulunamadı");
            }
             _context.Books.Remove(book);
             _context.SaveChanges();
            return Ok("Silindi");
        }
       
    }
}