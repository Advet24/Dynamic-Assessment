using Application.DTO;
using Application.Interface;
using Domain;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class PostAssessment : IRequest<PatientResponse<string>>
    {
        public AssessmentNameDto AssessmentDto { get; set; }
    }

    public class PostAssessmentHandler : IRequestHandler<PostAssessment, PatientResponse<string>>
    {
        private readonly IDynamicContext _dynamicContext;

        public PostAssessmentHandler(IDynamicContext dynamicContext)
        {
            _dynamicContext = dynamicContext ?? throw new ArgumentNullException(nameof(dynamicContext));
        }

        public async Task<PatientResponse<string>> Handle(PostAssessment request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.AssessmentDto == null)
                {
                    throw new ArgumentNullException(nameof(request.AssessmentDto), "AssessmentDto is required");
                }

                var assessmentTable = new AssessmentTable
                {
                    Name = request.AssessmentDto.Name,
                    IsScorable = request.AssessmentDto.IsScorable
                };

                _dynamicContext.AssessmentTables.Add(assessmentTable);

                await _dynamicContext.SaveChangesAsync();

                // Add questions to the assessment table
                if (request.AssessmentDto.Questions != null)
                {
                    foreach (var questiondto in request.AssessmentDto.Questions)
                    {
                        if (questiondto == null)
                        {
                            continue;
                        }

                        var assessmentQuestion = new AssessmentQuestion
                        {
                            Questions = questiondto.Questions,
                            ResponseType = questiondto.ResponseType,
                            IsRequired = questiondto.IsRequired,
                            AssessmentId = assessmentTable.Id
                        };

                        _dynamicContext.AssessmentQuestions.Add(assessmentQuestion);
                    }
                }

                await _dynamicContext.SaveChangesAsync();

                return new PatientResponse<string>
                {
                    Status = 200,
                    Message = "Success",
                    Error = null,
                    Response = null,
                    ResponseQuestion = request.AssessmentDto
                };
            }
            catch (ArgumentNullException ex)
            {
                return new PatientResponse<string>
                {
                    Status = 400,
                    Message = "Unsuccessful",
                    Error = ex.Message,
                    Response = null,
                    ResponseQuestion = null
                };
            }
            catch (Exception ex)
            {
                return new PatientResponse<string>
                {
                    Status = 500,
                    Message = "Internal Server Error",
                    Error = ex.Message,
                    Response = null,
                    ResponseQuestion = null
                };
            }
        }
    }
}



























//using Application.DTO;
//using Application.Interface;
//using Domain;
//using Domain.Entities;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.CQRS.Command
//{
//    public class PostAssessment : IRequest<PatientResponse<string>>
//    {
//        public AssessmentNameDto AssessmentDto { get; set; }
//        public List<AssessmentQuestionDto>? QuestionsDto { get; set; }
//    }

//    public class PostAssessmentHandler : IRequestHandler<PostAssessment, PatientResponse<string>>
//    {
//        private readonly IDynamicContext _dynamicContext;

//        public PostAssessmentHandler(IDynamicContext dynamicContext)
//        {
//            _dynamicContext = dynamicContext;
//        }

//        public async Task<PatientResponse<string>> Handle(PostAssessment request, CancellationToken cancellationToken)
//        {
//            try
//            {
//                if (request.AssessmentDto == null)
//                    throw new ArgumentNullException(nameof(request.AssessmentDto), "AssessmentDto is required");

//                var assessmentTable = new AssessmentTable
//                {
//                    Name = request.AssessmentDto.Name,
//                    Isactive = true, // Assuming it should be active by default
//                    IsScorable = request.AssessmentDto.IsScorable
//                };

//                _dynamicContext.AssessmentTables.Add(assessmentTable);

//                await _dynamicContext.SaveChangesAsync();

//                if (request.QuestionsDto != null)
//                {
//                    foreach (var questionDto in request.QuestionsDto)
//                    {
//                        var assessmentQuestion = new AssessmentQuestion
//                        {
//                            Questions = questionDto.Questions,
//                            ResponseType = questionDto.ResponseType,
//                            IsRequired = questionDto.IsRequired,
//                            AssessmentId = assessmentTable.Id,
//                            IsActive = true // Assuming it should be active by default
//                        };

//                        _dynamicContext.AssessmentQuestions.Add(assessmentQuestion);
//                    }

//                    await _dynamicContext.SaveChangesAsync();
//                }

//                return new PatientResponse<string>
//                {
//                    Status = 200,
//                    Message = "Success",
//                    Error = null,
//                    Response = null,
//                    ResponseQuestion = request.AssessmentDto
//                };
//            }
//            catch (Exception ex)
//            {
//                return new PatientResponse<string>
//                {
//                    Status = 400,
//                    Message = "Unsuccessful",
//                    Error = ex.Message,
//                    Response = null,
//                    ResponseQuestion = null
//                };
//            }
//        }
//    }
//}
































