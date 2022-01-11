using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DbOperations;

namespace  WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BookViewModel> Handle()
        {
            var books = _dbContext.Books.OrderBy(book=>book.Id).ToList<Book>();
          
            List<BookViewModel> viewModels = _mapper.Map<List<BookViewModel>>(books);
          
            if (books.Count <= 0) throw new InvalidOperationException("Hiçbir Kitap bulunamadı");
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