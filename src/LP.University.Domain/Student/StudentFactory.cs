using System.Collections.Generic;
using LP.University.Domain.Subject;

namespace LP.University.Domain.Student
{
    public class StudentFactory : IStudentFactory
    {
        private readonly IStudentWorkloadCalculator _workloadCalculator;

        public StudentFactory(IStudentWorkloadCalculator workloadCalculator)
        {
            _workloadCalculator = workloadCalculator;
        }

        public Student Create()
        {
            return Create(
                StudentDetailsItem.Default(), 
                new List<SubjectEnrollment>());
        }

        public Student Create(StudentDetailsItem studentDetails, IEnumerable<SubjectEnrollment> subjects)
        {
            var student = new Student(
                _workloadCalculator,
                studentDetails,
                subjects);

            return student;
        }

    }
}
