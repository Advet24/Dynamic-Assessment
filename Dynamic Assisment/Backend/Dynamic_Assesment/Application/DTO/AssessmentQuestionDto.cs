using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AssessmentQuestionDto
    {
        public int Id { get; internal set; }
        public string? Questions { get; set; }
        public string? ResponseType { get; set; }
        public bool IsRequired { get; set; }
        //public int AssessmentId { get; set; }
    }
}
