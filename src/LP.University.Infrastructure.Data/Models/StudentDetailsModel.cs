using System;
using System.ComponentModel.DataAnnotations;

namespace LP.University.Infrastructure.Data.Models
{
    public class StudentDetailsModel
    {
        [Key]
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
