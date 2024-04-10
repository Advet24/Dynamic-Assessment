using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UpdateAssessmentDto
    {
        public AssessmentNameDto? UpdatedAssessmentName { get; set; }
        public IList<AssessmentQuestionDto>? UpdatedQuestions { get; set; }
    }
}
