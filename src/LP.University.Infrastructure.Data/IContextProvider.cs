namespace LP.University.Infrastructure.Data
{
    public interface IDbContextProvider
    {
        UniversityDbContext UniversityDbContext();
    }
}
