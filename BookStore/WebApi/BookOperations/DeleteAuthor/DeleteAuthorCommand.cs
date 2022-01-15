using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.BookOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
               var  author =  _dbContext.Authors.SingleOrDefault(x=>x.AuthorId == AuthorId);
               var books = _dbContext.Books.Where(books => books.AuthorId == AuthorId).ToList();
               bool isBook = false;
               foreach (var item in books)
               {
                   isBook = item.Status;
               }
                
                if(isBook) throw new InvalidOperationException("Yazarın Yayında Olan Kitap'ı Mevcut");
                else if (author is null)throw new InvalidOperationException("Yazar bulunamadı");
               
                _dbContext.Authors.Remove(author);
               
        }
    }
}