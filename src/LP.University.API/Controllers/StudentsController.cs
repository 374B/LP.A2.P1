using System.Collections.Generic;
using System.Linq;
using LP.University.API.Dto;
using LP.University.Domain.Student;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LP.University.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        //TODO: Review use of repository at this layer
        private readonly IStudentDetailsRepository _studentDetailsRepository;

        public StudentsController(IStudentDetailsRepository studentDetailsRepository)
        {
            _studentDetailsRepository = studentDetailsRepository;
        }

        /// <summary>
        /// Returns an array of students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<StudentDto>> Get()
        {
            var studentDetails = await _studentDetailsRepository.GetAll();

            //TODO: Mapper

            var dtos = studentDetails.Select(x => new StudentDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth
            }).ToList();

            return dtos;
        }

        /// <summary>
        /// Returns a specific student via its studentId
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("{studentId}")]
        public IEnumerable<string> Get(int studentId)
        {
            return new string[] { "value1", "value2" };
        }

    }
}

