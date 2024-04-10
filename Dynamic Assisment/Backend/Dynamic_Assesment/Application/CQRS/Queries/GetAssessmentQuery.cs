using Application.DTO;
using Application.Interface;
using Application.ViewModel;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Query
{
    public class GetAssessmentQuery : IRequest<AssessmentNameDtoVM>
    {
        public int AssessmentId { get; set; }
    }

    public class GetAssessmentQueryHandler : IRequestHandler<GetAssessmentQuery, AssessmentNameDtoVM>
    {
        private readonly IDynamicContext _context;

        public GetAssessmentQueryHandler(IDynamicContext context)
        {
            _context = context;
        }

        public async Task<AssessmentNameDtoVM> Handle(GetAssessmentQuery request, CancellationToken cancellationToken)
        {
            var assessment = await _context.AssessmentTables
                .Include(a => a.AssessmentQuestions)
                .FirstOrDefaultAsync(a => a.Id == request.AssessmentId);

            if (assessment == null)
            {
                throw new Exception("Assessment not found");
            }

            // Map assessment entity to DTO
            var assessmentDto = new AssessmentNameDtoVM
            {
                id = assessment.Id,
                Name = assessment.Name,
                IsScorable = assessment.IsScorable,
                Questions = assessment.AssessmentQuestions
                    .Select(q => new AssessmentQuestionVM
                    {
                        Id = q.Id,
                        Questions = q.Questions,
                        ResponseType = q.ResponseType,
                        IsRequired = q.IsRequired
                    })
                    .ToList()
            };

            return assessmentDto;
        }
    }
}
