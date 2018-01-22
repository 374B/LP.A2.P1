using System.Collections.Generic;
using System.Threading.Tasks;

namespace LP.University.Domain.Subject
{
    public interface  ISubjectService
    {
        Task<Subject> GetAggregateBySubjectId(int subjectId);

        Task<List<SubjectEnrollment>> GetEnrolledSubjectsByStudentId(int studentId);

        Task<SubjectDetailsItem> GetSubjectDetailsBySubjectId(int subjectId);
    }
}
