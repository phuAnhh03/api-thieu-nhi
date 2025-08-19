using api.Dtos.Ownerships;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/ownership")]
    [ApiController]
    public class OwnershipController(IOwnershipService ownershipService) : ControllerBase
    {
        private readonly IOwnershipService _ownershipService = ownershipService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OwnershipDto ownershipDto)
        {
            var ownership = await _ownershipService.AddOwnershipAsync(ownershipDto);
            return Ok(ownership);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OwnershipDto ownershipDto)
        {
            var ownership = await _ownershipService.EditOwnershipAsync(ownershipDto);
            if (ownership == null) return NotFound("Ownership not found");
            return Ok(ownership);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] OwnershipDto ownershipDto)
        {
            var ownership = await _ownershipService.RemoveOwnershipAsync(ownershipDto);
            if (ownership == null) return NotFound("Ownership not found");
            return NoContent();
        }
    }
}