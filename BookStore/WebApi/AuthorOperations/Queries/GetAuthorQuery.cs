using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.AuthorOperations.Queries
{
    public class GetAuthorQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetAuthorsQueryModel> Handle()
        {  
          
            var authors = _dbContext.Authors.Include(x=>x.Books).Where(x=>x.Books.All(x=>x.Status == true)).OrderBy(x=>x.AuthorId).ToList<Author>();
            List<GetAuthorsQueryModel> viewAuthors = _mapper.Map<List<GetAuthorsQueryModel>>(authors);
         
            if (authors.Count <= 0) throw new InvalidOperationException("Hiçbir Yazar bulunamadı");
            return viewAuthors;
            
        }
    }

    public class GetAuthorsQueryModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}