using System.Collections.Generic;

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
                StudentDetails.Default(), 
                new List<Subject.Subject>());
        }

        public Student Create(StudentDetails studentDetails, IEnumerable<Subject.Subject> subjects)
        {
            var student = new Student(
                _workloadCalculator,
                studentDetails,
                subjects);

            return student;
        }

    }
}
