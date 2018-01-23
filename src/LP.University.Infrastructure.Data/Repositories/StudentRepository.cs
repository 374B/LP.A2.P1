using System;
using LP.University.Domain.Student;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LP.University.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LP.University.Infrastructure.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContextProvider _contextProvider;

        public StudentRepository(IDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public async Task<StudentDetailsItem> GetDetailsByStudentId(int studentId)
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var model = await ctx.StudentDetails.SingleOrDefaultAsync(x => x.StudentId == studentId);

                if (model == null)
                    return null;

                var mapped = Map(model);
                return mapped;
            }
        }

        public async Task<List<StudentDetailsItem>> GetDetailsAll()
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var models = await ctx.StudentDetails.ToListAsync();
                var mapped = models.Select(Map).ToList();
                return mapped;
            }
        }

        //TODO: Mapping shouldn't be here
        private StudentDetailsItem Map(StudentDetailsModel model)
        {
            return new StudentDetailsItem(
                model.StudentId,
                model.FirstName,
                model.LastName,
                model.DateOfBirth);
        }
    }
}
