using Microsoft.AspNetCore.Mvc;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;

namespace mylittle_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductAndListingController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductAndListingController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("ByPortal/{portal}")]
        public async Task<IActionResult> GetProductsByPortal(string portal)
        {
            var products = await _productService.GetProductListingsByPortalAsync(portal);
            return Ok(products);
        }

        [HttpGet("ByTenant/{tenantId}")]
        public async Task<IActionResult> GetProductsByTenant(Guid tenantId)
        {
            var products = await _productService.GetProductListingsByTenantAsync(tenantId);
            return Ok(products);
        }
    }
}
