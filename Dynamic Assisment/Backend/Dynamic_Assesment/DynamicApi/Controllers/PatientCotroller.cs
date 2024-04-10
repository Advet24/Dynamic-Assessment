using Application.CQRS.Command;
using Application.CQRS.Queries;
using Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCotroller : ApiController
    {
        [HttpGet("Getall")]
        public async Task<IActionResult> GetPatients()
        {

            var response = await Mediator.Send(new GetPatient());
            return Ok(response);
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var query = new GetPatientById { PatientId = id };
            var response = await Mediator.Send(query);

            return response.Status == 200 ? Ok(response.Response) : NotFound(response.Message);
        }



        [HttpPost("AddPatient")]
        public async Task<IActionResult> CreatePatient(PostPateient request)
        {
            try
            {
                var patient = await Mediator.Send(request);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error", Error = ex.Message });
            }
        }

        [HttpPut("UpdatePatient/{id}")]
        public async Task<IActionResult> UpdatePatient(UpdatePatient request)
        {
            try
            {
                var patient = await Mediator.Send(request);

                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error", Error = ex.Message });
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAssessmentNames()
        {
            var query = new GetAllAssessmentNames();
            var assessments = await Mediator.Send(query);

            if (assessments == null)
            {
                return NotFound();
            }

            return Ok(assessments);
        }
    }
}



           
            
           
