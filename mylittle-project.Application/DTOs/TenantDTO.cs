using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs;

public class FullTenantDto
{
    public string TenantName { get; set; } = string.Empty;
    public string TenantNickname { get; set; } = string.Empty;
    public string Subdomain { get; set; } = string.Empty;
    public string IndustryType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public AdminUserDto? AdminUser { get; set; } 
    public SubscriptionDto? Subscription { get; set; }
    public StoreDto? Store { get; set; }
    public BrandingDto? Branding { get; set; }
    public ContentSettingsDto? ContentSettings { get; set; }
    public FeatureSettingsDto? FeatureSettings { get; set; }
    public DomainSettingsDto? DomainSettings { get; set; }

    public List<ProductFilterDto>? ProductFilters { get; set; }   // ✅ Keep only this

    public string Country { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Timezone { get; set; } = string.Empty;
    public bool EnableTaxCalculations { get; set; }
    public bool EnableShipping { get; set; }
    public bool EnableFilters { get; set; }
}



