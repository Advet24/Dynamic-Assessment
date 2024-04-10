using Application.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.CQRS.Command
{
    public class DeleteAssessment : IRequest
    {
        public int AssessmentId { get; set; }
    }

    public class DeleteAssessmentHandler : IRequestHandler<DeleteAssessment>
    {
        private readonly IDynamicContext _dynamicContext;

        public DeleteAssessmentHandler(IDynamicContext dynamicContext)
        {
            _dynamicContext = dynamicContext;
        }

        public async Task<Unit> Handle(DeleteAssessment request, CancellationToken cancellationToken)
        {
            try
            {

                var assessment = await _dynamicContext.AssessmentTables
                    .Include(a => a.AssessmentQuestions)
                    .FirstOrDefaultAsync(a => a.Id == request.AssessmentId);

                if (assessment == null)
                {
                    throw new KeyNotFoundException($"Assessment with ID {request.AssessmentId} not found");
                }


                _dynamicContext.AssessmentQuestions.RemoveRange(assessment.AssessmentQuestions);


                _dynamicContext.AssessmentTables.Remove(assessment);


                await _dynamicContext.SaveChangesAsync();

                return Unit.Value;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                throw new Exception("Error deleting assessment", ex);
            }
        }
    }
}
