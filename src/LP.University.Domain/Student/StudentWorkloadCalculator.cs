using System;
using System.Collections.Generic;
using System.Linq;
using LP.University.Core.Extensions;

namespace LP.University.Domain.Student
{
    public class StudentWorkloadCalculator : IStudentWorkloadCalculator
    {
        public TimeSpan CalculateWeeklyWorkload(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));

            var subjects = student.CurrentSubjects()
                .Select(x => x.Subject);

            return CalculateWeeklyWorkload(subjects);
        }

        public TimeSpan CalculateWeeklyWorkload(IEnumerable<Subject.Subject> subjects)
        {
            if (subjects == null) throw new ArgumentNullException(nameof(subjects));

            var lectures = subjects.SelectMany(x => x.Lectures);

            return CalculateWeeklyWorkload(lectures);
        }

        public TimeSpan CalculateWeeklyWorkload(IEnumerable<Lecture.Lecture> lectures)
        {
            if (lectures == null) throw new ArgumentNullException(nameof(lectures));

            var total = lectures.Sum(x => x.Duration);

            return total;
        }
    }
}
