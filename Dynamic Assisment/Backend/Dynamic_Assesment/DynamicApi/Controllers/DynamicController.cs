using Microsoft.AspNetCore.Mvc;
using Application.CQRS.Command;
using Application.CQRS.Queries;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Domain.Entities;
using Application.DTO;
using Application.CQRS.Query;

namespace DynamicApi.Controllers
{

    public class DynamicController : ApiController
    {


        [HttpGet("GetAssessment")]
        public async Task<IActionResult> GetAssessmentNames()
        {
            var query = new GetAssessmentNamesQuery();
            var response = await Mediator.Send(query);
            return Ok(response);
        }


        [HttpPost ("AddQuestions")]
        public async Task<IActionResult> CreateAssessment(PostAssessment request)
        {
            try
            {
                var assessmentDto = await Mediator.Send(request);

                if(assessmentDto.Status == 200)
                {

                    return Ok(assessmentDto);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssessment(int id, UpdateAssessmentDto updateDto)
        {
                var command = new UpdateAssessmentCommand
                {
                    AssessmentId = id,
                    UpdatedAssessmentName = updateDto.UpdatedAssessmentName,
                    UpdatedQuestions = updateDto.UpdatedQuestions
                };

                await Mediator.Send(command);

                return Ok();
          
        }




        [HttpGet("GetAssessmentupdate/{id}")]
        public async Task<ActionResult<AssessmentNameDto>> GetAssessment(int id)
        {
           
                var query = new GetAssessmentQuery { AssessmentId = id };
                var result = await Mediator.Send(query);
                return Ok(result);

        }


        [HttpDelete("DeleteAssessment/{id}")]
        public async Task<IActionResult> DeleteAssessment(int id)
        {
            var command = new DeleteAssessment { AssessmentId = id };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}


  


