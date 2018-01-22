using System.Collections.Generic;
using LP.University.Domain.Subject;

namespace LP.University.Domain.Student
{
    public interface IStudentFactory
    {
        Student Create();

        Student Create(
            StudentDetailsItem studentDetails, 
            IEnumerable<SubjectEnrollment> subjects);

    }
}
