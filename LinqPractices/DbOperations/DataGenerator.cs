using System.Linq;
using LinqPractices.Entities;

namespace LinqPractices.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var context = new LinqDbContext())
            {
                 if (context.Students.Any())
                 {
                     return;
                 }
                 context.Students.AddRange(
                     new Student{ Name= "Kadriye", SurName= "Kılınç", ClassId=2},
                     new Student{ Name= "Ahmet", SurName= "Yılmaz", ClassId=3},
                     new Student{ Name= "Zikriye", SurName= "Ürkmez", ClassId=1},
                     new Student{Name= "Engin", SurName= "Demiroğ", ClassId=2}
                 );
                 context.SaveChanges();
            }
        }
    }
    
}