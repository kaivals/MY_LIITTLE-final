using Microsoft.AspNetCore.Mvc;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using System.Linq;
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

        [HttpGet("{portalId}")]
        public async Task<IActionResult> GetFeaturesByPortal(int portalId)
        {
            var features = await _portalService.GetFeaturesByPortalIdAsync(portalId);

            var dto = features.Select(f => new FeatureDto
            {
                Id = f.Id,
                Name = f.Name,
                Category = f.Category,
                IsPremium = f.IsPremium,
                IsEnabled = f.IsEnabled
            });

            return Ok(dto);
        }

        [HttpPost("toggle-feature")]
        public async Task<IActionResult> ToggleFeature([FromBody] UpdateFeatureAccessDto dto)
        {
            await _portalService.ToggleFeatureAccessAsync(dto);
            return NoContent();
        }

        [HttpPost("toggle-all")]
        public async Task<IActionResult> ToggleAllFeatures([FromBody] UpdateAllFeatureAccessDto dto)
        {
            await _portalService.ToggleAllFeatureAccessAsync(dto);
            return NoContent();
        }
    }
}
