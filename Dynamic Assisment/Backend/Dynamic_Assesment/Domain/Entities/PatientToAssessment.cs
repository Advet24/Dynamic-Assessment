using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PatientToAssessment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public int AssessmentId { get; set; }
        public AssessmentTable AssessmentTable { get; set; }
        public DateTime AssessmentDate { get; set; } 
        public List<PatientToAssessmentDetails>? PatientToAssessmentDetails { get; set; }
    }
}
