using System;

namespace mylittle_project.Domain.Entities
{
    public class TenentPortalLink
    {
        public int Id { get; set; }
        public Guid SourceTenantId { get; set; }
        public Guid TargetTenantId { get; set; }
        public string LinkType { get; set; } = string.Empty;
        public DateTime LinkedSince { get; set; }

        public Tenant? SourceTenant { get; set; }
        public Tenant? TargetTenant { get; set; }
    }

}