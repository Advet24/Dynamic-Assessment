using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PatienttoAssessment.Command
{
    public class CreatePatientToAssessmentDetailsCommand : IRequest<int>
    {
        public int PatientAssessmentId { get; set; }
        public int QuestionId { get; set; }
        public string Response { get; set; }
    }

    public class CreatePatientToAssessmentDetailsCommandHandler : IRequestHandler<CreatePatientToAssessmentDetailsCommand, int>
    {
        private readonly IDynamicContext _dynamicContext;

        public CreatePatientToAssessmentDetailsCommandHandler(IDynamicContext dynamicContext)
        {
            _dynamicContext = dynamicContext;
        }

        public async Task<int> Handle(CreatePatientToAssessmentDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var newPatientToAssessmentDetails = new PatientToAssessmentDetails
                {
                    PatientAssessmentId = request.PatientAssessmentId,
                    QuestionId = request.QuestionId,
                    Response = request.Response
                };

             
                _dynamicContext.PatientToAssessmentDetailsTable.Add(newPatientToAssessmentDetails);
                await _dynamicContext.SaveChangesAsync();

                return newPatientToAssessmentDetails.Id;
            }
            catch (Exception ex)
            {
            
                throw new Exception("Failed to create PatientToAssessmentDetails.", ex);
            }
        }
    }
}
