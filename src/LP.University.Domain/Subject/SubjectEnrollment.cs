namespace LP.University.Domain.Subject
{
    public class SubjectEnrollment
    {
        public Subject Subject { get; }

        public SubjectEnrollment(Subject subject)
        {
            Subject = subject;
        }
    }
}
