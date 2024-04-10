using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class QuestionDetailsDto
    {
        public int Patient_assessment_id { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
        public DateTime SavedDateTime { get; set; }
    }
}
