using ApplicationForm.DTOs;
using ApplicationForm.Models;
using ApplicationForm.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateFormController : ControllerBase
    {
        private readonly IFormService _formService;
        public CandidateFormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpPost("create-applyform")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateCandidateForm([FromBody] CandidateApplyDto applyForm)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _formService.AddCandidateForm(applyForm);
            return Ok();
        }

        [HttpGet("get-question")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetQuestionByQuestionType([FromQuery] List<QuestionsEnum> questionsEnum)
        {
            if(questionsEnum.Count == 0)
            {
                return BadRequest();
            }

            var question = await _formService.GetQuestionsByQuestionType(questionsEnum);
            return Ok(question);
        }
    }
}
