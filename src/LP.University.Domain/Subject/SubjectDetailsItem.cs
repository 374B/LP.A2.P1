namespace LP.University.Domain.Subject
{
    public class SubjectDetailsItem
    {
        public int SubjectId { get; }
        public string Code { get; }
        public string Name { get; }
        public string Description { get; }

        public SubjectDetailsItem(
            int subjectId,
            string code,
            string name,
            string description)
        {
            SubjectId = subjectId;
            Code = code;
            Name = name;
            Description = description;
        }

    }
}
