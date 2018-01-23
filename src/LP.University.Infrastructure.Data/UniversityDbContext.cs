using LP.University.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LP.University.Infrastructure.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions options) : base(options) { }

        public DbSet<StudentDetailsModel> StudentDetails { get; set; }
        public DbSet<SubjectDetailsModel> SubjectDetails { get; set; }
        public DbSet<LectureModel> Lectures { get; set; }
        public DbSet<LectureTheatreModel> LectureTheatres { get; set; }
        public DbSet<StudentSubjectModel> StudentSubject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubjectModel>().HasKey(x => new { x.StudentId, x.SubjectId });
        }
    }
}
