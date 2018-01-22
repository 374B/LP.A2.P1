using LP.University.API.Dto;
using LP.University.API.Interfaces;
using LP.University.Domain.Subject;

namespace LP.University.API.Mappers
{
    public class SubjectItemMapper :
        IMapper<SubjectEnrollment, SubjectItemDto>,
        IMapper<Subject, SubjectItemDto>,
        IMapper<SubjectDetailsItem, SubjectItemDto>
    {
        public SubjectItemDto Map(SubjectEnrollment obj)
        {
            if (obj == null) throw new System.ArgumentNullException(nameof(obj));

            return Map(obj.Subject);
        }

        public SubjectItemDto Map(Subject obj)
        {
            if (obj == null) throw new System.ArgumentNullException(nameof(obj));

            return Map(obj.SubjectDetails);
        }

        public SubjectItemDto Map(SubjectDetailsItem obj)
        {
            if (obj == null) throw new System.ArgumentNullException(nameof(obj));

            return new SubjectItemDto
            {
                SubjectId = obj.SubjectId,
                Code = obj.Code,
                Name = obj.Name,
            };
        }
    }
}
