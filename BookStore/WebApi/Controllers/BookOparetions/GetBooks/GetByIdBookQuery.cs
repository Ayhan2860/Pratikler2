using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
        public class GetByIdBookQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetByIdBookQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookIdViewModel Handle(int id)
        {
            var  book = _dbContext.Books.Where(x=>x.Id == id).SingleOrDefault();
           BookIdViewModel vm = new BookIdViewModel{
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                    PageCount = book.PageCount
                    
                };
            

            return vm;
        }
    }

    public class BookIdViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}