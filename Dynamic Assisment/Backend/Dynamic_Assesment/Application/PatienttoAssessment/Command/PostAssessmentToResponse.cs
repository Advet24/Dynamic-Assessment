using Application.DTO;
using Application.Interface;
using Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PatienttoAssessment.Command
{
    public class PostAssessmentToResponse : IRequest<QuesResponse<Patient>>
    {
        public int PatientId { get; set; }
        public int AssessmentId { get; set; }
        public List<QuestionResponseDto>? QuestionResponses { get; set; }
    }

    public class PostAssessmentToResponseHandler : IRequestHandler<PostAssessmentToResponse, QuesResponse<Patient>>
    {
        private readonly IDynamicContext _context;

        public PostAssessmentToResponseHandler(IDynamicContext context)
        {
            _context = context;
        }

        public async Task<QuesResponse<Patient>> Handle(PostAssessmentToResponse request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new PatientToAssessment()
                {
                    PatientId = request.PatientId,
                    AssessmentId = request.AssessmentId,
                    AssessmentDate=DateTime.Now,
                };

                _context.PatientToAssessmentsTable.Add(entity);
                await _context.SaveChangesAsync();

                foreach (var questionResponse in request.QuestionResponses)
                {
                    var details = new PatientToAssessmentDetails()
                    {
                      PatientAssessmentId  = entity.Id,
                        QuestionId = questionResponse.QuestionId,
                        Response = questionResponse.Response,
                    };

                    _context.PatientToAssessmentDetailsTable.Add(details);
                }

                await _context.SaveChangesAsync();

                return new QuesResponse<Patient>()
                {
                    Status = 200,
                    Message = "Questions and responses added successfully"
                };
            }
            catch (Exception ex)
            {
                return new QuesResponse<Patient>()
                {
                    Status = 500,
                    Error = "An error occurred while adding questions and responses"
                };
            }
        }
    }
}
