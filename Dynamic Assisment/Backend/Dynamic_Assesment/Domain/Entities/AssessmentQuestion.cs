using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AssessmentQuestion
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string? Questions { get; set; }
        public string? ResponseType { get; set; }
        public bool IsRequired { get; set; }
        public int AssessmentId { get; set; }
        public AssessmentTable AssessmentTable { get; set; }
    }
}
