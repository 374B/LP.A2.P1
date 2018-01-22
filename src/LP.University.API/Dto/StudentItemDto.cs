using System;

namespace LP.University.API.Dto
{
    public class StudentItemDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public StudentItemLinks Links { get; set; }

        public StudentItemDto()
        {
            Links = new StudentItemLinks();
        }

        public class StudentItemLinks //: LinksCollection
        {
            public LinkDto Details { get; set; }
        }

    }
}
