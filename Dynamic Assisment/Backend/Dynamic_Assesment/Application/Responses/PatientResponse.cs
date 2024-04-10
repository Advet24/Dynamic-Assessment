using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PatientResponse <T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public string? Error { get; set; }
        public List<T>? Response {  get; set; }
        public AssessmentNameDto? ResponseQuestion  { get; set; }

    }
}
