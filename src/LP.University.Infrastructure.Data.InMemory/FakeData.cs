using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using LP.University.Infrastructure.Data.Models;

namespace LP.University.Infrastructure.Data.InMemory
{
    public class FakeData
    {
        private readonly List<int> _studentIds = new List<int>();
        private readonly List<int> _subjectIds = new List<int>();

        public FakeData()
        {

        }

        public void Generate(int numStudents, int numSubjects)
        {
            StudentDetails(numStudents);
            Subjects(numSubjects);
            //SubjectSessions();
            //SubjectEnrollments();
        }

        private void StudentDetails(int numRecords)
        {
            var generator = new Faker<StudentDetailsModel>();

            int studentId = _studentIds.Any() ? _studentIds.Max() + 1 : 1000000;

            generator.StrictMode(true);
            generator.RuleFor(x => x.StudentId, f => studentId++);
            generator.RuleFor(x => x.FirstName, f => f.Name.FirstName());
            generator.RuleFor(x => x.LastName, f => f.Name.LastName());
            generator.RuleFor(x => x.DateOfBirth, f => f.Date.Past(7, DateTime.Now.Date.AddYears(18)));

            using (var ctx = new InMemoryContextProvider().UniversityDbContext())
            {
                generator.Generate(numRecords).ForEach(x =>
                {
                    ctx.StudentDetails.Add(x);
                    _studentIds.Add(x.StudentId);
                });

                ctx.SaveChanges();
            }
        }

        private void Subjects(int numRecords)
        {
            var generator = new Faker<SubjectDetailsModel>();

            int subjectId = _subjectIds.Any() ? _subjectIds.Max() + 1 : 100;

            generator.StrictMode(true);
            generator.RuleFor(x => x.SubjectId, f => subjectId++);
            generator.RuleFor(x => x.Code, f => f.Random.AlphaNumeric(4));
            generator.RuleFor(x => x.Name, f => f.Commerce.Department());
            generator.RuleFor(x => x.Description, f => f.Lorem.Paragraph(1));

            using (var ctx = new InMemoryContextProvider().UniversityDbContext())
            {
                generator.Generate(numRecords).ForEach(x =>
                {
                    ctx.SubjectDetails.Add(x);
                    _subjectIds.Add(x.SubjectId);
                });
            }
        }
    }
}
