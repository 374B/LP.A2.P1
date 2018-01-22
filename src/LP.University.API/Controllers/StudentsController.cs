using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LP.University.API.Dto;
using LP.University.Domain.Student;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LP.University.API.Extensions;
using LP.University.API.Mappers;

namespace LP.University.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        //TODO: Remove route provider, hard code
        //TODO: Link to enrollment

        public const string RouteStudentDetails = "StudentDetails";
        public const string RouteStudentSubjects = "StudentSubjects";

        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            if (studentService == null) throw new ArgumentNullException(nameof(studentService));

            _studentService = studentService;
        }

        /// <summary>
        /// Returns an array of students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<StudentItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var studentDetails = await _studentService.GetDetailsAll();
            var mapper = new StudentItemMapper();

            var dtos = new List<StudentItemDto>();

            foreach (var item in studentDetails)
            {
                var dto = mapper.Map(item);

                dto.Links.Details = RouteStudentDetails.GetLink(this, new { studentId = item.StudentId });

                dtos.Add(dto);

            }

            return Ok(dtos);
        }

        /// <summary>
        /// Returns a specific student via its studentId
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("{studentId}", Name = RouteStudentDetails)]
        [ProducesResponseType(typeof(StudentDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int studentId)
        {
            var studentDetails = await _studentService.GetDetailsByStudentId(studentId);

            if (studentDetails == null)
                return NotFound($"No resource found for studentId: {studentId}");

            var dto = new StudentDetailsMapper().Map(studentDetails);
            dto.Links.Subjects = RouteStudentSubjects.GetLink(this, new { studentId = studentId });

            return Ok(dto);

        }

        /// <summary>
        /// Returns an array of the specified student's subjects
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("{studentId}/subjects", Name = RouteStudentSubjects)]
        [ProducesResponseType(typeof(List<SubjectItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> StudentSubjects(int studentId)
        {
            var student = await _studentService.GetAggregateByStudentId(studentId);

            if (student == null)
                return NotFound($"No resource found for studentId: {studentId}");

            var subjects = student.CurrentSubjects();

            var mapper = new SubjectItemMapper();

            var dtos = subjects.Select(mapper.Map);

            return Ok(dtos);

        }
    }
}

