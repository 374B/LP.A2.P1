using System;

namespace LP.University.API.Dto
{
    public class StudentDetailsDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public StudentDetailsLinks Links { get; set; }

        public StudentDetailsDto()
        {
            Links = new StudentDetailsLinks();
        }

        public class StudentDetailsLinks// : LinksCollection
        {
            public LinkDto Subjects { get; set; }
        }

    }
}
