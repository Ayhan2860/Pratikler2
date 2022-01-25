using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common.Mappings.AuthorMappings;
using WebApi.Common.Mappings.BookMappings;
using WebApi.Common.Mappings.GenreMappings;
using WebApi.DbOperations;

namespace  Tests.WebApi.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreDbContext Context{ get; set;}
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDb").Options;
            Context = new BookStoreDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.AddAuthors();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg=>{cfg.AddProfile<GenreMappingProfile>();
             cfg.AddProfile<BookMappingProfile>(); cfg.AddProfile<AuthorMappingProfile>(); }).CreateMapper();
        }
       
    }
}