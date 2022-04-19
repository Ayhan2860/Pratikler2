using System;
using WebApi;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class  Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                     new Genre {Name= "PersonalGrowth"},
                     new Genre {Name= "ScienceFiction",Status = false},
                     new Genre {Name= "Noval", Status = true}
                 );
        }
    }
}