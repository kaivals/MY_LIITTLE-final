using Microsoft.AspNetCore.Mvc;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;

namespace mylittle_project.Controllers
{

    [ApiController]
    [Route("api/BusinessDealer")]
    public class BusinessController : ControllerBase // Fix: Inherit from ControllerBase
    {
        private readonly IBusinessService _businessService;

        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessInfo([FromBody] BusinessInfoDto dto)
        {
            if (!ModelState.IsValid) // Fix: ModelState is available in ControllerBase
                return BadRequest(ModelState); // Fix: BadRequest is available in ControllerBase

            var id = await _businessService.CreateBusinessInfoAsync(dto);
            return Ok(new { Message = "Business Info created successfully", BusinessId = id });
        }
    }
}
