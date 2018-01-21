using System.Collections.Generic;
using System.Threading.Tasks;

namespace LP.University.Domain.Student
{
    public interface IStudentDetailsRepository
    {
        Task<StudentDetails> GetByStudentId(int studentId);

        Task<List<StudentDetails>> GetAll();
    }
}
