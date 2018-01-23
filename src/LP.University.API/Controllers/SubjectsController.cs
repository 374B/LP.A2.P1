using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LP.University.API.Dto;
using LP.University.API.Mappers;
using LP.University.Domain.Student;
using LP.University.Domain.Subject;

namespace LP.University.API.Controllers
{
    [Route("api/[controller]")]
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectsService;
        private readonly IStudentService _studentService;

        public SubjectsController(
            ISubjectService subjectsService,
            IStudentService studentService)
        {
            _subjectsService = subjectsService;
            _studentService = studentService;
        }

        /// <summary>
        /// Returns an array of subjects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<SubjectItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Subjects()
        {
            var subjects = await _subjectsService.GetSubjectDetailsAll();

            var mapper = new SubjectItemMapper();
            var dtos = subjects.Select(mapper.Map);

            return Ok(dtos);
        }

        /// <summary>
        /// Returns a specific subject via its subjectId
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        [HttpGet("{subjectId}")]
        [ProducesResponseType(typeof(SubjectItemDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Subject(int subjectId)
        {
            var subject = await _subjectsService.GetSubjectDetailsBySubjectId(subjectId);

            if (subject == null)
                return NotFound($"No resource found for subjectId: {subjectId}");

            var mapper = new SubjectItemMapper();

            var dto = mapper.Map(subject);

            return Ok(dto);

        }

        /// <summary>
        /// Enroll a specified student in a specified subject
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpPost("{subjectId}/enrollments/{studentId}")]
        public async Task<IActionResult> Enroll(int subjectId, int studentId)
        {
            var studentAggregate = await _studentService.GetAggregateByStudentId(studentId);
            var subjectAggregate = await _subjectsService.GetAggregateBySubjectId(subjectId);

            if (studentAggregate == null || subjectAggregate == null)
                return NotFound($"No resource found for subjectId {subjectId} and studentId {studentId}");

            if (!studentAggregate.CanEnroll(subjectAggregate, out var violations))
                return BadRequest(new DomainErrorDto(violations));

            await _subjectsService.EnrollStudent(subjectId, studentId);

           return Ok();

        }

    }
}
