using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class FeatureSettings
    {
        public Guid Id { get; set; }

        // Categories Management (already added)
        public bool EnableCategoriesManagement { get; set; }
        public bool EnableProducts { get; set; }
        public bool EnableBrands { get; set; }
        public bool EnableReviews { get; set; }
        public bool EnableProductTags { get; set; }

        // Master Toggle for Customer Info
        public bool EnableCustomerInformation { get; set; }
        public bool EnableBillingInfo { get; set; }
        public bool EnableShippingInfo { get; set; }
        public bool EnableDeliveryMethod { get; set; }

        // Master Toggle for Payment
        public bool EnablePaymentMethods { get; set; }
        public bool EnableStripe { get; set; }
        public bool EnablePayPal { get; set; }
        public bool EnableCashOnDelivery { get; set; }

        // Master Toggle for Advanced
        public bool EnableAdvancedFeatures { get; set; }
        public bool EnableApiAccess { get; set; }
        public bool EnableThemeCustomization { get; set; }
        public bool EnableDealerPlan { get; set; }
        public bool EnableMultiAdminPanel { get; set; }

        public Guid TenantId { get; set; }
    }


}
