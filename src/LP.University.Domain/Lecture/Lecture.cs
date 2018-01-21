using System;

namespace LP.University.Domain.Lecture
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DayOfWeek Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan End => Start + Duration;
    }
}
