using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs;

public class FullTenantDto
{
    public string TenantName { get; set; }
    public string TenantNickname { get; set; }
    public string Subdomain { get; set; }
    public string IndustryType { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }

    public AdminUserDto AdminUser { get; set; }
    public SubscriptionDto Subscription { get; set; }
    public StoreDto Store { get; set; }
    public BrandingDto Branding { get; set; }
    public ContentSettingsDto ContentSettings { get; set; }
    public FeatureSettingsDto FeatureSettings { get; set; }
    public DomainSettingsDto DomainSettings { get; set; }

    public List<ProductFilterDto> ProductFilters { get; set; }   // ✅ Keep only this

    public string Country { get; set; }
    public string Currency { get; set; }
    public string Language { get; set; }
    public string Timezone { get; set; }
    public bool EnableTaxCalculations { get; set; }
    public bool EnableShipping { get; set; }
    public bool EnableFilters { get; set; }
}



