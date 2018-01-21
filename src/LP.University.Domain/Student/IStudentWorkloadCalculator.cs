using System;
using System.Collections.Generic;

namespace LP.University.Domain.Student
{
    public interface IStudentWorkloadCalculator
    {
        TimeSpan CalculateWeeklyWorkload(Student student);
        TimeSpan CalculateWeeklyWorkload(IEnumerable<Subject.Subject> subjects);
        TimeSpan CalculateWeeklyWorkload(IEnumerable<Lecture.Lecture> lectures);
    }
}
