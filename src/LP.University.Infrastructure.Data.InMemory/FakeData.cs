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
        private readonly List<int> _lectureTheatreIds = new List<int>();

        public FakeData()
        {

        }

        public void Generate(
            int numStudents,
            int numSubjects,
            int minLecturesPerSubject,
            int maxLecturesPerSubject,
            int minSubjectsPerStudent,
            int maxSubjectsPerStudent)
        {
            StudentDetails(numStudents);
            Subjects(numSubjects);
            LectureTheatres();
            Lectures(minLecturesPerSubject, maxLecturesPerSubject);
            StudentSubjects(minSubjectsPerStudent, maxSubjectsPerStudent);
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

                ctx.SaveChanges();

            }
        }

        private void LectureTheatres()
        {
            using (var ctx = new InMemoryContextProvider().UniversityDbContext())
            {
                for (int i = 0; i < 3; i++)
                {
                    var cap = (i + 1) * 10;

                    var e = ctx.LectureTheatres.Add(new LectureTheatreModel
                    {
                        Capacity = cap
                    });

                    _lectureTheatreIds.Add(e.Entity.LectureTheatreId);
                }

                ctx.SaveChanges();
            }
        }

        private void Lectures(int minPerSubject, int maxPerSubject)
        {
            var generator = new Faker<LectureModel>();

            var lectureId = 1000;
            var currentSubjectId = 0;

            generator.StrictMode(true);
            generator.RuleFor(x => x.LectureId, f => lectureId++);
            generator.RuleFor(x => x.SubjectId, f => currentSubjectId);
            generator.RuleFor(x => x.Code, f => f.Random.AlphaNumeric(4));
            generator.RuleFor(x => x.Title, f => f.Commerce.Department());
            generator.RuleFor(x => x.Description, f => f.Lorem.Paragraph(1));
            generator.RuleFor(x => x.Day, f => f.Date.Future().DayOfWeek);
            generator.RuleFor(x => x.Start, f => f.Date.Future().TimeOfDay);
            generator.RuleFor(x => x.Duration, f => TimeSpan.FromMinutes(f.Random.Int(30, 60)));
            generator.RuleFor(x => x.LectureTheatreId, f => f.PickRandom(_lectureTheatreIds));

            var rng = new Random();

            var lectures = new List<LectureModel>();

            foreach (var subjectId in _subjectIds)
            {
                currentSubjectId = subjectId;

                var numRecords = rng.Next(minPerSubject, maxPerSubject + 1);

                lectures.AddRange(generator.Generate(numRecords));

            }

            using (var ctx = new InMemoryContextProvider().UniversityDbContext())
            {
                lectures.ForEach(x =>
                {
                    ctx.Lectures.Add(x);
                });

                ctx.SaveChanges();

            }
        }

        private void StudentSubjects(int minPerStudent, int maxPerStudent)
        {
            var rng = new Random();
            var faker = new Faker();

            var models = new List<StudentSubjectModel>();

            foreach (var studentId in _studentIds)
            {
                var numSubjects = rng.Next(minPerStudent, maxPerStudent + 1);
                var studentSubjects = new List<int>();

                for (int i = 0; i < numSubjects; i++)
                {
                    var subjectId = faker.PickRandom(_subjectIds);

                    if (studentSubjects.Contains(subjectId)) continue;

                    models.Add(new StudentSubjectModel
                    {
                        SubjectId = subjectId,
                        StudentId = studentId
                    });

                    studentSubjects.Add(subjectId);
                }
            }

            using (var ctx = new InMemoryContextProvider().UniversityDbContext())
            {
                models.ForEach(x => ctx.StudentSubject.Add(x));
                ctx.SaveChanges();
            }

        }
    }
}
