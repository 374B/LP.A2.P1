using System.Collections.Generic;
using System.Linq;

namespace LP.University.API.Dto
{
    public class DomainErrorDto
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public DomainErrorDto() { }

        public DomainErrorDto(string message)
            : this(message, new List<string>())
        {

        }

        public DomainErrorDto(IEnumerable<string> errors)
            : this("A domain validation error occurred", errors)
        {

        }

        public DomainErrorDto(string message, IEnumerable<string> errors)
        {
            Message = message;
            Errors = errors?.ToList() ?? new List<string>();
        }

    }
}
