using LP.University.API.Dto;
using LP.University.API.Interfaces;
using LP.University.Domain.Student;

namespace LP.University.API.Mappers
{
    public class StudentItemMapper : IMapper<StudentDetailsItem, StudentItemDto>
    {
        public StudentItemDto Map(StudentDetailsItem obj)
        {
            return new StudentItemDto
            {
                StudentId = obj.StudentId,
                FirstName = obj.FirstName,
                LastName = obj.LastName
            };
        }
    }
}
