using System;

namespace LP.University.Domain.Student
{
    public class StudentDetails
    {
        public static StudentDetails Default()
        {
            return new StudentDetails(0, string.Empty, string.Empty, new DateTime());
        }

        public int StudentId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }

        public StudentDetails(
            int studentId,
            string firstName,
            string lastName,
            DateTime dateOfBirth)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }

    public class NewStudentDetailsCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
