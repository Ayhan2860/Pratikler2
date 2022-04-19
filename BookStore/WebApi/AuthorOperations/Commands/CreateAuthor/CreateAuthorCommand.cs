using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public  CreateAuthorModel Model {get; set;}
        private readonly  IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.Include(x=>x.Books)
            .SingleOrDefault(x=>x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if (author is not null) throw new InvalidOperationException("Bu Yazar Kayıtlı");

            author = _mapper.Map<Author>(Model);
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
            
        }
    }

    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}