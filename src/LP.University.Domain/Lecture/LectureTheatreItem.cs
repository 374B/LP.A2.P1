namespace LP.University.Domain.Lecture
{
    public class LectureTheatreItem
    {
        public int LectureTheatreId { get; }
        public int Capacity { get; }

        public LectureTheatreItem(int lectureTheatreId, int capacity)
        {
            LectureTheatreId = lectureTheatreId;
            Capacity = capacity;
        }

    }
}
