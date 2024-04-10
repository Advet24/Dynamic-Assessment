using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class QuestionResponseDto
    {
        //public int PatientAssessmentId { get; set; }
        public int QuestionId { get; set; }
        public string? Response {  get; set; }
    }
}
