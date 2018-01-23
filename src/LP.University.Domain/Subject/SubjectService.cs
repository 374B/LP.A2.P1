using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LP.University.Domain.Lecture;

namespace LP.University.Domain.Subject
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISubjectFactory _subjectFactory;
        private readonly ILectureRepository _lectureRepository;

        public SubjectService(
            ISubjectRepository subjectRepository,
            ISubjectFactory subjectFactory,
            ILectureRepository lectureRepository)
        {
            _subjectRepository = subjectRepository;
            _subjectFactory = subjectFactory;
            _lectureRepository = lectureRepository;
        }

        public async Task<Subject> GetAggregateBySubjectId(int subjectId)
        {
            var details = await _subjectRepository.GetDetailsBySubjectId(subjectId);

            if (details == null) return null;

            var lectures = await _lectureRepository.GetLecturesBySubjectId(subjectId);
            var enrollments = await _subjectRepository.GetEnrollmentsBySubjectId(subjectId);

            var subject = _subjectFactory.CreateSubject(details, lectures, enrollments);

            return subject;
        }

        public async Task<List<SubjectEnrollment>> GetEnrolledSubjectsByStudentId(int studentId)
        {
            var studentEnrollments = await _subjectRepository.GetEnrollmentsByStudentId(studentId);

            if (!studentEnrollments.Any())
                return new List<SubjectEnrollment>();

            var subjectIds = studentEnrollments.Select(x => x.SubjectId).ToList();

            var subjects = await _subjectRepository.GetDetailsBySubjectIds(subjectIds);
            var subjectsDict = subjects.ToDictionary(x => x.SubjectId, x => x);

            var lectures = await _lectureRepository.GetLecturesBySubjectIds(subjectIds);

            var subjectEnrollments = await _subjectRepository.GetEnrollmentsBySubjectIds(subjectIds);

            var result = new List<SubjectEnrollment>();

            foreach (var item in studentEnrollments)
            {
                //Get the subject for this enrollment
                var s = subjectsDict[item.SubjectId];

                //Get the lectures for this enrollment
                var l = lectures.Where(x => x.SubjectId == item.SubjectId);

                //Get a list of other students enrolled in this subject
                var e = subjectEnrollments.Where(x => x.SubjectId == item.SubjectId);

                var se = _subjectFactory.CreateSubjectEnrollment(s, l, e);

                result.Add(se);

            }

            return result;

        }

        public async Task<SubjectDetailsItem> GetSubjectDetailsBySubjectId(int subjectId)
        {
            return await _subjectRepository.GetDetailsBySubjectId(subjectId);
        }

        public async Task<List<SubjectDetailsItem>> GetSubjectDetailsAll()
        {
            return await _subjectRepository.GetDetailsAll();
        }

        public async Task EnrollStudent(int subjectId, int studentId)
        {
           await  _subjectRepository.AddEnrollment(subjectId, studentId);
        }

    }
}
