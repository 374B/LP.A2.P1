using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LP.University.API.Dto;

namespace LP.University.API.Controllers
{
    [Route("api/[controller]")]
    public class SubjectsController : Controller
    {
        [HttpGet]
        public IEnumerable<SubjectDto> Subjects()
        {
            return new List<SubjectDto>();
        }

        [HttpGet("{subjectId}")]
        public SubjectDto Subject(int subjectId)
        {
            return new SubjectDto();
        }

        [HttpGet("{subjectId}/enrollments")]
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
