using Application.DTO;
using Application.Interface;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PatienttoAssessment.Query
{
    public class GetPatientResponse : IRequest<List<QuestionDetailsDto>>
    {
        public int Id { get; set; }
    }

    public class GetPatientResponseHandler : IRequestHandler<GetPatientResponse, List<QuestionDetailsDto>>
    {
        private readonly IDynamicContext _dynamicContext;

        public GetPatientResponseHandler(IDynamicContext dynamicContext)
        {
            _dynamicContext = dynamicContext;
        }

        public async Task<List<QuestionDetailsDto>> Handle(GetPatientResponse request, CancellationToken cancellationToken)
        {
            var patientResponses = _dynamicContext.PatientToAssessmentDetailsTable
                .Where(x => x.PatientAssessmentId == request.Id)
                .Select(x => new QuestionDetailsDto
                {
                    
                    Question = x.AssessmentQuestion.Questions,
                    Response = x.Response,
                    //SavedDateTime=x.SavedDateTime
                    
                })
                .ToList();

            return patientResponses;
        }
    }
}
