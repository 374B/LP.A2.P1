using System;

namespace LP.University.Infrastructure.Data.Models
{
    public class SubjectSessionModel
    {
        public int SubjectId { get; set; }

        public DateTime SessionStart { get; set; }

        public DateTime SessionEnd { get; set; }
    }
}
