using System.Collections.Generic;

namespace LP.University.Domain.Subject
{
    public interface ISubjectFactory
    {
        Subject CreateSubject(SubjectDetailsItem subjectDetails, IEnumerable<Lecture.Lecture> lectures, IEnumerable<SubjectEnrollmentItem> enrollments);

        SubjectEnrollment CreateSubjectEnrollment(Subject subject);

        SubjectEnrollment CreateSubjectEnrollment(SubjectDetailsItem subjectDetails, IEnumerable<Lecture.Lecture> lectures, IEnumerable<SubjectEnrollmentItem> enrollments);
    }
}
