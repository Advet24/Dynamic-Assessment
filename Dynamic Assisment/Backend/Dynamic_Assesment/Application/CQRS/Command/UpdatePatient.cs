using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class UpdatePatient  : IRequest<Patient>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DOB { get; set; }
    }

    public class UpdatePatientHandler : IRequestHandler<UpdatePatient, Patient>
    {
        private readonly IDynamicContext _dynamicContext;

        public UpdatePatientHandler(IDynamicContext dynamicContext)
        {
            _dynamicContext = dynamicContext;
        }

        public async Task<Patient> Handle(UpdatePatient request, CancellationToken cancellationToken)
        {
          var existingPatient = await _dynamicContext.PatientsTable.FirstOrDefaultAsync(p=>p.Id == request.Id);

            if(existingPatient == null)
            {
                throw new Exception("Patient not found");
            }

            existingPatient.FirstName = request.FirstName ?? existingPatient.FirstName;
            existingPatient.LastName = request.LastName ?? existingPatient.LastName;
            existingPatient.DOB = request.DOB;

            await _dynamicContext.SaveChangesAsync();
            return existingPatient;
        }
    }
}
