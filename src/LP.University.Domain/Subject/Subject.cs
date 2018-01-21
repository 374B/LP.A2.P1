using System;
using System.Collections.Generic;
using System.Linq;

namespace LP.University.Domain.Subject
{
    public class Subject
    {
        private readonly List<Lecture.Lecture> _lectures;

        public IEnumerable<Lecture.Lecture> Lectures => _lectures;

        public Subject()
             : this(new List<Lecture.Lecture>())
        {
        }

        public Subject(IEnumerable<Lecture.Lecture> lectures)
        {
            if (lectures == null) throw new ArgumentNullException(nameof(lectures));

            _lectures = lectures.ToList();
        }

        public void Enroll(Student.Student student)
        {

        }

    }
}
