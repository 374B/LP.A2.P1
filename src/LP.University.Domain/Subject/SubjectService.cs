using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LP.University.Domain.Subject
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public Task<Subject> GetAggregateBySubjectId(int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubjectEnrollment>> GetEnrolledSubjectsByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<SubjectDetailsItem> GetSubjectDetailsBySubjectId(int subjectId)
        {
            throw new NotImplementedException();
        }
    }
}
