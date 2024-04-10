using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class PatientToAssessmentDetailsVM
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime birth_date { get; set; }

        public List<PatientDetailsVM> patientDetails { get; set; }
    }
}
