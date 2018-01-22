using LP.University.Domain.Student;
using LP.University.Domain.Subject;
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

            //Student
            services.AddSingleton<IStudentFactory, StudentFactory>();
            services.AddSingleton<IStudentRepository, StudentRepository>();
            services.AddSingleton<IStudentService, StudentService>();
            services.AddSingleton<IStudentWorkloadCalculator, StudentWorkloadCalculator>();

            //Subject
            services.AddSingleton<ISubjectFactory, SubjectFactory>();
            services.AddSingleton<ISubjectRepository, SubjectRepository>();
            services.AddSingleton<ISubjectService, SubjectService>();

        }
    }
}
