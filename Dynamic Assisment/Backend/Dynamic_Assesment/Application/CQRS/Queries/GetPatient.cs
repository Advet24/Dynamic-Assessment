using Application.Interface;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetPatient : IRequest<PatientResponse<Patient>> 
    {
    }

    public class GetPatientHandler : IRequestHandler<GetPatient, PatientResponse<Patient>> 
    {
        private readonly IDynamicContext _dynamicContext;
        public GetPatientHandler(IDynamicContext dynamicContext)
        {
            _dynamicContext = dynamicContext;
        }

        public async Task<PatientResponse<Patient>> Handle(GetPatient request, CancellationToken cancellationToken)
        {
            try
            {
                var patients = await _dynamicContext.PatientsTable.ToListAsync();

                return new PatientResponse<Patient>() 
                {
                    Status = 200,
                    Message = "Success",
                    Response = patients,
                    Error = null,
                };
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
