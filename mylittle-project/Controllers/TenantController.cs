using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using mylittle_project.Domain.Entities;
using mylittle_project.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylittle_project.API.Controllers
{
    [ApiController]
    [Route("api/tenants")]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        // GET: api/tenants
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tenants = await _tenantService.GetAllAsync();
            return Ok(tenants);
        }

        // GET: api/tenants/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenant(Guid id)
        {
            var tenant = await _tenantService.GetTenantWithFeaturesAsync(id);
            if (tenant == null)
                return NotFound($"Tenant with ID {id} not found.");

            return Ok(tenant);
        }

        // GET: api/tenants/{id}/features
        [HttpGet("{id}/features")]
        public async Task<IActionResult> GetFeatureToggles(Guid id)
        {
            var settings = await _tenantService.GetFeatureTogglesAsync(id);
            if (settings == null)
                return NotFound($"Feature toggles not found for tenant ID {id}.");

            return Ok(settings);
        }

        // PUT: api/tenants/{id}/features
        [HttpPut("{id}/features")]
        public async Task<IActionResult> UpdateFeatureToggles(Guid id, [FromBody] FeatureSettingsDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid feature toggle payload.");

            var updated = await _tenantService.UpdateFeatureTogglesAsync(id, dto);
            if (!updated)
                return NotFound($"Tenant with ID {id} not found or update failed.");

            return Ok("Feature settings updated successfully.");
        }

        // POST: api/tenants
        [HttpPost]
        public async Task<IActionResult> CreateTenant([FromBody] TenantDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid tenant payload.");

            var createdTenant = await _tenantService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetTenant), new { id = createdTenant.Id }, createdTenant);
        }

        // PUT: api/tenants/{tenantId}/store
        [HttpPut("{tenantId}/store")]
        public async Task<IActionResult> UpdateStore(Guid tenantId, [FromBody] StoreDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid store payload.");

            var result = await _tenantService.UpdateStoreAsync(tenantId, dto);
            if (!result)
                return NotFound($"Tenant with ID {tenantId} not found.");

            return Ok("Store updated successfully.");
        }

        // GET: api/tenants/portals
        [HttpGet("portals")]
        public async Task<IActionResult> GetAllPortals()
        {
            var tenants = await _tenantService.GetAllAsync();
            var dto = tenants.Select(t => new TenantDto
            {
                Id = t.Id,
                TenantName = t.TenantName
            });

            return Ok(dto);
        }

    }
}
