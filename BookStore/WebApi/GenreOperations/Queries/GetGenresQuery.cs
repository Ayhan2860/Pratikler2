using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.GenreOperations.Queries
{
    public class GetGenresQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenresQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetGenresViewModel> Handle()
        {
            var genres = _dbContext.Genres.OrderBy(x=>x.Id);

            List<GetGenresViewModel> viewModels = _mapper.Map<List<GetGenresViewModel>>(genres);
            if(viewModels.Count <=0) throw new InvalidOperationException("Sistemde Kayıtlı Tür Adı Bulunamadı");
            return viewModels;

        }
    }

    public class GetGenresViewModel
    {
        public string Name { get; set; }
        public bool Status { get; set; }   
    }
}