using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.AuthorOperations.Queries
{
    public class GetAuthorDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }

        public GetAuthorDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(author=>author.AuthorId == AuthorId);
            
             if (author is null) throw new InvalidOperationException("Yazar Bulunamadı");

             AuthorDetailViewModel viewModel = _mapper.Map<AuthorDetailViewModel>(author);

             return viewModel;
         
        }
    }

    public class AuthorDetailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}