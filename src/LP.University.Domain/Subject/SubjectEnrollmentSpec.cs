using System;
using System.Collections.Generic;
using LP.University.Core.Spec;
using LP.University.Domain.Student;

namespace LP.University.Domain.Subject
{
    public class SubjectEnrollmentSpec : SpecList
    {
        private readonly Lecture.Lecture _lecture;
        private readonly Student.Student _student;

        public SubjectEnrollmentSpec(
            Lecture.Lecture lecture,
            Student.Student student)
        {
            if (lecture == null) throw new ArgumentNullException(nameof(lecture));
            if (student == null) throw new ArgumentNullException(nameof(student));

            _lecture = lecture;
            _student = student;
        }

        protected override IEnumerable<ISpec> Specifications()
        {
            var specs = new List<ISpec>();

            specs.Add(new LectureTheatreMustHaveCapacitySpec());
            //specs.Add(new StudentMustNotExceedMaximumWeeklyWorkloadSpec());

            return specs;
        }
    }

    public class StudentMustNotExceedMaximumWeeklyWorkloadSpec : ISpec
    {
        private readonly Student.Student _student;
        private readonly TimeSpan _maximumWeeklyWorkload;

        public string Description => $"A student must not have more than {_maximumWeeklyWorkload} lectures per week";

        public StudentMustNotExceedMaximumWeeklyWorkloadSpec(
            Student.Student student,
            TimeSpan maximumWeeklyWorkload)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));

            _student = student;
            _maximumWeeklyWorkload = maximumWeeklyWorkload;
        }

        public bool IsSatisfied()
        {
            return _student.WeeklyWorkload <= _maximumWeeklyWorkload;
        }
    }

    public class LectureTheatreMustHaveCapacitySpec : ISpec
    {
        public string Description { get; }

        public bool IsSatisfied()
        {
            throw new NotImplementedException();
        }
    }
}
