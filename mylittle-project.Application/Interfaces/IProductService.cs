using mylittle_project.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mylittle_project.Application.Interfaces
{
    public interface IProductService
    {
        // For listing from the main Product table (e.g., recently added or for internal product management)
        Task<IEnumerable<ProductDto>> GetProductListingsByTenantAsync(Guid tenantId);

        // For listing full view from Productandlisting (e.g., tenant storefront or user-facing listing)
        Task<IEnumerable<ProductandlistingDto>> GetProductandlistingByTenantAsync(Guid tenantId);
    }
}
