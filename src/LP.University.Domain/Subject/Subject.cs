using System;
using System.Collections.Generic;
using System.Linq;

namespace LP.University.Domain.Subject
{
    public class Subject
    {
        private readonly List<Lecture.Lecture> _lectures;
        private readonly List<SubjectEnrollmentItem> _studentIds;

        public IEnumerable<Lecture.Lecture> Lectures => _lectures;
        public SubjectDetailsItem SubjectDetails { get; }
        public int Enrollments => _studentIds.Count;

        public Subject(
            SubjectDetailsItem subjectDetails, 
            IEnumerable<Lecture.Lecture> lectures,
            IEnumerable<SubjectEnrollmentItem> subjectEnrollments)
        {
            if (subjectDetails == null) throw new ArgumentNullException(nameof(subjectDetails));
            if (lectures == null) throw new ArgumentNullException(nameof(lectures));
            if (subjectEnrollments == null) throw new ArgumentNullException(nameof(subjectEnrollments));

            SubjectDetails = subjectDetails;
            _lectures = lectures.ToList();
            _studentIds = subjectEnrollments.ToList();
        }
    }
}
