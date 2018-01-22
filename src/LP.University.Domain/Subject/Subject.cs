using System;
using System.Collections.Generic;
using System.Linq;

namespace LP.University.Domain.Subject
{
    public class Subject
    {
        private readonly List<Lecture.Lecture> _lectures;

        public IEnumerable<Lecture.Lecture> Lectures => _lectures;
        public SubjectDetailsItem SubjectDetails { get; }

        public Subject(SubjectDetailsItem subjectDetails)
             : this(subjectDetails, new List<Lecture.Lecture>())
        {
        }

        public Subject(
            SubjectDetailsItem subjectDetails, 
            IEnumerable<Lecture.Lecture> lectures)
        {
            if (subjectDetails == null) throw new ArgumentNullException(nameof(subjectDetails));
            if (lectures == null) throw new ArgumentNullException(nameof(lectures));

            SubjectDetails = subjectDetails;
            _lectures = lectures.ToList();
        }

        public void Enroll(Student.Student student)
        {

        }
    }
}
