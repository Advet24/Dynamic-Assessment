using Application.ViewModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IDynamicContext
    {
        DbSet<AssessmentTable> AssessmentTables { get; }
        DbSet<AssessmentQuestion> AssessmentQuestions { get; }

        DbSet<Patient> PatientsTable { get; }

        DbSet<QuestionResponse> QuestionResponses { get; }
        DbSet<PatientToAssessment> PatientToAssessmentsTable { get; }

        DbSet<PatientToAssessmentDetails> PatientToAssessmentDetailsTable {  get; }
        Task SaveChangesAsync();
    }
}
