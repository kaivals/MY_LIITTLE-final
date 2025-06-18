public class FeatureSettingsDto
{
    // === Master Toggles ===

    public bool EnableCategoriesManagement { get; set; }
    public bool EnableCustomerInformation { get; set; }
    public bool EnablePaymentMethods { get; set; }
    public bool EnableAdvancedFeatures { get; set; }

    // === Categories Management Features ===
    public bool EnableProducts { get; set; }
    public bool EnableBrands { get; set; }
    public bool EnableReviews { get; set; }
    public bool EnableProductTags { get; set; }

    // === Customer Information Features ===
    public bool EnableBillingInfo { get; set; }
    public bool EnableShippingInfo { get; set; }
    public bool EnableDeliveryMethod { get; set; }

    // === Payment Method Features ===
    public bool EnableStripe { get; set; }
    public bool EnablePayPal { get; set; }
    public bool EnableCashOnDelivery { get; set; }

    // === Advanced Features ===
    public bool EnableApiAccess { get; set; }
    public bool EnableThemeCustomization { get; set; }
    public bool EnableDealerPlan { get; set; }
    public bool EnableMultiAdminPanel { get; set; }
}
    