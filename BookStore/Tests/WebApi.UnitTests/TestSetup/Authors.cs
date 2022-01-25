using System;
using WebApi;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.AddRange(
                    new Author{FirstName = "LAUREN", LastName="BROOKE", DateOfBirth= new DateTime(1969,01,15)},
                    new Author{FirstName = "Marcel", LastName="Proust", DateOfBirth= new DateTime(1871,07,10)},
                    new Author{FirstName = "George", LastName="Orwell", DateOfBirth= new DateTime(1903,06,25)},
                    new Author{FirstName = "Richard Ellis", LastName="Shaw", DateOfBirth= new DateTime(1975,03,20)}
            );
        }
    }
}