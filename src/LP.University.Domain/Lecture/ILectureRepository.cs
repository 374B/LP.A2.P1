using System.Collections.Generic;
using System.Threading.Tasks;

namespace LP.University.Domain.Lecture
{
    public interface ILectureRepository
    {
        Task<List<Lecture>> GetLecturesBySubjectId(int subjectId);

        Task<List<Lecture>> GetLecturesBySubjectIds(IEnumerable<int> subjectIds);
    }
}
