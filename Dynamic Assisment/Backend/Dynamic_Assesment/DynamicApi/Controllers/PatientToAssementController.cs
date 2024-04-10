using Application.PatienttoAssessment.Command;
using Application.PatienttoAssessment.Query;
using Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientToAssementController : ApiController
    {
        [HttpPost("PatientToAssessment")]
        public async Task<IActionResult> CreatePatientToAssessment([FromBody] AddPatientToAssessmentCommand command)
        {
                var id = await Mediator.Send(command);
                return Ok(new { Id = id });
        }


        [HttpPost("PatientToAssessmentDetails")]
        public async Task<IActionResult> CreatePatientToAssessmentDetails(CreatePatientToAssessmentDetailsCommand command)
        {
                var result = await Mediator.Send(command);
                return Ok(result);
        }


        [HttpGet("Getdetails{patientId}")]
        public async Task<ActionResult<PatientToAssessmentDetailsVM>> GetPatientToAssessmentDetails(int patientId)
        {
            var query = new GetPatientToAssessmentDetails { PatientId = patientId };
            var result = await Mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost("PostResponse")]
        public async Task<IActionResult> PostAssessmentToResponse(PostAssessmentToResponse command)
        {
            var response = await Mediator.Send(command);

            if (response.Status == 200)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(response.Status, response);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientResponse(int id)
        {
            var query = new GetPatientResponse { Id = id };
            var patientResponses = await Mediator.Send(query);

            if (patientResponses == null)
            {
                return NotFound();
            }

            return Ok(patientResponses);
        }
    }
}
            
              

                
           

