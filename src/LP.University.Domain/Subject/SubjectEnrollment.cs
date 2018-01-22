namespace LP.University.Domain.Subject
{
    public class SubjectEnrollment
    {
        public Subject Subject { get; }
        public SubjectSession Session { get; }

        public SubjectEnrollment(
            Subject subject, 
            SubjectSession session)
        {
            Subject = subject;
            Session = session;
        }
    }
}
