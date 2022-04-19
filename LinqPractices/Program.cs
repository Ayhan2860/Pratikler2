using System;
using System.Collections.Generic;
using System.Linq;
using LinqPractices.DbOperations;
using LinqPractices.Entities;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
          
            var student = _context.Students.Where(s => s.StudentId == 1).FirstOrDefault();
            // ToList()
            Console.WriteLine("\t\t***** ToList *****");
            var  students = LinqToList(_context);


            // Find() 
            Console.WriteLine("\n\t\t***** Find *****");
            student = LinqFind(_context);

            // FirstOrDefault();
            Console.WriteLine("\n\t\t***** FirstOrDefault *****");
            student = LinqFirstOrDefault(_context);


            //SingleOrDefault()
            Console.WriteLine("\n\t\t***** SingleOrDefault *****");
            student = LinqSingleOrDefault(_context);


            // ToList() 2
            Console.WriteLine("\n\t\t***** ToList-2 *****");
            var studentList = _context.Students.Where(s => s.ClassId == 2).ToList();
            Console.WriteLine(studentList.Count);


            // OrderBy()
            Console.WriteLine("\n\t\t***** OrderBy *****");
            students = LinqOrderBy(_context);
 
           // OrderByDescending()
            Console.WriteLine("\n\t\t***** OrderByDescending *****");
            students = LinqOrderByDescending(_context);
            

            // Anonymous Object Result
             Console.WriteLine("\n\t\t***** Anonymous Object Result *****");
             var anonymousObject = _context.Students.Where(x=>x.ClassId == 2)
                                   .Select(x=> new {
                                       Id = x.StudentId,
                                       FullName = x.Name + " " + x.SurName
                                   });

              foreach (var item in anonymousObject)
              {
                   Console.WriteLine(@"
                    Id : {0}
                    Adı Soyadı : {1}
                    -----", item.Id, item.FullName);
              }                     

            Console.ReadKey();
        }

        private static List<Student> LinqOrderBy(LinqDbContext _context)
        {
            List<Student> students = _context.Students.OrderBy(x => x.StudentId).ToList();
            foreach (var item in students)
            {
                Console.WriteLine(@"
                    Adı : {0}
                    Soyadı : {1}
                    Sınıfı : {2}
                    -----", item.Name, item.SurName, item.ClassId);
            }

            return students;
        }
         private static List<Student> LinqOrderByDescending(LinqDbContext _context)
        {
            List<Student> students = _context.Students.OrderByDescending(x => x.StudentId).ToList();
            foreach (var item in students)
            {
                Console.WriteLine(@"
                    Adı : {0}
                    Soyadı : {1}
                    Sınıfı : {2}
                    -----", item.Name, item.SurName, item.ClassId);
            }

            return students;
        }

        private static Student LinqSingleOrDefault(LinqDbContext _context)
        {
            Student student = _context.Students.SingleOrDefault(s => s.Name == "Kadriye");
            Console.WriteLine(@"
                    Adı : {0}
                    Soyadı : {1}
                    Sınıfı : {2}
                    ", student.Name, student.SurName, student.ClassId);
            return student;
        }

        private static Student LinqFirstOrDefault(LinqDbContext _context)
        {
            Student student = _context.Students.Where(s => s.SurName == "Kılınç").FirstOrDefault();
            Console.WriteLine(@"
                    Adı : {0}
                    Soyadı : {1}
                    Sınıfı : {2}
                    ", student.Name, student.SurName, student.ClassId);

             student = _context.Students.FirstOrDefault(s => s.SurName == "Kılınç");
            Console.WriteLine(@"
                    Adı : {0}
                    Soyadı : {1}
                    Sınıfı : {2}
                    ", student.Name, student.SurName, student.ClassId);
            return student;
        }

        private static Student LinqFind(LinqDbContext _context)
        {
            
           Student student = _context.Students.Find(1);
            Console.WriteLine(@"
                    Adı : {0}
                    Soyadı : {1}
                    Sınıfı : {2}
                    ", student.Name, student.SurName, student.ClassId);

             return student;
        }

        private static List<Student> LinqToList(LinqDbContext _context)
        {
           List<Student> students =  _context.Students.ToList<Student>();
            foreach (var item in students)
            {
                Console.WriteLine(@"
                    Adı : {0}
                    Soyadı : {1}
                    Sınıfı : {2}
                    -----", item.Name, item.SurName, item.ClassId);
            }

            return students;
        }
    }
}
