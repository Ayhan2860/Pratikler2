using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.GenreOperations.Queries
{
    public class GetGenreDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;        public int GenreId { get; set; }

        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public GetGenreDetailViewModel Handle()
        {
           var genre = _dbContext.Genres.SingleOrDefault(x=>x.Id == GenreId);
           if(genre is null) throw new InvalidOperationException("Sistemde Kayıtlı Tür Adı Bulunamadı");
             GetGenreDetailViewModel viewModel = _mapper.Map<GetGenreDetailViewModel>(genre);
            return viewModel;
        }
    }

    public class GetGenreDetailViewModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}