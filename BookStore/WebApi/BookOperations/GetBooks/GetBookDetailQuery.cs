using System;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookDetailQuery
    {
        private BookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookDetailViewModel Handle()
        {
            var  book = _dbContext.Books.Where(x=>x.Id == BookId).SingleOrDefault();
            if (book is null) throw new InvalidOperationException("Kitap kaydı bulunamadı");

            BookDetailViewModel viewModel = new BookDetailViewModel
            {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                    PageCount = book.PageCount
            };

            return viewModel;
        }
    }

    public class BookDetailViewModel
    {
          public string  Title { get; set; } 
        public int PageCount { get; set; }
        public string  PublishDate { get; set; }
        public string Genre { get; set; }
    }
}