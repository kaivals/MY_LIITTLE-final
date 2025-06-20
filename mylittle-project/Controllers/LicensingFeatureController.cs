using Microsoft.AspNetCore.Mvc;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using System.Threading.Tasks;

namespace mylittle_project.API.Controllers
{
    [ApiController]
    [Route("api/licensing-feature")]
    public class LicensingFeatureController : ControllerBase
    {
        private readonly IPortalService _portalService;

        public LicensingFeatureController(IPortalService portalService)
        {
            _portalService = portalService;
        }

        // Get all portals (for the left side)
        [HttpGet("portals")]
        public async Task<IActionResult> GetAllPortals()
        {
            var portals = await _portalService.GetAllPortalsAsync();
            return Ok(portals);
        }

        // Get all features for a specific portal (for the right side)
        [HttpGet("{portalId}/features")]
        public async Task<IActionResult> GetFeaturesByPortal(int portalId)
        {
            var features = await _portalService.GetFeaturesByPortalIdAsync(portalId);
            return Ok(features);
        }

        // Toggle one feature (when switching single toggle)
        [HttpPost("toggle-feature")]
        public async Task<IActionResult> ToggleFeature([FromBody] UpdateFeatureAccessDto dto)
        {
            await _portalService.ToggleFeatureAccessAsync(dto);
            return Ok(new { message = "Feature updated successfully" });
        }

        // Toggle all features (bulk toggle for parent category)
        [HttpPost("toggle-all")]
        public async Task<IActionResult> ToggleAllFeatures([FromBody] UpdateAllFeatureAccessDto dto)
        {
            await _portalService.ToggleAllFeatureAccessAsync(dto);
            return Ok(new { message = "All features updated successfully" });
        }
    }
}
