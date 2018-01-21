using LP.University.Domain.Student;
using LP.University.Infrastructure.Data;
using LP.University.Infrastructure.Data.InMemory;
using LP.University.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LP.University.Infrastructure.Registrar
{
    public class Registrar
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IDbContextProvider, InMemoryContextProvider>();

            services.AddSingleton<IStudentFactory, StudentFactory>();
            services.AddSingleton<IStudentDetailsRepository, StudentDetailsRepository>();
        }
    }
}
