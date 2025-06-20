using mylittle_project.Application.DTOs;
using mylittle_project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mylittle_project.Application.Interfaces
{
    public interface ITenantService
    {
        // Core Tenant Operations
        Task<IEnumerable<Tenant>> GetAllAsync();
        Task<Tenant> CreateAsync(TenantDto dto);
        Task<Tenant?> GetTenantWithFeaturesAsync(Guid tenantId);

        // Feature Toggle Management
        Task<FeatureSettingsDto?> GetFeatureTogglesAsync(Guid tenantId);
        Task<bool> UpdateFeatureTogglesAsync(Guid tenantId, FeatureSettingsDto dto);

        // Individual or bulk feature control (replacing legacy PortalFeature style)
        Task<IEnumerable<FeatureDto>> GetFeaturesByTenantIdAsync(Guid tenantId);
        Task ToggleFeatureAccessAsync(UpdateFeatureAccessDto dto);
        Task ToggleAllFeatureAccessAsync(UpdateAllFeatureAccessDto dto);

        // Store Info
        Task<bool> UpdateStoreAsync(Guid tenantId, StoreDto dto);

        // Product Listing
        Task<IEnumerable<ProductDto>> GetProductListingsByTenantAsync(Guid tenantId);
    }
}
