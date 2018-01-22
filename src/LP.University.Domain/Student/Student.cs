using System;
using System.Collections.Generic;
using System.Linq;
using LP.University.Core.Extensions;
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
            return _enrolledSubjects.Where(x =>
                x.Session.Start.InPast() && x.Session.End.InFuture());
        }

    }
}
