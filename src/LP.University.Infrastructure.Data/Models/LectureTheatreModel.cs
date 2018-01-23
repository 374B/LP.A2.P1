using System.ComponentModel.DataAnnotations;

namespace LP.University.Infrastructure.Data.Models
{
    public class LectureTheatreModel
    {
        [Key]
        public int LectureTheatreId { get; set; }

        public int Capacity { get; set; }
    }
}
