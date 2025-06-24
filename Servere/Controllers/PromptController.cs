using BL;
using BL.Api;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptController : ControllerBase
    {
        private readonly IBLPrompt _promptService;

        public PromptController(IBLPrompt promptService)
        {
            _promptService = promptService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Prompts>>> GetAll()
        {
            return Ok(await _promptService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prompts>> GetById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objId))
                return BadRequest("Invalid ID");

            var prompt = await _promptService.GetById(objId);
            if (prompt == null)
                return NotFound();

            return Ok(prompt);
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Prompts prompt)
        {
            await _promptService.Update(prompt);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objId))
                return BadRequest("Invalid ID");

            await _promptService.Delete(objId);
            return NoContent();
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreatePrompt([FromBody] PromptRequest promptRequest)
        {
            await _promptService.CreateResponse(promptRequest);
            return Ok(promptRequest);  
        }

    }
}
