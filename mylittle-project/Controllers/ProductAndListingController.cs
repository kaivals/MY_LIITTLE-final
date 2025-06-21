using Microsoft.AspNetCore.Mvc;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;

namespace mylittle_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductAndListingController : ControllerBase
    {
        private readonly IProductService _productService; // 👈 Use IProductService

        public ProductAndListingController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("ByTenant/{tenantId}")]
        public async Task<IActionResult> GetProductsByTenant(Guid tenantId)
        {
            var products = await _productService.GetProductListingsByTenantAsync(tenantId);
            return Ok(products);
        }
    }
}
