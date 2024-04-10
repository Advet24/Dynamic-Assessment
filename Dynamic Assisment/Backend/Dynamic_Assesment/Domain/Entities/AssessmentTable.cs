using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AssessmentTable
    {
        public int Id { get; set; }
        public bool Isactive { get; set; }
        public string? Name { get; set; }    
        public int IsScorable { get; set; }
        public IList<AssessmentQuestion>? AssessmentQuestions { get; set; }

        public IList<PatientToAssessment> PatientToAssessments { get; set; }
    }
}
