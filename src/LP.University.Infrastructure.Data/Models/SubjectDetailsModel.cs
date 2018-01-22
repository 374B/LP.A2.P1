using System.ComponentModel.DataAnnotations;

namespace LP.University.Infrastructure.Data.Models
{
    public class SubjectDetailsModel
    {
        [Key]
        public int SubjectId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
