using System.Collections.Generic;

namespace LP.University.Domain.Student
{
    public interface IStudentFactory
    {
        Student Create();

        Student Create(StudentDetails studentDetails, IEnumerable<Subject.Subject> subjects);

    }
}
