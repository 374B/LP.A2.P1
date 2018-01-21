using Microsoft.EntityFrameworkCore;

namespace LP.University.Infrastructure.Data.InMemory
{
    public class InMemoryContextProvider : IDbContextProvider
    {
        private const string UnivesityDbName = "LP.University.DB";

        private readonly DbContextOptions<UniversityDbContext> _universityDbOptions;

        public InMemoryContextProvider()
        {
            var universityOptionsBuilder = new DbContextOptionsBuilder<UniversityDbContext>();
            universityOptionsBuilder.UseInMemoryDatabase(UnivesityDbName);

            _universityDbOptions = universityOptionsBuilder.Options;

        }

        public UniversityDbContext UniversityDbContext()
        {
            return new UniversityDbContext(_universityDbOptions);
        }
    }
}
