using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AssessmentNameDto
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public int IsScorable { get; set; }
        public IList<AssessmentQuestionDto>? Questions { get; set; }
    }
}
