using Microsoft.AspNetCore.Mvc;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;

namespace mylittle_project.API.Controllers
{
    [ApiController]
    [Route("api/portal")]
    public class PortalController : ControllerBase
    {
        private readonly IPortalService _portalService;

        public PortalController(IPortalService portalService)
        {
            _portalService = portalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPortals()
        {
            var portals = await _portalService.GetAllPortalsAsync();
            var dto = portals.Select(p => new PortalDto
            {
                Id = p.Id,
                Name = p.Name,
                IsActive = p.IsActive,
                LastAccessed = p.LastAccessed
            });

            return Ok(dto);
        }
    }
}
