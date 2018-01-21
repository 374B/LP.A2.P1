using System;
using Bogus;
using LP.University.Infrastructure.Data.Models;

namespace LP.University.Infrastructure.Data.InMemory
{
    public static class FakeData
    {
        public static void StudentDetails(int numRecords)
        {
            var generator = new Faker<StudentDetailsModel>();

            int studentIds = 1000000;

            generator.StrictMode(true);
            generator.RuleFor(x => x.StudentId, f => studentIds++);
            generator.RuleFor(x => x.FirstName, f => f.Name.FirstName());
            generator.RuleFor(x => x.LastName, f => f.Name.LastName());
            generator.RuleFor(x => x.DateOfBirth, f => f.Date.Past(7, DateTime.Now.Date.AddYears(18)));

            using (var ctx = new InMemoryContextProvider().UniversityDbContext())
            {
                generator.Generate(numRecords).ForEach(x =>
                {
                    ctx.StudentDetails.Add(x);
                });

                ctx.SaveChanges();
            }
        }
    }
}
