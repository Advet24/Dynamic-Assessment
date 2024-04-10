using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public  class PostPateient : IRequest<Patient>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DOB { get; set; }
    }

    public class PostPatientHandler : IRequestHandler<PostPateient, Patient>
    {
        private IDynamicContext _dynamicContext;
        public PostPatientHandler(IDynamicContext dynamicContext)
        {
            _dynamicContext = dynamicContext;
        }

        public async Task<Patient> Handle(PostPateient request, CancellationToken cancellationToken)
        {
            var newPatient = new Patient
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DOB = request.DOB,
            };

            _dynamicContext.PatientsTable.Add(newPatient);
            await _dynamicContext.SaveChangesAsync();
            return newPatient;
        }
    }
}
