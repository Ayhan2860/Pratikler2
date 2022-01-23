using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace  WebApi.BookOperations.Queries
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BookViewModel> Handle()
        {
            var books = _dbContext.Books.Include(x=>x.Author).Include(x=>x.Genre).Where(x=>x.Genre.Status == true).OrderBy(book=>book.Id).ToList<Book>();
            List<BookViewModel> viewModels = _mapper.Map<List<BookViewModel>>(books);
          
            if (books.Count <= 0) throw new InvalidOperationException("Hiçbir Kitap bulunamadı");
             return viewModels;
        }
    }

    public class  BookViewModel
    {
        public string  Title { get; set; } 
        public int PageCount { get; set; }
        public string FullName { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}