using System;
using System.Collections.Generic;

namespace mylittle_project.Application.DTOs
{
    public class TenantDto
    {
        public Guid Id { get; set; }

        // Basic Tenant Info
        public string Name { get; set; }
        public string TenantName { get; set; }
        public string TenantNickname { get; set; }
        public string Subdomain { get; set; }
        public string IndustryType { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        // Store Settings (Add these to resolve your error)
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Timezone { get; set; }
        public bool EnableTaxCalculations { get; set; }
        public bool EnableShipping { get; set; }
        public bool EnableFilters { get; set; }

        // Timing
        public bool IsActive { get; set; }
        public DateTime LastAccessed { get; set; }

        // Related Entities
        public AdminUserDto AdminUser { get; set; }
        public SubscriptionDto Subscription { get; set; }
        public StoreDto Store { get; set; }
        public BrandingDto Branding { get; set; }
        public ContentSettingsDto ContentSettings { get; set; }
        public FeatureSettingsDto FeatureSettings { get; set; }
        public DomainSettingsDto DomainSettings { get; set; }

        // Filters
        public List<ProductFilterDto> ProductFilters { get; set; } = new();
    }
}
