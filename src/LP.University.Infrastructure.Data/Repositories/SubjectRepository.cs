using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LP.University.Domain.Subject;
using LP.University.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LP.University.Infrastructure.Data.Repositories
{
    //TODO: Split enrollments into a different repo
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IDbContextProvider _contextProvider;

        public SubjectRepository(IDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public async Task<List<SubjectDetailsItem>> GetDetailsAll()
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var details = await ctx.SubjectDetails.ToListAsync();

                var mapped = details.Select(Map).ToList();

                return mapped;

            }
        }

        public async Task<SubjectDetailsItem> GetDetailsBySubjectId(int subjectId)
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var detail = await ctx.SubjectDetails.SingleOrDefaultAsync(
                    x => x.SubjectId == subjectId);

                if (detail == null)
                    return null;

                var mapped = Map(detail);

                return mapped;

            }
        }

        public async Task<List<SubjectDetailsItem>> GetDetailsBySubjectIds(IEnumerable<int> subjectIds)
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var details = await ctx.SubjectDetails.Where(x => subjectIds.Contains(x.SubjectId))
                    .ToListAsync();


                var mapped = details.Select(Map).ToList();

                return mapped;

            }
        }

        public async Task<List<SubjectEnrollmentItem>> GetEnrollmentsBySubjectId(int subjectId)
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var enrollments = await ctx.StudentSubject.Where(x => x.SubjectId == subjectId)
                    .ToListAsync();

                var mapped = enrollments.Select(Map).ToList();

                return mapped;
            }
        }

        public async Task<List<SubjectEnrollmentItem>> GetEnrollmentsBySubjectIds(IEnumerable<int> subjectIds)
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var enrollments = await ctx.StudentSubject.Where(x => subjectIds.Contains(x.SubjectId))
                    .ToListAsync();

                var mapped = enrollments.Select(Map).ToList();

                return mapped;
            }
        }

        public async Task<List<SubjectEnrollmentItem>> GetEnrollmentsByStudentId(int studentId)
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var enrollments = await ctx.StudentSubject.Where(x => x.StudentId == studentId)
                    .ToListAsync();

                var mapped = enrollments.Select(Map).ToList();

                return mapped;
            }
        }

        public async Task AddEnrollment(int subjectId, int studentId)
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                ctx.StudentSubject.Add(new StudentSubjectModel
                {
                    SubjectId = subjectId,
                    StudentId = studentId
                });

                await ctx.SaveChangesAsync();
            }
        }

        //TODO: Mapping shouldn't be here
        private SubjectDetailsItem Map(SubjectDetailsModel model)
        {
            return new SubjectDetailsItem(
                model.SubjectId,
                model.Code,
                model.Name,
                model.Description);
        }

        //TODO: Mapping shouldn't be here
        private SubjectEnrollmentItem Map(StudentSubjectModel model)
        {
            return new SubjectEnrollmentItem
            {
                SubjectId = model.SubjectId,
                StudentId = model.SubjectId
            };
        }

    }
}