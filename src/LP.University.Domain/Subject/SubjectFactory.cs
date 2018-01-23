using System;
using System.Collections.Generic;

namespace LP.University.Domain.Subject
{
    public class SubjectFactory : ISubjectFactory
    {
        public Subject CreateSubject(
            SubjectDetailsItem subjectDetails,
            IEnumerable<Lecture.Lecture> lectures,
            IEnumerable<SubjectEnrollmentItem> enrollments)
        {
            if (subjectDetails == null) throw new ArgumentNullException(nameof(subjectDetails));
            if (lectures == null) throw new ArgumentNullException(nameof(lectures));

            var subject = new Subject(subjectDetails, lectures, enrollments);
            return subject;
        }

        public SubjectEnrollment CreateSubjectEnrollment(Subject subject)
        {
            var enrollment = new SubjectEnrollment(subject);
            return enrollment;
        }

        public SubjectEnrollment CreateSubjectEnrollment(SubjectDetailsItem subjectDetails, IEnumerable<Lecture.Lecture> lectures, IEnumerable<SubjectEnrollmentItem> enrollments)
        {
            if (subjectDetails == null) throw new ArgumentNullException(nameof(subjectDetails));
            if (lectures == null) throw new ArgumentNullException(nameof(lectures));

            var subject = CreateSubject(subjectDetails, lectures, enrollments);
            var enrollment = CreateSubjectEnrollment(subject);

            return enrollment;
        }
    }
}
