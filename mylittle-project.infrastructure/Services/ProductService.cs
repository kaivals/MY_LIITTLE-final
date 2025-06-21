using Microsoft.EntityFrameworkCore;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using mylittle_project.Domain.Entities;
using mylittle_project.infrastructure.Data;

namespace mylittle_project.infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetProductListingsByTenantAsync(Guid tenantId)
        {
            var products = await _context.Products
                .Where(p => p.TenantId == tenantId)
                .ToListAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Category = p.Category,
                Brand = p.Brand,
                Price = p.Price,
                Stock = p.Stock,
                Status = p.Status,
                Description = p.Description,
                TenantId = p.TenantId
            });
        }

        public async Task<IEnumerable<ProductandlistingDto>> GetProductandlistingByTenantAsync(Guid tenantId)
        {
            var listings = await _context.Products
                .Where(p => p.TenantId == tenantId)
                .ToListAsync();

            return listings.Select(p => new ProductandlistingDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Category = p.Category,
                Brand = p.Brand,
                Price = p.Price,
                Stock = p.Stock,
                Status = p.Status,
                Description = p.Description,
                TenantId = p.TenantId
            });
        }
    }
}
