using Application.Interface;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetPatientById : IRequest<PatientResponse<Patient>>
    {
        public int PatientId { get; set; }
    }

    public class GetPatientByIdHandler : IRequestHandler<GetPatientById, PatientResponse<Patient>>
    {
        private readonly IDynamicContext _dynamicContext;

        public GetPatientByIdHandler(IDynamicContext dynamicContext)
        {
            _dynamicContext = dynamicContext;
        }

        public async Task<PatientResponse<Patient>> Handle(GetPatientById request, CancellationToken cancellationToken)
        {
            try
            {
                var patient = await _dynamicContext.PatientsTable.FirstOrDefaultAsync(p => p.Id == request.PatientId);

                if (patient != null)
                {
                    return new PatientResponse<Patient>()
                    {
                        Status = 200,
                        Message = "Success",
                        Response = new List<Patient> { patient },
                        Error = null,
                    };
                }
                else
                {
                    return new PatientResponse<Patient>()
                    {
                        Status = 404,
                        Message = "Patient not found",
                        Response = null,
                        Error = null,
                    };
                }
            }
            catch (Exception ex)
            {
                return new PatientResponse<Patient>()
                {
                    Status = 400,
                    Message = "Error",
                    Error = ex.Message
                };
            }
        }
    }
}
