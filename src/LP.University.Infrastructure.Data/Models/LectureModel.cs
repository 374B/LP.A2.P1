using System;
using System.ComponentModel.DataAnnotations;

namespace LP.University.Infrastructure.Data.Models
{
    //TODO: SubjectId should not be here
    //... As this model does not support the case that a lecture could be offered in multiple subjects
    public class LectureModel
    {
        [Key]
        public int LectureId { get; set; }
        public int SubjectId { get; set; }
        public int LectureTheatreId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DayOfWeek Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
