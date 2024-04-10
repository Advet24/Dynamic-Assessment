using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PatientToAssessmentDetails
    {
        public int Id { get; set; }

       
        public int PatientAssessmentId { get; set; }
        public PatientToAssessment? PatientToAssessment { get; set; }
        public int QuestionId { get; set; }
  
        public AssessmentQuestion? AssessmentQuestion { get; set; }
        public string? Response { get; set; }
        public DateTime SavedDateTime { get; set; }
    }
}
