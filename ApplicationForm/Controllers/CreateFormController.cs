using ApplicationForm.DTOs;
using ApplicationForm.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApplicationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateFormController : ControllerBase
    {
        private readonly IFormService _formService;
        public CreateFormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpPost("create-form")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateProgram([FromBody] ProgramDto programForm)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _formService.AddForm(programForm);
            return Ok();
        }

        [HttpPut("Edit-Question")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditQuestion([FromBody] AdditionalQuestionsDto questions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _formService.EditQuestion(questions);
            if(question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
    }
}
