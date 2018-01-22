using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using LP.University.API.Dto;

namespace LP.University.API.Controllers
{
    [Route("api/[controller]")]
    public class SubjectsController : Controller
    {
        public const string RouteNameSubjectDetails = "SubjectDetails";

        [HttpGet]
        public IEnumerable<SubjectDetailsDto> Subjects()
        {
            return new List<SubjectDetailsDto>();
        }

        [HttpGet("{subjectId}", Name = RouteNameSubjectDetails)]
        public SubjectDetailsDto Subject(int subjectId)
        {
            return new SubjectDetailsDto();
        }

        [HttpGet("{subjectId}/enrollments")]
        [ProducesResponseType(typeof(StudentItemDto), (int)HttpStatusCode.OK)]
        public object SubjectEnrollments(int subjectId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{subjectId}/enrollments/{studentId}")]
        public IActionResult Enroll(int subjectId, int studentId)
        {
            throw new NotImplementedException();

        }

    }
}
