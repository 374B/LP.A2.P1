using System.Collections.Generic;
using System.Threading.Tasks;
using LP.University.Domain.Subject;

namespace LP.University.Domain.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentFactory _studentFactory;
        private readonly ISubjectService _subjectService;

        public StudentService(
            IStudentRepository studentRepository,
            IStudentFactory studentFactory,
            ISubjectService subjectService)
        {
            _studentRepository = studentRepository;
            _studentFactory = studentFactory;
            _subjectService = subjectService;
        }

        public async Task<Student> GetAggregateByStudentId(int studentId)
        {
            var details = await _studentRepository.GetDetailsByStudentId(studentId);

            if (details == null) return null;

            var enrolledSubjects = await _subjectService.GetEnrolledSubjectsByStudentId(studentId) ?? new List<SubjectEnrollment>();

            var student = _studentFactory.Create(details, enrolledSubjects);

            return student;

        }

        public async Task<StudentDetailsItem> GetDetailsByStudentId(int studentId)
        {
            return await _studentRepository.GetDetailsByStudentId(studentId);
        }

        public async Task<List<StudentDetailsItem>> GetDetailsAll()
        {
            return await _studentRepository.GetDetailsAll();
        }

    }
}
