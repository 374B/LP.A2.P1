using System.Collections.Generic;
using System.Threading.Tasks;

namespace LP.University.Domain.Student
{
    public interface IStudentService
    {
        Task<Student> GetAggregateByStudentId(int studentId);

        Task<StudentDetailsItem> GetDetailsByStudentId(int studentId);

        Task<List<StudentDetailsItem>> GetDetailsAll();
    }
}
