using Application.DTO;
using Application.Interface;
using Application.ViewModel;
using Domain.Entities;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PatienttoAssessment.Query
{
    public class GetPatientToAssessmentDetails : IRequest<PatientToAssessmentDetailsVM>
    {
        public int PatientId { get; set; }
    }

    public class GetPatientToAssessmentDetailsHandler : IRequestHandler<GetPatientToAssessmentDetails, PatientToAssessmentDetailsVM>
    {
        private readonly IDynamicContext _dbContext;

        public GetPatientToAssessmentDetailsHandler(IDynamicContext context)
        {
            _dbContext = context;
        }

        public async Task<PatientToAssessmentDetailsVM> Handle(GetPatientToAssessmentDetails request, CancellationToken cancellationToken)
        {
            var patientResponseDetails = await _dbContext.PatientsTable
                .Where(patient => patient.Id == request.PatientId).Include(x=>x.patientToAssessments)
                .Select(patient => new PatientToAssessmentDetailsVM
                {
                    First_name = patient.FirstName,
                    Last_name = patient.LastName,
                    birth_date = patient.DOB,
                   
                    patientDetails = patient.patientToAssessments
                        .Select(assessment => new PatientDetailsVM
                        {
                            PTA_Id = assessment.Id,
                            AssessmentName = assessment.AssessmentTable.Name,
                            assessment_date = assessment.AssessmentDate,
                            // Retrieve question responses for each assessment
                            
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return patientResponseDetails;
        }
    }
}
