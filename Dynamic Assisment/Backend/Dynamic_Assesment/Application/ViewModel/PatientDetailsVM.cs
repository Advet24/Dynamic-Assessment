using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class PatientDetailsVM
    {
        public int PTA_Id { get; set; }
        public string AssessmentName { get; set; }

        public DateTime assessment_date { get; set; }
        //public List<QuestionDetailsDto> questionDetails { get; set; }
    }
}
