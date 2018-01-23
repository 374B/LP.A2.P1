using System.Collections.Generic;
using System.Threading.Tasks;

namespace LP.University.Domain.Subject
{
    public interface ISubjectRepository
    {
        Task<List<SubjectDetailsItem>> GetDetailsAll();

        Task<SubjectDetailsItem> GetDetailsBySubjectId(int subjectId);

        Task<List<SubjectDetailsItem>> GetDetailsBySubjectIds(IEnumerable<int> subjectIds);

        Task<List<SubjectEnrollmentItem>> GetEnrollmentsBySubjectId(int subjectId);

        Task<List<SubjectEnrollmentItem>> GetEnrollmentsBySubjectIds(IEnumerable<int> subjectIds);

        Task<List<SubjectEnrollmentItem>> GetEnrollmentsByStudentId(int studentId);

        Task AddEnrollment(int subjectId, int studentId);

    }
}
