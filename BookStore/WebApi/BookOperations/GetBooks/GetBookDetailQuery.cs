using System;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var  book = _dbContext.Books.Where(x=>x.Id == BookId).SingleOrDefault();
            if (book is null) throw new InvalidOperationException("Kitap kaydı bulunamadı");

            BookDetailViewModel viewModel = _mapper.Map<BookDetailViewModel>(book);
            

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