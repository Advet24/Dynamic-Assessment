using Application.DTO;
using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class AddPatientToAssessmentAndDetails : IRequest<int>
    {
        // Data for PatientToAssessment
        public int PatientId { get; set; }
        public int AssessmentId { get; set; }
        public DateTime AssessmentDate { get; set; }

        // Data for PatientToAssessmentDetails
        public int QuestionId { get; set; }
        public string? Response { get; set; }
    }

    public class AddPatientToAssessmentAndDetailsHandler : IRequestHandler<AddPatientToAssessmentAndDetails, int>
    {
        private readonly IDynamicContext _context;

        public AddPatientToAssessmentAndDetailsHandler(IDynamicContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddPatientToAssessmentAndDetails request, CancellationToken cancellationToken)
        {
            try
            {
                // Create a new PatientToAssessment entity
                var patientToAssessment = new PatientToAssessment
                {
                    PatientId = request.PatientId,
                    AssessmentId = request.AssessmentId,
                    AssessmentDate = request.AssessmentDate
                };

                _context.PatientToAssessmentsTable.Add(patientToAssessment);
                await _context.SaveChangesAsync();

                // Create a new PatientToAssessmentDetails entity
                var patientToAssessmentDetails = new PatientToAssessmentDetails
                {
                    PatientAssessmentId = patientToAssessment.Id, // Use the generated id
                    QuestionId = request.QuestionId,
                    Response = request.Response
                };

                _context.PatientToAssessmentDetailsTable.Add(patientToAssessmentDetails);
                await _context.SaveChangesAsync();

                return patientToAssessment.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add PatientToAssessment and details", ex);
            }
        }
    }
}
