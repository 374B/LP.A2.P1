using System;
using System.Collections.Generic;
using System.Linq;
using LP.University.Core.Spec;

namespace LP.University.Domain.Subject
{
    public class SubjectEnrollmentSpec : SpecList
    {
        //TODO: This shouldn't be here
        private static TimeSpan MaxAllowedWorkload = TimeSpan.FromHours(10);

        private readonly Subject _subject;
        private readonly Student.Student _student;

        public SubjectEnrollmentSpec(
            Subject subject,
            Student.Student student)
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject));
            if (student == null) throw new ArgumentNullException(nameof(student));

            _subject = subject;
            _student = student;
        }

        protected override IEnumerable<ISpec> Specifications()
        {
            var specs = new List<ISpec>();

            specs.Add(new StudentMustNotAlreadyBeEnrolledSpec(_student, _subject));
            specs.Add(new LectureTheatresMustHaveCapacitySpec(_subject));
            specs.Add(new StudentMustNotExceedMaximumWeeklyWorkloadSpec(_student, _subject, MaxAllowedWorkload));

            return specs;
        }
    }

    public class StudentMustNotAlreadyBeEnrolledSpec : ISpec
    {
        private readonly Student.Student _student;
        private readonly Subject _subject;

        public string Description => $"A student must not enroll in the same subject twice";

        public StudentMustNotAlreadyBeEnrolledSpec(Student.Student student, Subject subject)
        {
            _student = student;
            _subject = subject;
        }

        public bool IsSatisfied()
        {
            var match = _student.CurrentSubjects()
                .FirstOrDefault(x => x.Subject.SubjectDetails.SubjectId == _subject.SubjectDetails.SubjectId);

            //If there is a match, the student is already in this subject
            //... therefore, this spec is satisfied if the match is null

            return match == null;

        }
    }

    public class StudentMustNotExceedMaximumWeeklyWorkloadSpec : ISpec
    {
        private readonly Student.Student _student;
        private readonly Subject _subject;
        private readonly TimeSpan _maximumWeeklyWorkload;

        public string Description => $"A student must not have more than {_maximumWeeklyWorkload} lectures per week";

        public StudentMustNotExceedMaximumWeeklyWorkloadSpec(
            Student.Student student,
            Subject subject,
            TimeSpan maximumWeeklyWorkload)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));

            _student = student;
            _subject = subject;
            _maximumWeeklyWorkload = maximumWeeklyWorkload;
        }

        public bool IsSatisfied()
        {
            //The extra workload is the sum of all of the lectures for the subject
            var extraWork = TimeSpan.FromTicks(_subject.Lectures.Sum(x => x.Duration.Ticks));
            var totalWork = _student.WeeklyWorkload + extraWork;

            return totalWork <= _maximumWeeklyWorkload;
        }
    }

    public class LectureTheatresMustHaveCapacitySpec : ISpec
    {
        private readonly Subject _subject;

        public string Description => $"All lecture theatres in the subject must have capacity for a new student";

        public LectureTheatresMustHaveCapacitySpec(Subject subject)
        {
            _subject = subject;
        }

        public bool IsSatisfied()
        {
            //The minimum capacity we need is the number of students in the subject + 1 for the new enrollment
            var minCapacity = _subject.Enrollments + 1;

            //If any of the lecture theatres do not have the minimum capacity, this spec is not satisfied
            if (_subject.Lectures.Any(x => x.LectureTheatre.Capacity < minCapacity))
                return false;

            return true;
        }
    }
}
