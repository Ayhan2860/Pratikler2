using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace  WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookViewModel> Handle()
        {
            var books = _dbContext.Books.OrderBy(book=>book.Id).ToList<Book>();
          
            List<BookViewModel> viewModels = new List<BookViewModel>();
            if (books.Count <= 0) throw new InvalidOperationException("Hiçbir Kitap bulunamadı");
            
            foreach (var book in books)
            {
                viewModels.Add(
                    new BookViewModel{
                        Title = book.Title,
                        Genre = ((GenreEnum)book.GenreId).ToString(),
                        PageCount = book.PageCount,
                        PublishDate = book.PublishDate
                    }
                );
            }
            return viewModels;
        }
    }

    public class  BookViewModel
    {
        public string  Title { get; set; } 
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}