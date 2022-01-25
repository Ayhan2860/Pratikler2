using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    { 
        public UpdateBookModel Model {get; set;}

        private  readonly IBookStoreDbContext _dbContext;
       
        public int BookId { get; set; }

        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public void Handle()
        {
             var book = _dbContext.Books.SingleOrDefault(x=>x.Id == BookId);

            if (book is null)throw new InvalidOperationException("Kitap Bulunamadı");
              

            book.GenreId = Model.GenreId != default ? Model.GenreId: book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.Title = Model.Title  != default ? Model.Title : book.Title;
            book.AuthorId = Model.AuthorId != default ? Model.AuthorId : book.AuthorId;
            _dbContext.SaveChanges();
         
        }
    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public bool Status { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}