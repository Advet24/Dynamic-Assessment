using Application.DTO; 
using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Command
{
    public class UpdateAssessmentCommand : IRequest
    {
        public int AssessmentId { get; set; }
        public AssessmentNameDto? UpdatedAssessmentName { get; set; }
        public IList<AssessmentQuestionDto>? UpdatedQuestions { get; set; }
    }

    public class UpdateAssessmentCommandHandler : IRequestHandler<UpdateAssessmentCommand>
    {
        private readonly IDynamicContext _context;

        public UpdateAssessmentCommandHandler(IDynamicContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAssessmentCommand request, CancellationToken cancellationToken)
        {
            var assessment = await _context.AssessmentTables
                .Include(a => a.AssessmentQuestions)
                .FirstOrDefaultAsync(a => a.Id == request.AssessmentId);

            if (assessment == null)
            {
                throw new Exception("Assessment not found");
            }

            if (request.UpdatedAssessmentName != null)
            {
                assessment.Name = request.UpdatedAssessmentName.Name;
                assessment.IsScorable = request.UpdatedAssessmentName.IsScorable;
            }

            if (request.UpdatedQuestions != null)
            {
                foreach (var questionDto in request.UpdatedQuestions)
                {
                    var existingQuestion = assessment.AssessmentQuestions.FirstOrDefault(q => q.Id == questionDto.Id);
                    if (existingQuestion != null)
                    {
                        // Update existing question
                        existingQuestion.Questions = questionDto.Questions;
                        existingQuestion.ResponseType = questionDto.ResponseType;
                        existingQuestion.IsRequired = questionDto.IsRequired;
                    }
                    else
                    {
                        // Create new question
                        assessment.AssessmentQuestions.Add(new AssessmentQuestion
                        {
                            Questions = questionDto.Questions,
                            ResponseType = questionDto.ResponseType,
                            IsRequired = questionDto.IsRequired,
                            AssessmentId = request.AssessmentId
                        });
                    }
                }
            }

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }

}
