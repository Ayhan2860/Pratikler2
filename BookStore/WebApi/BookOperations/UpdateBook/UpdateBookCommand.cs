using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    { 
        public UpdateBookModel Model {get; set;}

        private  readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
             var book = _dbContext.Books.SingleOrDefault(x=>x.Id == BookId);

            if (book is null)throw new InvalidOperationException("Kitap Bulunamadı");
              

            book.GenreId = Model.GenreId != default ? Model.GenreId: book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.Title = Model.Title  != default ? Model.Title : book.Title;
            _dbContext.SaveChanges();
         
        }
    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}