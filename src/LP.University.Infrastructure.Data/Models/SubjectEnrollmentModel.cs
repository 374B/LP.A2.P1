using System.ComponentModel.DataAnnotations;

namespace LP.University.Infrastructure.Data.Models
{
    public class SubjectEnrollmentModel
    {
        [Key]
        public int SubjectId { get; set; }

        [Key]
        public int StudentId { get; set; }

        [Key]
        public int SessionId { get; set; }
    }
}
