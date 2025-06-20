using Microsoft.AspNetCore.Mvc;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using System.Threading.Tasks;

namespace mylittle_project.API.Controllers
{
    [ApiController]
    [Route("api/tenant-feature")]
    public class TenantFeatureController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantFeatureController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        // Get all tenants (was "portals" on the left side)
        [HttpGet("tenants")]
        public async Task<IActionResult> GetAllTenants()
        {
            var tenants = await _tenantService.GetAllAsync();
            var dto = tenants.Select(t => new TenantDto
            {
                Id = t.Id,
                TenantName = t.TenantName,
                Subdomain = t.Subdomain,
                IndustryType = t.IndustryType,
                IsActive = t.IsActive,
                LastAccessed = t.LastAccessed
            });

            return Ok(dto);
        }

        // Get all features for a specific tenant
        [HttpGet("{tenantId}/features")]
        public async Task<IActionResult> GetFeaturesByTenant(Guid tenantId)
        {
            var features = await _tenantService.GetFeatureTogglesAsync(tenantId);
            if (features == null)
                return NotFound($"No features found for tenant ID {tenantId}");

            return Ok(features);
        }

        // Toggle a single feature
        [HttpPost("toggle-feature")]
        public async Task<IActionResult> ToggleFeature([FromBody] UpdateFeatureAccessDto dto)
        {
            // Optional: You can validate here if necessary
            await _tenantService.ToggleFeatureAccessAsync(dto);
            return Ok(new { message = "Feature updated successfully" });
        }

        // Toggle all features for a tenant
        [HttpPost("toggle-all")]
        public async Task<IActionResult> ToggleAllFeatures([FromBody] UpdateAllFeatureAccessDto dto)
        {
            await _tenantService.ToggleAllFeatureAccessAsync(dto);
            return Ok(new { message = "All features updated successfully" });
        }
    }
}
