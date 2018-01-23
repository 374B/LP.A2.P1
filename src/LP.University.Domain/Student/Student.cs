using System;
using System.Collections.Generic;
using System.Linq;
using LP.University.Domain.Subject;

namespace LP.University.Domain.Student
{
    public class Student
    {
        private readonly IStudentWorkloadCalculator _workloadCalculator;
        private readonly List<SubjectEnrollment> _enrolledSubjects;

        public StudentDetailsItem StudentDetails { get; }

        public TimeSpan WeeklyWorkload => _workloadCalculator.CalculateWeeklyWorkload(this);

        public Student(
            IStudentWorkloadCalculator workloadCalculator,
            StudentDetailsItem studentDetails,
            IEnumerable<SubjectEnrollment> enrolledSubjects)
        {
            if (workloadCalculator == null) throw new ArgumentNullException(nameof(workloadCalculator));
            if (enrolledSubjects == null) throw new ArgumentNullException(nameof(enrolledSubjects));

            _workloadCalculator = workloadCalculator;
            StudentDetails = studentDetails;
            _enrolledSubjects = enrolledSubjects.ToList();

        }

        public IEnumerable<SubjectEnrollment> AllSubjects()
        {
            return _enrolledSubjects;
        }

        public IEnumerable<SubjectEnrollment> CurrentSubjects()
        {
            //TODO: There is no concept of subject sessions so let's return all subjects for now
            return AllSubjects();
        }

        public bool CanEnroll(Subject.Subject subject, out IEnumerable<string> violations)
        {
            var specList = new SubjectEnrollmentSpec(subject, this);
            var result = specList.IsSatisfied();

            violations = result.Violations;
            return result.IsSatisifed;
            
        }
    }
}
