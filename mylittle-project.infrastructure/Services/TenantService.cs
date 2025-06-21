using Microsoft.EntityFrameworkCore;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using mylittle_project.Domain.Entities;
using mylittle_project.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Tenant> CreateAsync(TenantDto dto)
        {
            var tenantId = Guid.NewGuid();

            var tenant = new Tenant
            {
                Id = tenantId,
                Name = dto.TenantName,
                TenantName = dto.TenantName,
                TenantNickname = dto.TenantNickname,
                Subdomain = dto.Subdomain,
                IndustryType = dto.IndustryType,
                Status = dto.Status,
                Description = dto.Description,
                IsActive = dto.IsActive,
                LastAccessed = DateTime.UtcNow,
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
                    StateProvince = dto.AdminUser.StateProvince,
                    ZipPostalCode = dto.AdminUser.ZipPostalCode,
                    Country = dto.AdminUser.Country
                },
                Subscription = new Subscription
                {
                    PlanName = dto.Subscription.PlanName,
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
                    EnableCategoriesManagement = dto.FeatureSettings.EnableCategoriesManagement,
                    EnableProducts = dto.FeatureSettings.EnableProducts,
                    EnableBrands = dto.FeatureSettings.EnableBrands,
                    EnableReviews = dto.FeatureSettings.EnableReviews,
                    EnableProductTags = dto.FeatureSettings.EnableProductTags,
                    EnableCustomerInformation = dto.FeatureSettings.EnableCustomerInformation,
                    EnableBillingInfo = dto.FeatureSettings.EnableBillingInfo,
                    EnableShippingInfo = dto.FeatureSettings.EnableShippingInfo,
                    EnableDeliveryMethod = dto.FeatureSettings.EnableDeliveryMethod,
                    EnablePaymentMethods = dto.FeatureSettings.EnablePaymentMethods,
                    EnableStripe = dto.FeatureSettings.EnableStripe,
                    EnablePayPal = dto.FeatureSettings.EnablePayPal,
                    EnableCashOnDelivery = dto.FeatureSettings.EnableCashOnDelivery,
                    EnableAdvancedFeatures = dto.FeatureSettings.EnableAdvancedFeatures,
                    EnableApiAccess = dto.FeatureSettings.EnableApiAccess,
                    EnableThemeCustomization = dto.FeatureSettings.EnableThemeCustomization,
                    EnableDealerPlan = dto.FeatureSettings.EnableDealerPlan,
                    EnableMultiAdminPanel = dto.FeatureSettings.EnableMultiAdminPanel,
                    TenantId = tenantId
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

            var fs = tenant.FeatureSettings;

            return new FeatureSettingsDto
            {
                TenantId = tenantId,
                EnableCategoriesManagement = fs.EnableCategoriesManagement,
                EnableProducts = fs.EnableProducts,
                EnableBrands = fs.EnableBrands,
                EnableReviews = fs.EnableReviews,
                EnableProductTags = fs.EnableProductTags,
                EnableCustomerInformation = fs.EnableCustomerInformation,
                EnableBillingInfo = fs.EnableBillingInfo,
                EnableShippingInfo = fs.EnableShippingInfo,
                EnableDeliveryMethod = fs.EnableDeliveryMethod,
                EnablePaymentMethods = fs.EnablePaymentMethods,
                EnableStripe = fs.EnableStripe,
                EnablePayPal = fs.EnablePayPal,
                EnableCashOnDelivery = fs.EnableCashOnDelivery,
                EnableAdvancedFeatures = fs.EnableAdvancedFeatures,
                EnableApiAccess = fs.EnableApiAccess,
                EnableThemeCustomization = fs.EnableThemeCustomization,
                EnableDealerPlan = fs.EnableDealerPlan,
                EnableMultiAdminPanel = fs.EnableMultiAdminPanel
            };
        }

        public async Task<bool> UpdateFeatureTogglesAsync(Guid tenantId, FeatureSettingsDto dto)
        {
            var tenant = await _context.Tenants
                .Include(t => t.FeatureSettings)
                .FirstOrDefaultAsync(t => t.Id == tenantId);

            if (tenant?.FeatureSettings == null) return false;

            var fs = tenant.FeatureSettings;

            fs.EnableCategoriesManagement = dto.EnableCategoriesManagement;
            fs.EnableProducts = dto.EnableCategoriesManagement && dto.EnableProducts;
            fs.EnableBrands = dto.EnableCategoriesManagement && dto.EnableBrands;
            fs.EnableReviews = dto.EnableCategoriesManagement && dto.EnableReviews;
            fs.EnableProductTags = dto.EnableCategoriesManagement && dto.EnableProductTags;

            fs.EnableCustomerInformation = dto.EnableCustomerInformation;
            fs.EnableBillingInfo = dto.EnableCustomerInformation && dto.EnableBillingInfo;
            fs.EnableShippingInfo = dto.EnableCustomerInformation && dto.EnableShippingInfo;
            fs.EnableDeliveryMethod = dto.EnableCustomerInformation && dto.EnableDeliveryMethod;

            fs.EnablePaymentMethods = dto.EnablePaymentMethods;
            fs.EnableStripe = dto.EnablePaymentMethods && dto.EnableStripe;
            fs.EnablePayPal = dto.EnablePaymentMethods && dto.EnablePayPal;
            fs.EnableCashOnDelivery = dto.EnablePaymentMethods && dto.EnableCashOnDelivery;

            fs.EnableAdvancedFeatures = dto.EnableAdvancedFeatures;
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

            if (tenant?.Store == null)
            {
                tenant!.Store = new Store { TenantId = tenantId };
                _context.Stores.Add(tenant.Store);
            }

            tenant.Store.Country = dto.Country;
            tenant.Store.Currency = dto.Currency;
            tenant.Store.Language = dto.Language;
            tenant.Store.Timezone = dto.Timezone;
            tenant.Store.EnableTaxCalculations = dto.EnableTaxCalculations;
            tenant.Store.EnableShipping = dto.EnableShipping;
            tenant.Store.EnableFilters = dto.EnableFilters;

            if (dto.EnableFilters && dto.ProductFilters != null)
            {
                _context.Filters.RemoveRange(tenant.Store.ProductFilters);
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
                _context.Filters.RemoveRange(tenant.Store.ProductFilters);
                tenant.Store.ProductFilters.Clear();
            }

            await _context.SaveChangesAsync();
            return true;
        }

        

        
    }
}
