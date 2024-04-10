using Application.DTO;
using Application.Interface;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetAssessmentNamesQuery : IRequest<GetNameResponses<List<AssessmentNameDto>>>
    {
    }

    public class GetAssessmentNamesQueryHandler : IRequestHandler<GetAssessmentNamesQuery, GetNameResponses<List<AssessmentNameDto>>>
    {
        private readonly IDynamicContext _dynamicContext;

        public GetAssessmentNamesQueryHandler(IDynamicContext dynamicContext)
        {
            _dynamicContext = dynamicContext;
        }

        public async Task<GetNameResponses<List<AssessmentNameDto>>> Handle(GetAssessmentNamesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var assessmentTables = await _dynamicContext.AssessmentTables.ToListAsync();
                var assessmentNameDtos = assessmentTables.Select(table => new AssessmentNameDto
                {
                    id = table.Id,
                    Name = table.Name,
                    IsScorable = table.IsScorable
                }).ToList();


                return new GetNameResponses<List<AssessmentNameDto>>
                {
                    Status = 200,
                    Message = "Success",
                    Response = assessmentNameDtos,
                    Error = null
                };
            }

            catch (Exception ex)
            {
                return new GetNameResponses<List<AssessmentNameDto>>
                {
                    Status = 400,
                    Message = "Error",
                    Response = null,
                    Error = ex.Message
                };
            }


        }
    }
}
