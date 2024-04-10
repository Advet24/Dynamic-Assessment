using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PatienttoAssessment.Command
{
    public class AddPatientToAssessmentCommand : IRequest<int>
    {
        public int PatientId { get; set; }
        public int AssessmentId { get; set; }
    }

    public class AddPatientToAssessmentCommandHandler : IRequestHandler<AddPatientToAssessmentCommand, int>
    {
        private readonly IDynamicContext _context;

        public AddPatientToAssessmentCommandHandler(IDynamicContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddPatientToAssessmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
              
                var patientToAssessment = new PatientToAssessment
                {
                    PatientId = request.PatientId,
                    AssessmentId = request.AssessmentId,
                    AssessmentDate=DateTime.Now,
                };

              
                _context.PatientToAssessmentsTable.Add(patientToAssessment);

       
                await _context.SaveChangesAsync();

        
                return patientToAssessment.Id;
            }
            catch (Exception ex)
            {
              
                throw new Exception("Failed to add PatientToAssessment.", ex);
            }
        }
    }
}
