using System;
using System.Collections.Generic;
using System.Linq;

namespace LP.University.Domain.Student
{
    public class Student
    {
        private readonly IStudentWorkloadCalculator _workloadCalculator;
        private readonly StudentDetails _studentDetails;
        private readonly List<Subject.Subject> _enrolledSubjects;

        public StudentDetails StudentDetails => _studentDetails;
        public IEnumerable<Subject.Subject> EnrolledSubjects => _enrolledSubjects;

        public TimeSpan WeeklyWorkload => _workloadCalculator.CalculateWeeklyWorkload(this);

        public Student(
            IStudentWorkloadCalculator workloadCalculator,
            StudentDetails studentDetails,
            IEnumerable<Subject.Subject> enrolledSubjects)
        {
            if (workloadCalculator == null) throw new ArgumentNullException(nameof(workloadCalculator));
            if (enrolledSubjects == null) throw new ArgumentNullException(nameof(enrolledSubjects));

            _workloadCalculator = workloadCalculator;
            _studentDetails = studentDetails;
            _enrolledSubjects = enrolledSubjects.ToList();

        }

    }
}
