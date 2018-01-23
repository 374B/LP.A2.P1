using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LP.University.Domain.Lecture;
using LP.University.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LP.University.Infrastructure.Data.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly IDbContextProvider _contextProvider;

        public LectureRepository(IDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public async Task<List<Lecture>> GetLecturesBySubjectId(int subjectId)
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var query = from lecture in ctx.Lectures
                            join theatre in ctx.LectureTheatres on lecture.LectureTheatreId equals theatre.LectureTheatreId
                            where lecture.SubjectId == subjectId
                            select new { lecture, theatre };

                var results = await query.ToListAsync();

                var mapped = results.Select(x => Map(x.lecture, x.theatre)).ToList();

                return mapped;

            }
        }

        public async Task<List<Lecture>> GetLecturesBySubjectIds(IEnumerable<int> subjectIds)
        {
            using (var ctx = _contextProvider.UniversityDbContext())
            {
                var query = from lecture in ctx.Lectures
                            join theatre in ctx.LectureTheatres on lecture.LectureTheatreId equals theatre.LectureTheatreId
                            where subjectIds.Contains(lecture.SubjectId)
                            select new { lecture, theatre };

                var results = await query.ToListAsync();

                var mapped = results.Select(x => Map(x.lecture, x.theatre)).ToList();

                return mapped;

            }
        }

        //TODO: Mapping shouldn't be here
        private Lecture Map(LectureModel lectureModel, LectureTheatreModel lectureTheatreModel)
        {
            var theatre = new LectureTheatreItem(lectureTheatreModel.LectureTheatreId, lectureTheatreModel.Capacity);

            return new Lecture
            {
                SubjectId = lectureModel.SubjectId,
                Code = lectureModel.Code,
                Day = lectureModel.Day,
                Description = lectureModel.Description,
                Duration = lectureModel.Duration,
                LectureId = lectureModel.LectureId,
                Start = lectureModel.Start,
                Title = lectureModel.Title,
                LectureTheatre = theatre
            };
        }

    }
}
