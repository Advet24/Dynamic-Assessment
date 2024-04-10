using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DOB { get; set; }
        public IList<PatientToAssessment> patientToAssessments { get; set; }
    }
}
