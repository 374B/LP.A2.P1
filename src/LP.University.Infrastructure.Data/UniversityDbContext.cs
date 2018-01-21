using LP.University.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LP.University.Infrastructure.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions options) : base(options) { }

        public DbSet<StudentDetailsModel> StudentDetails { get; set; }
    }
}
