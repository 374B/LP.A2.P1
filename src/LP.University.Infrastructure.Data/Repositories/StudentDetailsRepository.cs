using LP.University.Domain.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LP.University.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LP.University.Infrastructure.Data.Repositories
{
    public class StudentDetailsRepository : IStudentDetailsRepository
    {
        private readonly IDbContextProvider _contextProvider;

        public StudentDetailsRepository(IDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public async Task<StudentDetails> GetByStudentId(int studentId)
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var model = await ctx.StudentDetails.SingleAsync(x => x.StudentId == studentId);

                if (model == null)
                    return null;

                var mapped = Map(model);
                return mapped;
            }
        }

        public async Task<List<StudentDetails>> GetAll()
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var models = await ctx.StudentDetails.ToListAsync();
                var mapped = models.Select(Map).ToList();
                return mapped;
            }
        }

        //TODO: Mapping shouldn't be here
        private StudentDetails Map(StudentDetailsModel model)
        {
            return new StudentDetails(
                model.StudentId,
                model.FirstName,
                model.LastName,
                model.DateOfBirth);
        }
    }
}
