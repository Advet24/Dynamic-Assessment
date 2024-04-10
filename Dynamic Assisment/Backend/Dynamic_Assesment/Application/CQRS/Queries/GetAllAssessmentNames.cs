
using Application.DTO;
using Application.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetAllAssessmentNames : IRequest<List<AssessmentDTO>>
    {
    }

    public class GetAllAssessmentNamesHandler : IRequestHandler<GetAllAssessmentNames, List<AssessmentDTO>>
    {
        private readonly IDynamicContext _context;

        public GetAllAssessmentNamesHandler(IDynamicContext context)
        {
            _context = context;
        }

        public async Task<List<AssessmentDTO>> Handle(GetAllAssessmentNames request, CancellationToken cancellationToken)
        {
            try
            {
                // Query the database to get all assessment IDs and names
                var assessments = await _context.AssessmentTables
                    .Select(a => new AssessmentDTO { Id = a.Id, Name = a.Name })
                    .ToListAsync();

                return assessments;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all assessment names", ex);
            }
        }
    }
}
