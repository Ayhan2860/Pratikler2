using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }  
        private  readonly IBookStoreDbContext _dbContext;
        public UpdateAuthorViewModel Model { get; set; }
        public UpdateAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.AuthorId == AuthorId);
            
            if(author is null) throw new InvalidOperationException("Yazar bulunamadı");

            author.FirstName = Model.FirstName != default ? Model.FirstName : author.FirstName;
            author.LastName = Model.LastName != default ? Model.LastName : author.LastName;
            author.DateOfBirth = Model.DateOfBirth != default ? Model.DateOfBirth : author.DateOfBirth;
            _dbContext.SaveChanges();
        }
         

        
    }

    public class UpdateAuthorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}