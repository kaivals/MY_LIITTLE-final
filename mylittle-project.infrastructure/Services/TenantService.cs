using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using mylittle_project.Domain.Entities;
using mylittle_project.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace mylittle_project.infrastructure.Services
{
    public class TenantService : ITenantService
    {
        private readonly AppDbContext _context;

        public TenantService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            return await _context.Tenants
                .Include(t => t.AdminUser)
                .Include(t => t.Subscription)
                .Include(t => t.Store)
                .Include(t => t.Branding)
                .Include(t => t.ContentSettings)
                .Include(t => t.FeatureSettings)
                .Include(t => t.DomainSettings)
                .ToListAsync();
        }

        public async Task<Tenant> CreateAsync(FullTenantDto dto)
        {
            var tenantId = Guid.NewGuid();

            var tenant = new Tenant
            {
                Id = tenantId,
                TenantName = dto.TenantName,
                TenantNickname = dto.TenantNickname,
                Subdomain = dto.Subdomain,
                IndustryType = dto.IndustryType,
                Status = dto.Status,
                Description = dto.Description,

                AdminUser = new AdminUser
                {
                    FullName = dto.AdminUser.FullName,
                    Email = dto.AdminUser.Email,
                    Password = dto.AdminUser.Password,
                    Role = dto.AdminUser.Role,
                    PhoneNumber = dto.AdminUser.PhoneNumber,
                    CountryCode = dto.AdminUser.CountryCode,
                    DateOfBirth = dto.AdminUser.DateOfBirth,
                    Gender = dto.AdminUser.Gender,
                    StreetAddress = dto.AdminUser.StreetAddress,
                    City = dto.AdminUser.City,
                    StateProvince = dto.AdminUser.StateProvince?.ToString(),
                    ZipPostalCode = dto.AdminUser.ZipPostalCode?.ToString(),
                    Country = dto.AdminUser.Country
                },

                Subscription = new Subscription
                {
                    PlanName = dto.Subscription.PlanName?.ToString(),
                    StartDate = dto.Subscription.StartDate,
                    EndDate = dto.Subscription.EndDate,
                    IsTrial = dto.Subscription.IsTrial,
                    IsActive = dto.Subscription.IsActive,
                    TenantId = tenantId
                },

                Store = new Store
                {
                    Country = dto.Country,
                    Currency = dto.Currency,
                    Language = dto.Language,
                    Timezone = dto.Timezone,
                    EnableTaxCalculations = dto.EnableTaxCalculations,
                    EnableShipping = dto.EnableShipping,
                    EnableFilters = dto.EnableFilters,
                    TenantId = tenantId,
                    ProductFilters = dto.EnableFilters && dto.ProductFilters != null
                        ? dto.ProductFilters.Select(f => new Filter
                        {
                            Name = f.Name,
                            Description = f.Description,
                            IsActive = f.IsActive,
                            Type = f.Type,
                            Category = f.Category,
                            RangeStart = f.RangeStart,
                            RangeEnd = f.RangeEnd,
                            Step = f.Step,
                            Options = f.Options != null ? string.Join(",", f.Options) : null
                        }).ToList()
                        : new List<Filter>()
                },

                Branding = new Branding
                {
                    PrimaryColor = dto.Branding.PrimaryColor,
                    AccentColor = dto.Branding.AccentColor,
                    BackgroundColor = dto.Branding.BackgroundColor,
                    SecondaryColor = dto.Branding.SecondaryColor,
                    TextColor = dto.Branding.TextColor,
                    Text = new BrandingText
                    {
                        FontName = dto.Branding.TextSettings.FontName,
                        FontSize = dto.Branding.TextSettings.FontSize,
                        FontWeight = dto.Branding.TextSettings.FontWeight
                    },
                    Media = new BrandingMedia
                    {
                        LogoUrl = dto.Branding.MediaSettings.LogoUrl,
                        FaviconUrl = dto.Branding.MediaSettings.FaviconUrl,
                        BackgroundImageUrl = dto.Branding.MediaSettings.BackgroundImageUrl
                    }
                },

                ContentSettings = new ContentSettings
                {
                    WelcomeMessage = dto.ContentSettings.WelcomeMessage,
                    CallToAction = dto.ContentSettings.CallToAction,
                    HomePageContent = dto.ContentSettings.HomePageContent,
                    AboutUs = dto.ContentSettings.AboutUs
                },

                FeatureSettings = new FeatureSettings
                {
                    EnableProducts = dto.FeatureSettings.EnableProducts,
                    EnableBrands = dto.FeatureSettings.EnableBrands,
                    EnableReviews = dto.FeatureSettings.EnableReviews,
                    EnableProductTags = dto.FeatureSettings.EnableProductTags,
                    EnableBillingInfo = dto.FeatureSettings.EnableBillingInfo,
                    EnableShippingInfo = dto.FeatureSettings.EnableShippingInfo,
                    EnableDeliveryMethod = dto.FeatureSettings.EnableDeliveryMethod,
                    EnableStripe = dto.FeatureSettings.EnableStripe,
                    EnablePayPal = dto.FeatureSettings.EnablePayPal,
                    EnableCashOnDelivery = dto.FeatureSettings.EnableCashOnDelivery,
                    EnableApiAccess = dto.FeatureSettings.EnableApiAccess,
                    EnableThemeCustomization = dto.FeatureSettings.EnableThemeCustomization,
                    EnableDealerPlan = dto.FeatureSettings.EnableDealerPlan,
                    EnableMultiAdminPanel = dto.FeatureSettings.EnableMultiAdminPanel
                },

                DomainSettings = new DomainSettings
                {
                    Subdomain = dto.DomainSettings.Subdomain,
                    CustomDomain = dto.DomainSettings.CustomDomain,
                    EnableApiAccess = dto.DomainSettings.EnableApiAccess
                }
            };

            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
            return tenant;
        }

        public async Task<Tenant?> GetTenantWithFeaturesAsync(Guid tenantId)
        {
            return await _context.Tenants
                .Include(t => t.FeatureSettings)
                .FirstOrDefaultAsync(t => t.Id == tenantId);
        }

        public async Task<FeatureSettingsDto?> GetFeatureTogglesAsync(Guid tenantId)
        {
            var tenant = await _context.Tenants
                .Include(t => t.FeatureSettings)
                .FirstOrDefaultAsync(t => t.Id == tenantId);

            if (tenant == null || tenant.FeatureSettings == null)
                return null;

            return new FeatureSettingsDto
            {
                EnableProducts = tenant.FeatureSettings.EnableProducts,
                EnableBrands = tenant.FeatureSettings.EnableBrands,
                EnableReviews = tenant.FeatureSettings.EnableReviews,
                EnableProductTags = tenant.FeatureSettings.EnableProductTags,
                EnableBillingInfo = tenant.FeatureSettings.EnableBillingInfo,
                EnableShippingInfo = tenant.FeatureSettings.EnableShippingInfo,
                EnableDeliveryMethod = tenant.FeatureSettings.EnableDeliveryMethod,
                EnableStripe = tenant.FeatureSettings.EnableStripe,
                EnablePayPal = tenant.FeatureSettings.EnablePayPal,
                EnableCashOnDelivery = tenant.FeatureSettings.EnableCashOnDelivery,
                EnableApiAccess = tenant.FeatureSettings.EnableApiAccess,
                EnableThemeCustomization = tenant.FeatureSettings.EnableThemeCustomization,
                EnableDealerPlan = tenant.FeatureSettings.EnableDealerPlan,
                EnableMultiAdminPanel = tenant.FeatureSettings.EnableMultiAdminPanel
            };
        }

        public async Task<bool> UpdateFeatureTogglesAsync(Guid tenantId, FeatureSettingsDto dto)
        {
            var tenant = await _context.Tenants
                .Include(t => t.FeatureSettings)
                .FirstOrDefaultAsync(t => t.Id == tenantId);

            if (tenant == null || tenant.FeatureSettings == null)
                return false;

            var fs = tenant.FeatureSettings;

            // ✅ Master toggles
            fs.EnableCategoriesManagement = dto.EnableCategoriesManagement;
            fs.EnableCustomerInformation = dto.EnableCustomerInformation;
            fs.EnablePaymentMethods = dto.EnablePaymentMethods;
            fs.EnableAdvancedFeatures = dto.EnableAdvancedFeatures;

            // ✅ Auto-assign child toggles based on master
            // Categories Management
            fs.EnableProducts = dto.EnableCategoriesManagement && dto.EnableProducts;
            fs.EnableBrands = dto.EnableCategoriesManagement && dto.EnableBrands;
            fs.EnableReviews = dto.EnableCategoriesManagement && dto.EnableReviews;
            fs.EnableProductTags = dto.EnableCategoriesManagement && dto.EnableProductTags;

            // Customer Information
            fs.EnableBillingInfo = dto.EnableCustomerInformation && dto.EnableBillingInfo;
            fs.EnableShippingInfo = dto.EnableCustomerInformation && dto.EnableShippingInfo;
            fs.EnableDeliveryMethod = dto.EnableCustomerInformation && dto.EnableDeliveryMethod;

            // Payment Methods
            fs.EnableStripe = dto.EnablePaymentMethods && dto.EnableStripe;
            fs.EnablePayPal = dto.EnablePaymentMethods && dto.EnablePayPal;
            fs.EnableCashOnDelivery = dto.EnablePaymentMethods && dto.EnableCashOnDelivery;

            // Advanced Features
            fs.EnableApiAccess = dto.EnableAdvancedFeatures && dto.EnableApiAccess;
            fs.EnableThemeCustomization = dto.EnableAdvancedFeatures && dto.EnableThemeCustomization;
            fs.EnableDealerPlan = dto.EnableAdvancedFeatures && dto.EnableDealerPlan;
            fs.EnableMultiAdminPanel = dto.EnableAdvancedFeatures && dto.EnableMultiAdminPanel;

            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> UpdateStoreAsync(Guid tenantId, StoreDto dto)
        {
            var tenant = await _context.Tenants
                .Include(t => t.Store)
                    .ThenInclude(s => s.ProductFilters)
                .FirstOrDefaultAsync(t => t.Id == tenantId);

            if (tenant == null)
                return false;

            if (tenant.Store == null)
            {
                tenant.Store = new Store { TenantId = tenantId };
                _context.Stores.Add(tenant.Store);
            }

            // Update store fields
            tenant.Store.Country = dto.Country;
            tenant.Store.Currency = dto.Currency;
            tenant.Store.Language = dto.Language;
            tenant.Store.Timezone = dto.Timezone;
            tenant.Store.EnableTaxCalculations = dto.EnableTaxCalculations;
            tenant.Store.EnableShipping = dto.EnableShipping;
            tenant.Store.EnableFilters = dto.EnableFilters;

            if (dto.EnableFilters && dto.ProductFilters != null)
            {
                // Remove old filters
                _context.Filters.RemoveRange(tenant.Store.ProductFilters);

                // Add new filters
                tenant.Store.ProductFilters = dto.ProductFilters.Select(f => new Filter
                {
                    Name = f.Name,
                    Description = f.Description,
                    IsActive = f.IsActive,
                    Type = f.Type,
                    Category = f.Category,
                    RangeStart = f.RangeStart,
                    RangeEnd = f.RangeEnd,
                    Step = f.Step,
                    Options = f.Options != null ? string.Join(",", f.Options) : null
                }).ToList();
            }
            else
            {
                // Disable filters: clear them
                _context.Filters.RemoveRange(tenant.Store.ProductFilters);
                tenant.Store.ProductFilters.Clear();
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<ProductDto>> GetProductListingsByTenantAsync(Guid tenantId)
        {
            throw new NotImplementedException();
        }
    }
}