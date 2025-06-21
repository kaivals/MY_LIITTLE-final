using mylittle_project.Application.DTOs;
using mylittle_project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mylittle_project.Application.Interfaces
{
    public interface ITenantService
    {
        // Tenant Management
        Task<IEnumerable<Tenant>> GetAllAsync();
        Task<Tenant> CreateAsync(TenantDto dto);
        Task<Tenant?> GetTenantWithFeaturesAsync(Guid tenantId);

        // Feature Settings Management (Single table logic)
        Task<FeatureSettingsDto?> GetFeatureTogglesAsync(Guid tenantId);
        Task<bool> UpdateFeatureTogglesAsync(Guid tenantId, FeatureSettingsDto dto);

        // Store Management
        Task<bool> UpdateStoreAsync(Guid tenantId, StoreDto dto);

        

    }
}
