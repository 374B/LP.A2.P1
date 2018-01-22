using LP.University.API.Dto;
using LP.University.API.Interfaces;
using LP.University.Domain.Student;

namespace LP.University.API.Mappers
{
    public class StudentDetailsMapper : IMapper<StudentDetailsItem, StudentDetailsDto>
    {
        public StudentDetailsDto Map(StudentDetailsItem obj)
        {
            return new StudentDetailsDto
            {
                StudentId = obj.StudentId,
                FirstName = obj.FirstName,
                DateOfBirth = obj.DateOfBirth,
                LastName = obj.LastName
            };
        }
    }
}
