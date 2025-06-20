using System;

namespace mylittle_project.Domain.Entities
{
    public class TenantFeature
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }

        public bool IsEnabled { get; set; }
    }
}

